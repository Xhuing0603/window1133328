using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Poker
{
    public partial class frmPoker : Form
    {
        // 滾動文字相關欄位
        private int specialX;
        private string specialText = "歡迎來到撲克遊戲！請下注開始。";
        PictureBox[] pic = new PictureBox[5];
        int[] allPoker = new int[52];
        int[] playerPoker = new int[5];
        int playerMoney = 1000000;
        int betMoney = 0;
        int multipleMoney = 1;
        bool checkpoint = false;
        public frmPoker()
        {
            InitializeComponent();
            InitializePoker();
            // 初始化滾動標籤
            lblSpecial.Text = specialText;
            // 從右邊開始
            specialX = pnlSpecial.Width;
            lblSpecial.Left = specialX;
            timerSpecial.Start();
        }

        private Bitmap GetPic(string name)
        {
            return Properties.Resources.ResourceManager.
            GetObject(name) as Bitmap;
        }

        private void pic_Click(object sender, MouseEventArgs e)
        {
            PictureBox pic = (PictureBox)sender;

            int index = int.Parse(pic.Name.Replace("pic", ""));
            // 如果pic 的Tag 為back，則將顯示撲克牌
            if (pic.Tag.ToString() == "back")
            {
                pic.Tag = "front";
                pic.Image = GetPic("pic" + (playerPoker[index] + 1));
            }
            else
            {
                pic.Tag = "back";
                pic.Image = GetPic("back");
            }
            // MessageBox.Show("你選擇了" + pic.Name);
        }

        private void InitializePoker()
        {
            // 動態產生5張牌
            for (int i = 0; i < 5; i++)
            {
                pic[i] = new PictureBox();
                pic[i].Image = GetPic("back");
                pic[i].Name = "pic" + i;
                pic[i].SizeMode = PictureBoxSizeMode.AutoSize;
                pic[i].Top = 30;
                pic[i].Left = 10 + ((pic[i].Width + 10) * i);
                pic[i].Visible = true;
                pic[i].Enabled = false;
                pic[i].Tag = "back";
                // 將pic 丟至到grpPorker內
                this.grpPoker.Controls.Add(pic[i]);
                pic[i].MouseClick += new MouseEventHandler(pic_Click);
            }
        }

        private async void btnDealCard_Click(object sender, EventArgs e)
        {
            // 只有在已下注 (checkpoint == true) 時才允許發牌
            if (!checkpoint)
            {
                MessageBox.Show("請先下注");
                return;
            }
            // 發牌後清除下注檢查點，避免重複發牌而不重新下注
            checkpoint = false;
            btnDealCard.Enabled = false;
            for (int i = 0; i < 5; i++)
            {
                pic[i].Image = GetPic("back");
            }
            // 初始化52張牌
            for (int i = 0; i < 52; i++)
            {
                allPoker[i] = i;
            }
            // 洗牌
            Shuffle();
            // 發牌
            await Task.Delay(500);
            for (int i = 0; i < 5; i++)
            {
                pic[i].Image = GetPic("pic" + (allPoker[i] + 1));
                playerPoker[i] = allPoker[i];
            }
   
            for (int i = 0; i < 5; i++)
            {
                pic[i].Enabled = true;
                pic[i].Tag = "front";
            }
            btnChangeCard.Enabled = true;
        }

        private void Shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < allPoker.Length; i++)
            {
                int r = rand.Next(allPoker.Length);
                int temp = allPoker[r];
                allPoker[r] = allPoker[0];
                allPoker[0] = temp;
            }
        }

        private void btnChangeCard_Click(object sender, EventArgs e)
        {
            int cardIndex = 5;
            for (int i = 0; i < pic.Length; i++)
            {
                if (pic[i].Tag.ToString() == "back")
                {
                    playerPoker[i] = allPoker[cardIndex];
                    pic[i].Image = GetPic("pic" + (playerPoker[i] + 1));
                    pic[i].Tag = "front";
                    cardIndex++;
                }
            }
            // 禁用所有牌的點擊事件
            for (int i = 0; i < pic.Length; i++)
            {
                pic[i].Enabled = false;
            }
            btnCheck.Enabled = true;
        }
        
        // 計錄目前五張撲克牌的花色和點數的陣列
        private void btnCheck_Click(object sender, EventArgs e)
        {
            string[] colorList = { "梅花", "方塊", "愛心", "黑桃" };
            string[] pointList = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
            int[] pokerColor = new int[5];
            int[] pokerPoint = new int[5];

            for (int i = 0; i < 5; i++)
            {
                pokerColor[i] = playerPoker[i] % 4;
                pokerPoint[i] = playerPoker[i] / 4;
            }

            int[] colorCount = new int[4];
            int[] pointCount = new int[13];

            for (int i = 0; i < 5; i++)
            {
                int color = pokerColor[i];
                int point = pokerPoint[i];
                colorCount[color]++;
                pointCount[point]++;
            }
            // 排序colorCount和pointCount由大到小
            Array.Sort(colorCount, colorList);
            Array.Reverse(colorCount);
            Array.Reverse(colorList);
            Array.Sort(pointCount, pointList);
            Array.Reverse(pointCount);
            Array.Reverse(pointList);
            // 判斷是否為同花
            bool isFlush = (colorCount[0] == 5);
            // 判斷是否為五張單張
            bool isSingle = (pointCount[0] == 1 && pointCount[1] == 1 && pointCount[2] == 1 && pointCount[3] == 1 && pointCount[4] == 1);
            // 判斷是否為差四
            bool isDiffFout = (pokerPoint.Max() - pokerPoint.Min() == 4);
            // 判斷是否為大順
            bool isRoyal = pokerPoint.Contains(0) && pokerPoint.Contains(9) && pokerPoint.Contains(10) && pokerPoint.Contains(11) && pokerPoint.Contains(12);
            // 判斷是否為同花大順
            bool isRoyalisFlush = isFlush && isRoyal;
            // 判斷是否為同花順
            bool isStraightFlush = isFlush && isSingle && isDiffFout;
            // 判斷是否為順子
            bool isStraight = isSingle && (isDiffFout || isRoyal);
            // 判斷是否為鐵支
            bool isFourOfAKind = (pointCount[0] == 4);
            // 判斷是否為葫蘆
            bool isFullHouse = (pointCount[0] == 3 && pointCount[1] == 2);
            // 判斷是否為三條
            bool isThreeOfAKind = (pointCount[0] == 3 && pointCount[1] == 1);
            // 判斷是否為兩對
            bool isTwoPair = (pointCount[0] == 2 && pointCount[1] == 2);
            // 判斷是否為一對
            bool isOnePair = (pointCount[0] == 2 && pointCount[1] == 1);
            string result = "";
            if (isRoyalisFlush)
            {
                result = $"{colorList[0]}同花大順";
                multipleMoney = 250;
            }
            else if(isStraightFlush) {
                result = $"{colorList[0]}同花順";
                multipleMoney = 50;
            }
            else if(isStraight) {
                result = "順子";
                multipleMoney = 4;
            }
            else if(isFourOfAKind) {
                result = $"{pointList[0]}鐵支";
                multipleMoney = 25;
            }
            else if(isFullHouse) {
                result = $"{pointList[0]}三張{pointList[1]}兩張葫蘆";
                multipleMoney = 9;
            }
            else if(isFlush) {
                result = $"{colorList[0]}同花";
                multipleMoney = 6;
            }
            else if(isThreeOfAKind) {
                result = $"{pointList[0]}三條";
                multipleMoney = 3;
            }
            else if(isTwoPair) {
                result = $"{pointList[0]},{pointList[1]}兩對";
                multipleMoney = 2;
            }
            else if(isOnePair) {
                result = $"{pointList[0]}一對";
                multipleMoney = 1;
            } else
            {
                result = "雜牌";
                multipleMoney = 0;
            }
            lblResult.Text = result;
            btnChangeCard.Enabled = false;
            btnCheck.Enabled = false;
            txtBetMoney.Enabled = false;
            if (multipleMoney == 0)
            {
                playerMoney = playerMoney - betMoney;
            }
            else
            {
                playerMoney = playerMoney + (betMoney * multipleMoney);
            }
            txtMoney.Text = playerMoney.ToString();
        }

        private void frmPoker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (btnDealCard.Enabled == false)
            {
                switch (e.KeyChar)
                {
                    case 'q': // q鍵
                              // 同花大順
                        playerPoker[0] = 51;
                        playerPoker[1] = 47;
                        playerPoker[2] = 43;
                        playerPoker[3] = 39;
                        playerPoker[4] = 3;
                        break;
                    case 'w': // w鍵
                              // 同花順
                        playerPoker[0] = 37;
                        playerPoker[1] = 33;
                        playerPoker[2] = 29;
                        playerPoker[3] = 25;
                        playerPoker[4] = 21;
                        break;
                    case 'e': // e鍵
                              // 同花
                        playerPoker[0] = 50;
                        playerPoker[1] = 38;
                        playerPoker[2] = 34;
                        playerPoker[3] = 22;
                        playerPoker[4] = 18;
                        break;
                    case 'r': // r鍵
                              // 鐵支
                        playerPoker[0] = 48;
                        playerPoker[1] = 39;
                        playerPoker[2] = 38;
                        playerPoker[3] = 37;
                        playerPoker[4] = 36;
                        break;
                    case 't': // t鍵
                              // 葫蘆
                        playerPoker[0] = 30;
                        playerPoker[1] = 29;
                        playerPoker[2] = 6;
                        playerPoker[3] = 5;
                        playerPoker[4] = 4;
                        break;
                    case 'y': // y鍵
                              // 三條
                        playerPoker[0] = 48;
                        playerPoker[1] = 39;
                        playerPoker[2] = 15;
                        playerPoker[3] = 14;
                        playerPoker[4] = 13;
                        break;
                }
                // 顯示五張撲克牌到桌面上
                ShowCards();
            }
        }
        private void ShowCards()
        {
            for (int i = 0; i < 5; i++)
            {
                pic[i].Image = GetPic($"pic{playerPoker[i] + 1}");
            }
        }

        private void timerSpecial_Tick(object sender, EventArgs e)
        {
            // 每次向左移動一個像素，若完全移出則從右側重新開始
            specialX -= 1;
            lblSpecial.Left = specialX;
            if (lblSpecial.Right < 0)
            {
                specialX = pnlSpecial.Width;
                lblSpecial.Left = specialX;
            }
        }

        private void btnBet_Click(object sender, EventArgs e)
        {
            //playerMoney = playerMoney - betMoney;
            //playerMoney = playerMoney + ( betMoney * multipleMoney );
            // 設定下注檢查點，允許接下來發牌
            checkpoint = true;
            //txtMoney.Text = playerMoney.ToString();
            btnDealCard.Enabled = true;
        }

        private void txtBetMoney_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBetMoney.Text))
            {
                betMoney = 0;
                return;
            }
            int value;
            if (!int.TryParse(txtBetMoney.Text, out value))
            {
                MessageBox.Show("請輸入數字", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBetMoney.Clear();
                txtBetMoney.Focus();
                betMoney = 0;
                return;
            }

            betMoney = value;
        }
    }
    
}
