namespace Poker
{
    partial class frmPoker
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
            this.grpPoker = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnChangeCard = new System.Windows.Forms.Button();
            this.btnDealCard = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.grpBet = new System.Windows.Forms.GroupBox();
            this.txtBetMoney = new System.Windows.Forms.TextBox();
            this.lbl3 = new System.Windows.Forms.Label();
            this.btnBet = new System.Windows.Forms.Button();
            this.lbl2 = new System.Windows.Forms.Label();
            this.txtMoney = new System.Windows.Forms.Label();
            this.pnlSpecial = new System.Windows.Forms.Panel();
            this.lblSpecial = new System.Windows.Forms.Label();
            this.timerSpecial = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.grpBet.SuspendLayout();
            this.pnlSpecial.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpPoker
            // 
            this.grpPoker.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.grpPoker.Location = new System.Drawing.Point(29, 27);
            this.grpPoker.Name = "grpPoker";
            this.grpPoker.Size = new System.Drawing.Size(485, 160);
            this.grpPoker.TabIndex = 0;
            this.grpPoker.TabStop = false;
            this.grpPoker.Text = "牌桌";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCheck);
            this.groupBox1.Controls.Add(this.btnChangeCard);
            this.groupBox1.Controls.Add(this.btnDealCard);
            this.groupBox1.Controls.Add(this.lblResult);
            this.groupBox1.Location = new System.Drawing.Point(29, 193);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 60);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "功能";
            // 
            // btnCheck
            // 
            this.btnCheck.Enabled = false;
            this.btnCheck.Location = new System.Drawing.Point(194, 18);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 28);
            this.btnCheck.TabIndex = 3;
            this.btnCheck.Text = "判斷牌型";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnChangeCard
            // 
            this.btnChangeCard.Enabled = false;
            this.btnChangeCard.Location = new System.Drawing.Point(113, 18);
            this.btnChangeCard.Name = "btnChangeCard";
            this.btnChangeCard.Size = new System.Drawing.Size(75, 28);
            this.btnChangeCard.TabIndex = 2;
            this.btnChangeCard.Text = "換牌";
            this.btnChangeCard.UseVisualStyleBackColor = true;
            this.btnChangeCard.Click += new System.EventHandler(this.btnChangeCard_Click);
            // 
            // btnDealCard
            // 
            this.btnDealCard.Location = new System.Drawing.Point(32, 18);
            this.btnDealCard.Name = "btnDealCard";
            this.btnDealCard.Size = new System.Drawing.Size(75, 28);
            this.btnDealCard.TabIndex = 1;
            this.btnDealCard.Text = "發牌";
            this.btnDealCard.UseVisualStyleBackColor = true;
            this.btnDealCard.Click += new System.EventHandler(this.btnDealCard_Click);
            // 
            // lblResult
            // 
            this.lblResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblResult.Location = new System.Drawing.Point(297, 18);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(164, 28);
            this.lblResult.TabIndex = 0;
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpBet
            // 
            this.grpBet.Controls.Add(this.txtBetMoney);
            this.grpBet.Controls.Add(this.lbl3);
            this.grpBet.Controls.Add(this.btnBet);
            this.grpBet.Controls.Add(this.lbl2);
            this.grpBet.Controls.Add(this.txtMoney);
            this.grpBet.Location = new System.Drawing.Point(29, 259);
            this.grpBet.Name = "grpBet";
            this.grpBet.Size = new System.Drawing.Size(485, 55);
            this.grpBet.TabIndex = 4;
            this.grpBet.TabStop = false;
            this.grpBet.Text = "下注區";
            // 
            // txtBetMoney
            // 
            this.txtBetMoney.Location = new System.Drawing.Point(267, 21);
            this.txtBetMoney.Name = "txtBetMoney";
            this.txtBetMoney.Size = new System.Drawing.Size(131, 22);
            this.txtBetMoney.TabIndex = 5;
            this.txtBetMoney.TextChanged += new System.EventHandler(this.txtBetMoney_TextChanged);
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(208, 26);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(53, 12);
            this.lbl3.TabIndex = 4;
            this.lbl3.Text = "押注金額";
            // 
            // btnBet
            // 
            this.btnBet.Location = new System.Drawing.Point(404, 20);
            this.btnBet.Name = "btnBet";
            this.btnBet.Size = new System.Drawing.Size(75, 23);
            this.btnBet.TabIndex = 3;
            this.btnBet.Text = "下注";
            this.btnBet.UseVisualStyleBackColor = true;
            this.btnBet.Click += new System.EventHandler(this.btnBet_Click);
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(18, 26);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(41, 12);
            this.lbl2.TabIndex = 2;
            this.lbl2.Text = "總資金";
            // 
            // txtMoney
            // 
            this.txtMoney.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtMoney.Location = new System.Drawing.Point(65, 18);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(137, 28);
            this.txtMoney.TabIndex = 1;
            this.txtMoney.Text = "1000000";
            this.txtMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSpecial
            // 
            this.pnlSpecial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSpecial.Controls.Add(this.lblSpecial);
            this.pnlSpecial.Location = new System.Drawing.Point(29, 323);
            this.pnlSpecial.Name = "pnlSpecial";
            this.pnlSpecial.Size = new System.Drawing.Size(485, 28);
            this.pnlSpecial.TabIndex = 5;
            // 
            // lblSpecial
            // 
            this.lblSpecial.AutoSize = true;
            this.lblSpecial.Location = new System.Drawing.Point(485, 5);
            this.lblSpecial.Name = "lblSpecial";
            this.lblSpecial.Size = new System.Drawing.Size(185, 12);
            this.lblSpecial.TabIndex = 0;
            this.lblSpecial.Text = "歡迎來到撲克遊戲！請下注開始。";
            // 
            // timerSpecial
            // 
            this.timerSpecial.Interval = 30;
            this.timerSpecial.Tick += new System.EventHandler(this.timerSpecial_Tick);
            // 
            // frmPoker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 372);
            this.Controls.Add(this.grpBet);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpPoker);
            this.Controls.Add(this.pnlSpecial);
            this.Name = "frmPoker";
            this.Text = "  Poker";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmPoker_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.grpBet.ResumeLayout(false);
            this.grpBet.PerformLayout();
            this.pnlSpecial.ResumeLayout(false);
            this.pnlSpecial.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPoker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnChangeCard;
        private System.Windows.Forms.Button btnDealCard;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.GroupBox grpBet;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label txtMoney;
        private System.Windows.Forms.TextBox txtBetMoney;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Button btnBet;
        private System.Windows.Forms.Panel pnlSpecial;
        private System.Windows.Forms.Label lblSpecial;
        private System.Windows.Forms.Timer timerSpecial;
    }
}