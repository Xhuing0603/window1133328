using System.Windows.Forms;

namespace SlapJack_ver1
{
    partial class frmGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblHuman = new System.Windows.Forms.Label();
            this.lblAI1 = new System.Windows.Forms.Label();
            this.lblAI2 = new System.Windows.Forms.Label();
            this.pnlTarget = new System.Windows.Forms.Panel();
            this.lblCentralPile = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.progressBarCalibration = new System.Windows.Forms.ProgressBar();
            this.btnCalibrate = new System.Windows.Forms.Button();
            this.timerAIFlip = new System.Windows.Forms.Timer(this.components);
            this.timerCalibration = new System.Windows.Forms.Timer(this.components);
            this.timerCardDisplay = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxCard = new System.Windows.Forms.PictureBox();
            this.timerAISlap1 = new System.Windows.Forms.Timer(this.components);
            this.timerAISlap2 = new System.Windows.Forms.Timer(this.components);
            this.btnFlip = new System.Windows.Forms.Button();
            this.timerClaimPause = new System.Windows.Forms.Timer(this.components);
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCard)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHuman
            // 
            this.lblHuman.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.lblHuman.Location = new System.Drawing.Point(40, 20);
            this.lblHuman.Name = "lblHuman";
            this.lblHuman.Size = new System.Drawing.Size(220, 40);
            this.lblHuman.TabIndex = 0;
            this.lblHuman.Text = "玩家 (你): 0 牌";
            // 
            // lblAI1
            // 
            this.lblAI1.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.lblAI1.Location = new System.Drawing.Point(40, 70);
            this.lblAI1.Name = "lblAI1";
            this.lblAI1.Size = new System.Drawing.Size(220, 40);
            this.lblAI1.TabIndex = 1;
            this.lblAI1.Text = "電腦A: 0 牌";
            // 
            // lblAI2
            // 
            this.lblAI2.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.lblAI2.Location = new System.Drawing.Point(40, 120);
            this.lblAI2.Name = "lblAI2";
            this.lblAI2.Size = new System.Drawing.Size(220, 40);
            this.lblAI2.TabIndex = 2;
            this.lblAI2.Text = "電腦B: 0 牌";
            // 
            // pnlTarget
            // 
            this.pnlTarget.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(144)))), ((int)(((byte)(238)))), ((int)(((byte)(144)))));
            this.pnlTarget.Location = new System.Drawing.Point(300, 80);
            this.pnlTarget.Name = "pnlTarget";
            this.pnlTarget.Size = new System.Drawing.Size(50, 30);
            this.pnlTarget.TabIndex = 8;
            this.pnlTarget.Visible = false;
            // 
            // lblCentralPile
            // 
            this.lblCentralPile.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.lblCentralPile.Location = new System.Drawing.Point(300, 20);
            this.lblCentralPile.Name = "lblCentralPile";
            this.lblCentralPile.Size = new System.Drawing.Size(440, 40);
            this.lblCentralPile.TabIndex = 4;
            this.lblCentralPile.Text = "中央棄牌堆: 0 張";
            this.lblCentralPile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlRight.Controls.Add(this.lblMessage);
            this.pnlRight.Location = new System.Drawing.Point(280, 12);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(460, 95);
            this.pnlRight.TabIndex = 7;
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.lblMessage.Location = new System.Drawing.Point(10, 10);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(460, 80);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "遊戲訊息...";
            // 
            // progressBarCalibration
            // 
            this.progressBarCalibration.Location = new System.Drawing.Point(300, 80);
            this.progressBarCalibration.Maximum = 1000;
            this.progressBarCalibration.Name = "progressBarCalibration";
            this.progressBarCalibration.Size = new System.Drawing.Size(440, 30);
            this.progressBarCalibration.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarCalibration.TabIndex = 5;
            this.progressBarCalibration.Visible = false;
            this.progressBarCalibration.MouseDown += new System.Windows.Forms.MouseEventHandler(this.progressBarCalibration_MouseDown);
            // 
            // btnCalibrate
            // 
            this.btnCalibrate.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.btnCalibrate.Location = new System.Drawing.Point(300, 130);
            this.btnCalibrate.Name = "btnCalibrate";
            this.btnCalibrate.Size = new System.Drawing.Size(200, 40);
            this.btnCalibrate.TabIndex = 6;
            this.btnCalibrate.Text = "校準 (按我停止)";
            this.btnCalibrate.UseVisualStyleBackColor = true;
            this.btnCalibrate.Visible = false;
            this.btnCalibrate.Click += new System.EventHandler(this.btnCalibrate_Click);
            // 
            // timerAIFlip
            // 
            this.timerAIFlip.Interval = 1500;
            this.timerAIFlip.Tick += new System.EventHandler(this.timerAIFlip_Tick);
            // 
            // timerCalibration
            // 
            this.timerCalibration.Interval = 30;
            this.timerCalibration.Tick += new System.EventHandler(this.timerCalibration_Tick);
            // 
            // timerCardDisplay
            // 
            this.timerCardDisplay.Interval = 800;
            this.timerCardDisplay.Tick += new System.EventHandler(this.timerCardDisplay_Tick);
            // 
            // pictureBoxCard
            // 
            this.pictureBoxCard.Location = new System.Drawing.Point(280, 80);
            this.pictureBoxCard.Name = "pictureBoxCard";
            this.pictureBoxCard.Size = new System.Drawing.Size(240, 320);
            this.pictureBoxCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCard.TabIndex = 9;
            this.pictureBoxCard.TabStop = false;
            this.pictureBoxCard.Visible = false;
            this.pictureBoxCard.Click += new System.EventHandler(this.pictureBoxCard_Click);
            // 
            // timerAISlap1
            // 
            this.timerAISlap1.Interval = 100;
            this.timerAISlap1.Tick += new System.EventHandler(this.TimerAISlap1_Tick);
            // 
            // timerAISlap2
            // 
            this.timerAISlap2.Interval = 100;
            this.timerAISlap2.Tick += new System.EventHandler(this.TimerAISlap2_Tick);
            // 
            // timerClaimPause
            // 
            this.timerClaimPause.Interval = 1500;
            this.timerClaimPause.Tick += new System.EventHandler(this.timerClaimPause_Tick);
            // 
            // btnFlip
            // 
            this.btnFlip.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.btnFlip.Location = new System.Drawing.Point(40, 180);
            this.btnFlip.Name = "btnFlip";
            this.btnFlip.Size = new System.Drawing.Size(120, 40);
            this.btnFlip.TabIndex = 10;
            this.btnFlip.Text = "翻牌";
            this.btnFlip.UseVisualStyleBackColor = true;
            this.btnFlip.Click += new System.EventHandler(this.btnFlip_Click);
            this.btnFlip.Visible = false;
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnFlip);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.btnCalibrate);
            this.Controls.Add(this.progressBarCalibration);
            this.Controls.Add(this.pnlTarget);
            this.Controls.Add(this.pictureBoxCard);
            this.Controls.Add(this.lblCentralPile);
            this.Controls.Add(this.lblAI2);
            this.Controls.Add(this.lblAI1);
            this.Controls.Add(this.lblHuman);
            this.Name = "frmGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "心臟病";
            this.Load += new System.EventHandler(this.frmGame_Load);
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCard)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblHuman;
        private System.Windows.Forms.Label lblAI1;
        private System.Windows.Forms.Label lblAI2;
        private System.Windows.Forms.Button btnFlip;
        private Panel pnlTarget;
        private System.Windows.Forms.Label lblCentralPile;
        private System.Windows.Forms.ProgressBar progressBarCalibration;
        private System.Windows.Forms.Button btnCalibrate;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Timer timerAIFlip;
        private System.Windows.Forms.Timer timerCalibration;
        private System.Windows.Forms.Timer timerCardDisplay;
        private System.Windows.Forms.PictureBox pictureBoxCard;
        private System.Windows.Forms.Timer timerAISlap1;
        private System.Windows.Forms.Timer timerAISlap2;
        private System.Windows.Forms.Timer timerClaimPause;

        #endregion
    }
}