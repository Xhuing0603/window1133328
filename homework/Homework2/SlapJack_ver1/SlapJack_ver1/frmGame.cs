using System;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlapJack_ver1
{
    public partial class frmGame : Form
    {
        public frmGame()
        {
            InitializeComponent();
        }

        private void progressBarCalibration_MouseDown(object sender, MouseEventArgs e)
        {
            if (!calibrationActive) return;

            var pb = progressBarCalibration;
            int max = pb.Maximum;
            int clientWidth = Math.Max(1, pb.ClientRectangle.Width);
            double ratio = (double)e.X / clientWidth;
            ratio = Math.Max(0.0, Math.Min(1.0, ratio));
            int clickedValue = (int)Math.Round(ratio * max);

            bool hit = (clickedValue >= calibrationTargetX && clickedValue <= calibrationTargetX + calibrationTargetWidth);

            EndCalibration(hit, true);
        }

        private void HandlePlayerMisSlap()
        {
            if (centralCount <= 0)
            {
                lblMessage.Text = "你拍錯了，但中央棄牌堆為空。";
                return;
            }

            int half = centralCount / 2;
            int remainder = centralCount - (half * 2);
            ai1Count += half;
            ai2Count += half;

            if (remainder > 0) ai1Count += remainder;

            lblMessage.Text = $"玩家錯拍，\n中央牌堆 {centralCount} 張分給電腦A和電腦B。";
            centralCount = 0;
            UpdateLabels();
 
            try { expectedNumber = 1; } catch { }
            try { nextVoiceIndex = 0; }
            catch { }
            try
            {
                if (voiceResourceNames != null && voiceResourceNames.Count > 0)
                {
                    string resName = voiceResourceNames[0];
                    var obj = Properties.Resources.ResourceManager.GetObject(resName, Properties.Resources.Culture);
                    if (obj is System.IO.UnmanagedMemoryStream ums)
                    {
                        new SoundPlayer(ums).Play();
                    }
                    else if (obj is System.IO.Stream s)
                    {
                        new SoundPlayer(s).Play();
                    }
                    else if (obj is byte[] b)
                    {
                        var ms = new System.IO.MemoryStream(b);
                        new SoundPlayer(ms).Play();
                    }
                    else
                    {
                        System.Media.SystemSounds.Beep.Play();
                    }
                }
                else
                {
                    System.Media.SystemSounds.Beep.Play();
                }
            }
            catch { try { System.Media.SystemSounds.Beep.Play(); } catch { } }
            try { timerAIFlip.Stop(); } catch { }
            try { if (btnFlip != null) btnFlip.Enabled = false; } catch { }
            try { timerClaimPause.Interval = 1500; timerClaimPause.Start(); } catch { }
        }

        private Random rnd = new Random();
        private int humanCount = 0;
        private int ai1Count = 0;
        private int ai2Count = 0;
        private int centralCount = 0;
        private bool calibrationActive = false;
        private int flipTurn = 0; // 0: AI1, 1: AI2, 2: Human
        private int calibrationTargetX = 0;
        private int calibrationTargetWidth = 0;
        private int calibrationHoldTicks = 0;
        private System.Collections.Generic.List<Control> subscribedControls = new System.Collections.Generic.List<Control>();

        private bool cardVisible = false;
        private string lastCardResourceName = null;
        private List<string> faceResourceNames = null;
        private List<string> heartResourceNames = null;
        private int heartsIndexInGroup = 2;
        private int expectedNumber = 1;
        private List<string> voiceResourceNames = null;
        private int nextVoiceIndex = 0;

        private double ai1ReactionMs = 0;
        private double ai2ReactionMs = 0;
        private DateTime calibrationStartTime;
        private bool calibrationClaimed = false;

        private void frmGame_Load(object sender, EventArgs e)
        {
            DealCards();
            UpdateLabels();
            EnsureLoadResources();
            timerAIFlip.Start();
            lblMessage.Text = "遊戲開始！請等待翻牌。";
        }

        private void DealCards()
        {
            int total = 52;
            int players = 3;
            int baseCount = total / players; 
            int remainder = total % players; 

            ai1Count = baseCount;
            ai2Count = baseCount;
            humanCount = baseCount;

            humanCount += remainder;

            centralCount = 0;

            expectedNumber = 1;
        }

        private void EnsureLoadResources()
        {
            if (faceResourceNames != null) return;
            faceResourceNames = new List<string>();
            heartResourceNames = new List<string>();
            voiceResourceNames = new List<string>();

            var rm = Properties.Resources.ResourceManager;
            var set = rm.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            if (set == null) return;
            foreach (System.Collections.DictionaryEntry entry in set)
            {
                string name = entry.Key as string;
                object val = entry.Value;
                if (name == null || val == null) continue;
                if (val is System.Drawing.Bitmap || val is System.Drawing.Image)
                {
                    string lname = name.ToLowerInvariant();
                    if (lname == "back") continue; // skip back
                    faceResourceNames.Add(name);
                    if (lname.Contains("heart") || lname.Contains("hearts") || lname.Contains("diamond") || lname.Contains("♦"))
                    {
                        heartResourceNames.Add(name);
                    }
                }
                else
                {
                    // audio resources in .resx are often UnmanagedMemoryStream or Stream
                    if (val is System.IO.UnmanagedMemoryStream || val is System.IO.Stream || val is byte[])
                    {
                        string lname = name.ToLowerInvariant();
                        if (lname.StartsWith("voice") || lname.Contains("voice") || lname.StartsWith("sound"))
                        {
                            voiceResourceNames.Add(name);
                        }
                    }
                }
            }
            // sort voice resources by trailing digits if present (voice1wav, voice2wav ...)
            try
            {
                voiceResourceNames = voiceResourceNames
                    .OrderBy(n => {
                        var digits = new string(n.Where(char.IsDigit).ToArray());
                        if (int.TryParse(digits, out int idx)) return idx;
                        return int.MaxValue;
                    })
                    .ThenBy(n => n)
                    .ToList();
            }
            catch { }

            // fallback: if no faces found, keep back as only resource
            if (faceResourceNames.Count == 0)
            {
                // do nothing
            }
        }

        private void UpdateLabels()
        {
            lblHuman.Text = $"玩家 (你): {humanCount} 牌";
            lblAI1.Text = $"電腦A: {ai1Count} 牌";
            lblAI2.Text = $"電腦B: {ai2Count} 牌";
            lblCentralPile.Text = $"中央牌堆: {centralCount} 張";
            CheckGameOver();
        }

        // If both computer players have zero cards, end the game.
        private void CheckGameOver()
        {
            // End the game if both computer players have no cards, or if the human has no cards
            if ((ai1Count == 0 && ai2Count == 0) || humanCount == 0)
            {
                // stop all timers and disable player input
                try { timerAIFlip.Stop(); } catch { }
                try { timerCardDisplay.Stop(); } catch { }
                try { timerCalibration.Stop(); } catch { }
                UnsubscribeClicksDuringCalibration();
                if (btnFlip != null) btnFlip.Enabled = false;

                string msg;
                if (humanCount == 0)
                {
                    msg = "遊戲結束！你沒有牌了。";
                }
                else
                {
                    msg = "遊戲結束！電腦玩家已無牌。";
                }

                // show summary form modally and wait for user to press 繼續
                try
                {
                    using (var summary = new frmSummary(msg))
                    {
                        var dr = summary.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            try
                            {
                                var start = System.Windows.Forms.Application.OpenForms.OfType<frmStart>().FirstOrDefault();
                                if (start != null)
                                {
                                    start.Show();
                                    start.BringToFront();
                                }
                                else
                                {
                                    start = new frmStart();
                                    start.Show();
                                }
                            }
                            catch { }
                        }
                    }
                }
                catch { }

                // close game form after returning from summary
                this.Close();
            }
        }

        private void timerAIFlip_Tick(object sender, EventArgs e)
        {
            if (calibrationActive) return; 
            if (cardVisible) return; 

            if (!AdvanceToNextWithCards())
            {
                timerAIFlip.Stop();
                return;
            }

            int shownRank = 0;
            if (flipTurn == 0)
            {
                if (ai1Count > 0)
                {
                    ai1Count--;
                    centralCount++;
                    shownRank = ShowCard();
                    lblMessage.Text = "電腦A 翻出一張牌" + (shownRank == expectedNumber ? "（拍！）" : "");
                    if (shownRank == expectedNumber) StartCalibration();
                }
            }
            else if (flipTurn == 1)
            {
                if (ai2Count > 0)
                {
                    ai2Count--;
                    centralCount++;
                    shownRank = ShowCard();
                    lblMessage.Text = "電腦B 翻出一張牌" + (shownRank == expectedNumber ? "（拍！）" : "");
                    if (shownRank == expectedNumber) StartCalibration();
                }
            }
            else // human turn automatic
            {
                if (humanCount > 0)
                {
                    humanCount--;
                    centralCount++;
                    shownRank = ShowCard();
                    lblMessage.Text = "你 翻出一張牌" + (shownRank == expectedNumber ? "（拍！）" : "");
                    if (shownRank == expectedNumber) StartCalibration();
                }
            }

            UpdateLabels();

            if (shownRank != 0 && shownRank == expectedNumber)
            {
                expectedNumber = 1;
            }
            else
            {
                expectedNumber = (expectedNumber % 13) + 1;
            }

            flipTurn = (flipTurn + 1) % 3;
            AdvanceToNextWithCards();
        }

        private bool AdvanceToNextWithCards()
        {
            int totalPlayers = 3;
            bool anyHas = (humanCount > 0) || (ai1Count > 0) || (ai2Count > 0);
            if (!anyHas) return false;

            for (int i = 0; i < totalPlayers; i++)
            {
                int idx = (flipTurn + i) % totalPlayers;
                if ((idx == 0 && ai1Count > 0) || (idx == 1 && ai2Count > 0) || (idx == 2 && humanCount > 0))
                {
                    flipTurn = idx;
                    return true;
                }
            }

            return false;
        }

        private void btnFlip_Click(object sender, EventArgs e)
        {
            if (humanCount <= 0)
            {
                lblMessage.Text = "你沒有牌可以翻。";
                return;
            }

            humanCount--;
            centralCount++;
            int rank = ShowCard();
            lblMessage.Text = "你 翻出一張牌" + (rank == expectedNumber ? "（拍！）" : "");
            UpdateLabels();
            if (rank == expectedNumber)
            {
                StartCalibration();
                expectedNumber = 1;
            }
            else
            {
                // increment expected number for next flip (wrap 1..13)
                expectedNumber = (expectedNumber % 13) + 1;
            }
        }

        private void StartCalibration()
        {
            // 改為玩家需點擊畫面中顯示的牌 (pictureBoxCard) 以搶牌
            calibrationActive = true;

            // 確保牌顯示於最上層並可被點擊
            if (pictureBoxCard.Image != null)
            {
                pictureBoxCard.Visible = true;
                pictureBoxCard.BringToFront();
            }

            // 設定判定窗口為 0.0 ~ 2.0 秒
            int duration = rnd.Next(0, 2000);
            timerCalibration.Stop();
            timerCalibration.Interval = duration;
            timerCalibration.Start();

            // record calibration start time
            calibrationStartTime = DateTime.UtcNow;
            calibrationClaimed = false;

            // schedule AI slap times randomly between 500ms and 1500ms from now
            ai1ReactionMs = rnd.Next(1300, 1501);
            ai2ReactionMs = rnd.Next(1300, 1501);
            timerAISlap1?.Stop();
            timerAISlap2?.Stop();
            if (timerAISlap1 != null) timerAISlap1.Interval = (int)Math.Max(1, ai1ReactionMs);
            if (timerAISlap2 != null) timerAISlap2.Interval = (int)Math.Max(1, ai2ReactionMs);
            timerAISlap1?.Start();
            timerAISlap2?.Start();

            lblMessage.Text = "請搶拍。";

            timerAIFlip.Stop();
        }

        // Show a randomly chosen face card and return its rank (1..13). Returns 0 if unknown.
        private int ShowCard()
        {
            try
            {
                EnsureLoadResources();
                Image img = null;
                string chosen = null;

                // choose a random face image if available
                if (faceResourceNames != null && faceResourceNames.Count > 0)
                {
                    chosen = faceResourceNames[rnd.Next(faceResourceNames.Count)];
                }

                if (string.IsNullOrEmpty(chosen))
                {
                    img = Properties.Resources.back;
                    lastCardResourceName = "back";
                }
                else
                {
                    object o = Properties.Resources.ResourceManager.GetObject(chosen, Properties.Resources.Culture);
                    if (o is Image)
                    {
                        img = (Image)o;
                        lastCardResourceName = chosen;
                    }
                    else
                    {
                        img = Properties.Resources.back;
                        lastCardResourceName = "back";
                    }
                }

                if (img != null)
                {
                    pictureBoxCard.Image = img;
                    pictureBoxCard.Visible = true;
                    pictureBoxCard.BringToFront();
                    cardVisible = true;
                    // 顯示卡片一段短時間，若進入校準（紅心）則保留直到校準結束
                    timerCardDisplay.Stop();
                    timerCardDisplay.Interval = 1000; // 顯示 1 秒
                    timerCardDisplay.Start();
                }

                // play next voice if available
                try { PlayNextVoice(); } catch { }

                // Determine rank based on resource name like pic1..pic52 -> rank = ((idx-1)/4)+1
                int rank = 0;
                try
                {
                    string lname = lastCardResourceName?.ToLowerInvariant() ?? "";
                    var digits = new string(lname.Where(char.IsDigit).ToArray());
                    if (int.TryParse(digits, out int idx) && idx >= 1)
                    {
                        rank = ((idx - 1) / 4) + 1; // 1..13
                        if (rank < 1 || rank > 13) rank = 0;
                    }
                }
                catch { rank = 0; }

                return rank;
            }
            catch { return 0; }
        }

        private void PlayNextVoice()
        {
            if (voiceResourceNames == null || voiceResourceNames.Count == 0) return;

            // ensure index in range
            if (nextVoiceIndex < 0 || nextVoiceIndex >= voiceResourceNames.Count) nextVoiceIndex = 0;
            string resName = voiceResourceNames[nextVoiceIndex];
            nextVoiceIndex = (nextVoiceIndex + 1) % voiceResourceNames.Count;

            try
            {
                var obj = Properties.Resources.ResourceManager.GetObject(resName, Properties.Resources.Culture);
                if (obj is System.IO.UnmanagedMemoryStream ums)
                {
                    var sp = new SoundPlayer(ums);
                    sp.Play();
                    return;
                }
                else if (obj is System.IO.Stream s)
                {
                    var sp = new SoundPlayer(s);
                    sp.Play();
                    return;
                }
                else if (obj is byte[] b)
                {
                    var ms = new System.IO.MemoryStream(b);
                    var sp = new SoundPlayer(ms);
                    sp.Play();
                    return;
                }
            }
            catch { }
        }

        private void timerCardDisplay_Tick(object sender, EventArgs e)
        {
            timerCardDisplay.Stop();
            // 如果正在校準（紅心出現），保留卡片直到校準結束，否則隱藏並允許自動翻牌
            if (calibrationActive)
            {
                // keep visible until EndCalibration
                return;
            }

            pictureBoxCard.Visible = false;
            cardVisible = false;
            timerAIFlip.Start();
        }

        private void timerCalibration_Tick(object sender, EventArgs e)
        {
            // 當 timerCalibration 到期，代表按鈕消失，玩家未按到 -> 視為失敗
            if (!calibrationActive) return;

            // 目前行為為單次 timeout，超時即結束校準並隨機由某台AI取得
            EndCalibration(false, false);
        }

        private void btnCalibrate_Click(object sender, EventArgs e)
        {
            if (!calibrationActive)
            {
                // 玩家在非出現時間按下，視為誤拍，中央棄牌堆平均分給電腦A和B
                HandlePlayerMisSlap();
                return;
            }

            // 玩家成功按下出現的按鈕，給予玩家中央棄牌堆
            EndCalibration(true, true);
        }

        private void pictureBoxCard_Click(object sender, EventArgs e)
        {
            if (!calibrationActive)
            {
                // player slapped at the wrong time -> penalty, split central pile evenly between AI A and B
                HandlePlayerMisSlap();
                return;
            }

            // player clicked the card within the allowed interval -> check reaction time
            var playerMs = (DateTime.UtcNow - calibrationStartTime).TotalMilliseconds;
            // if any AI already claimed, player loses; otherwise player must be faster than both AIs
            if (calibrationClaimed)
            {
                // someone already claimed
                EndCalibration(false, true);
                return;
            }

            bool fasterThanAI1 = playerMs < ai1ReactionMs;
            bool fasterThanAI2 = playerMs < ai2ReactionMs;

            // stop AI timers since player acted
            try { timerAISlap1.Stop(); } catch { }
            try { timerAISlap2.Stop(); } catch { }

            if (fasterThanAI1 && fasterThanAI2)
            {
                EndCalibration(true, true);
            }
            else
            {
                // player was slower than at least one AI -> AI wins
                EndCalibration(false, true);
            }
        }

        private void TimerAISlap1_Tick(object sender, EventArgs e)
        {
            timerAISlap1.Stop();
            if (!calibrationActive) return;
            // Do not allow AI to claim before the card is actually visible
            if (pictureBoxCard == null || !pictureBoxCard.Visible) return;
            var elapsed = (DateTime.UtcNow - calibrationStartTime).TotalMilliseconds;
            // if player already claimed, ignore
            if (calibrationClaimed) return;
            // if AI's reaction time passed and AI is faster than player, AI claims
            if (elapsed >= ai1ReactionMs)
            {
                calibrationClaimed = true;
                EndCalibration(false, false);
            }
        }

        private void TimerAISlap2_Tick(object sender, EventArgs e)
        {
            timerAISlap2.Stop();
            if (!calibrationActive) return;
            // Do not allow AI to claim before the card is actually visible
            if (pictureBoxCard == null || !pictureBoxCard.Visible) return;
            var elapsed = (DateTime.UtcNow - calibrationStartTime).TotalMilliseconds;
            if (calibrationClaimed) return;
            if (elapsed >= ai2ReactionMs)
            {
                calibrationClaimed = true;
                EndCalibration(false, false);
            }
        }

        private void timerClaimPause_Tick(object sender, EventArgs e)
        {
            try { timerClaimPause.Stop(); } catch { }
            try { timerAIFlip.Start(); } catch { }
            try { if (btnFlip != null) btnFlip.Enabled = true; } catch { }
        }

        private void SubscribeClicksDuringCalibration()
        {
            subscribedControls.Clear();
            // subscribe form itself
            this.MouseDown -= AnyControl_MouseDown;
            this.MouseDown += AnyControl_MouseDown;
            subscribedControls.Add(this);

            foreach (Control c in this.Controls)
            {
                // don't re-subscribe pnlTarget if already handled; still safe
                c.MouseDown -= AnyControl_MouseDown;
                c.MouseDown += AnyControl_MouseDown;
                subscribedControls.Add(c);
            }
        }

        private void UnsubscribeClicksDuringCalibration()
        {
            foreach (Control c in subscribedControls)
            {
                try { c.MouseDown -= AnyControl_MouseDown; } catch { }
            }
            subscribedControls.Clear();
        }

        private void AnyControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (!calibrationActive) return;
            // Any click counts as attempt. We'll map the click position to the progressBar value
            // and also consider clicks directly on the colored target panel as hits.
            Control src = sender as Control;
            if (src == null) return;

            // Get screen coordinates of the click
            Point screenPt = src.PointToScreen(new Point(e.X, e.Y));

            // Map to progressBar client coordinates
            Point pbClient = progressBarCalibration.PointToClient(screenPt);
            int max = progressBarCalibration.Maximum;
            int clientWidth = Math.Max(1, progressBarCalibration.ClientRectangle.Width);
            double ratio = (double)pbClient.X / clientWidth;
            ratio = Math.Max(0.0, Math.Min(1.0, ratio));
            int clickedValue = (int)Math.Round(ratio * max);

            // Also check if the click (in form client coords) is inside pnlTarget bounds
            Point formClient = this.PointToClient(screenPt);
            bool insideTargetPanel = pnlTarget.Bounds.Contains(formClient);

            bool hit = insideTargetPanel || (clickedValue >= calibrationTargetX && clickedValue <= calibrationTargetX + calibrationTargetWidth);

            EndCalibration(hit, true);
        }

        private void EndCalibration(bool playerHit, bool byClick)
        {
            // centralize end-of-calibration logic
            timerCalibration.Stop();
            calibrationActive = false;
            progressBarCalibration.Visible = false;
            btnCalibrate.Visible = false;
            pnlTarget.Visible = false;

            if (playerHit)
            {
                humanCount += centralCount;
                lblMessage.Text = $"你命中目標區域\n獲得 {centralCount} 張中央棄牌堆！";
            }
            else
            {
                if (rnd.Next(0, 2) == 0)
                {
                    ai1Count += centralCount;
                    lblMessage.Text = $"電腦A 搶到中央棄牌堆\n獲得 {centralCount} 張牌。";
                }
                else
                {
                    ai2Count += centralCount;
                    lblMessage.Text = $"電腦B 搶到中央棄牌堆\n獲得 {centralCount} 張牌。";
                }
            }

            // reset audio sequence when central pile is claimed
            try { nextVoiceIndex = 0; } catch { }

            centralCount = 0;
            UpdateLabels();

            // hide displayed card and stop card timer
            try { timerCardDisplay.Stop(); } catch { }
            pictureBoxCard.Visible = false;
            cardVisible = false;

            // stop AI slap timers
            try { timerAISlap1.Stop(); } catch { }
            try { timerAISlap2.Stop(); } catch { }

            UnsubscribeClicksDuringCalibration();

            // 暫停約 1.5 秒，讓玩家可看到誰取得中央棄牌堆，之後由 timerClaimPause_Tick 恢復自動翻牌
            try { if (btnFlip != null) btnFlip.Enabled = false; } catch { }
            try { timerClaimPause.Interval = 1500; timerClaimPause.Start(); } catch { }
        }
    }
}