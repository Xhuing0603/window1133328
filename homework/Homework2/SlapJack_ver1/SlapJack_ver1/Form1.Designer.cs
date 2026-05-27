namespace SlapJack_ver1
{
    partial class frmStart
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblRules;

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblRules = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle (主標題) - 時尚藏青藍，放大加粗
            // 
            this.lblTitle.Font = new System.Drawing.Font("微軟正黑體", 26F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(53)))), ((int)(((byte)(87))))); // 高級藏青
            this.lblTitle.Location = new System.Drawing.Point(12, 35);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(776, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "心臟病  Slap Jack";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStart (開始按鈕) - 無印風質感森林綠
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(157)))), ((int)(((byte)(143))))); // 森林綠
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.Color.White; // 白色文字
            this.btnStart.Location = new System.Drawing.Point(300, 125);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(200, 50);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "開 始 遊 戲";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblRules (遊戲規則區塊) - 輕盈淡灰圓潤質感
            // 
            this.lblRules.Font = new System.Drawing.Font("微軟正黑體", 10.5F, System.Drawing.FontStyle.Regular);
            this.lblRules.Location = new System.Drawing.Point(200, 205);
            this.lblRules.Name = "lblRules";
            this.lblRules.Size = new System.Drawing.Size(400, 180);
            this.lblRules.TabIndex = 2;
            this.lblRules.Padding = new System.Windows.Forms.Padding(15);
            this.lblRules.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(245))))); // 極淡暖灰背景
            this.lblRules.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74))))); // 優雅深灰字
            this.lblRules.Text = "遊戲規則:\r\n\r\n1) 使用一副去掉鬼牌的標準撲克牌。\r\n2) 玩家依序翻牌，翻出的牌放到中央棄牌堆。\r\n3) 當紅心出現時，最先拍到中央者獲得整個棄牌堆。\r\n4) 若玩家無牌則被淘汰，最後擁有所有牌的玩家獲勝。";
            this.lblRules.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // frmStart (主表單) - 質感雪白背景
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250))))); // 與主遊戲視窗一致的雪白底色
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblRules);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle; // 固定視窗大小更美觀
            this.MaximizeBox = false; // 隱藏最大化按鈕保持排版
            this.Name = "frmStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "心臟病 SlapJack";
            this.ResumeLayout(false);

        }

        #endregion
    }
}

