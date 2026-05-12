namespace TSVFile
{
    partial class Form1
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
        private void InitializeComponent()
        {
            this.mnsWord = new System.Windows.Forms.MenuStrip();
            this.ssrWord = new System.Windows.Forms.StatusStrip();
            this.tsmFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsslMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.lvwWord = new System.Windows.Forms.ListView();
            this.chWord = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSoundPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPhonogram = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chExplain = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tsmOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmhelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsWord.SuspendLayout();
            this.ssrWord.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsWord
            // 
            this.mnsWord.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFile,
            this.tsmhelp});
            this.mnsWord.Location = new System.Drawing.Point(0, 0);
            this.mnsWord.Name = "mnsWord";
            this.mnsWord.Size = new System.Drawing.Size(800, 24);
            this.mnsWord.TabIndex = 0;
            this.mnsWord.Text = "menuStrip1";
            // 
            // ssrWord
            // 
            this.ssrWord.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslMessage});
            this.ssrWord.Location = new System.Drawing.Point(0, 428);
            this.ssrWord.Name = "ssrWord";
            this.ssrWord.Size = new System.Drawing.Size(800, 22);
            this.ssrWord.TabIndex = 1;
            this.ssrWord.Text = "statusStrip1";
            // 
            // tsmFile
            // 
            this.tsmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmOpen,
            this.toolStripSeparator1,
            this.tsmExit});
            this.tsmFile.Name = "tsmFile";
            this.tsmFile.Size = new System.Drawing.Size(57, 20);
            this.tsmFile.Text = "檔案(&F)";
            // 
            // tsslMessage
            // 
            this.tsslMessage.Name = "tsslMessage";
            this.tsslMessage.Size = new System.Drawing.Size(58, 17);
            this.tsslMessage.Text = "Message";
            // 
            // lvwWord
            // 
            this.lvwWord.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chWord,
            this.chPhonogram,
            this.chSoundPath,
            this.chExplain});
            this.lvwWord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwWord.FullRowSelect = true;
            this.lvwWord.HideSelection = false;
            this.lvwWord.Location = new System.Drawing.Point(0, 24);
            this.lvwWord.Name = "lvwWord";
            this.lvwWord.Size = new System.Drawing.Size(800, 404);
            this.lvwWord.TabIndex = 2;
            this.lvwWord.UseCompatibleStateImageBehavior = false;
            this.lvwWord.View = System.Windows.Forms.View.Details;
            // 
            // chWord
            // 
            this.chWord.Text = "單字";
            // 
            // chSoundPath
            // 
            this.chSoundPath.Text = "音檔路徑";
            // 
            // chPhonogram
            // 
            this.chPhonogram.Text = "音檔";
            // 
            // chExplain
            // 
            this.chExplain.Text = "解釋";
            // 
            // tsmOpen
            // 
            this.tsmOpen.Name = "tsmOpen";
            this.tsmOpen.Size = new System.Drawing.Size(180, 22);
            this.tsmOpen.Text = "開啟(&O)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(180, 22);
            this.tsmExit.Text = "離開(&X)";
            // 
            // tsmhelp
            // 
            this.tsmhelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAbout});
            this.tsmhelp.Name = "tsmhelp";
            this.tsmhelp.Size = new System.Drawing.Size(60, 20);
            this.tsmhelp.Text = "幫助(&H)";
            // 
            // tsmAbout
            // 
            this.tsmAbout.Name = "tsmAbout";
            this.tsmAbout.Size = new System.Drawing.Size(180, 22);
            this.tsmAbout.Text = "關於(&A)";
            this.tsmAbout.Click += new System.EventHandler(this.tsmAbout_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvwWord);
            this.Controls.Add(this.ssrWord);
            this.Controls.Add(this.mnsWord);
            this.MainMenuStrip = this.mnsWord;
            this.Name = "Form1";
            this.Text = "Form1";
            this.mnsWord.ResumeLayout(false);
            this.mnsWord.PerformLayout();
            this.ssrWord.ResumeLayout(false);
            this.ssrWord.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsWord;
        private System.Windows.Forms.ToolStripMenuItem tsmFile;
        private System.Windows.Forms.StatusStrip ssrWord;
        private System.Windows.Forms.ToolStripStatusLabel tsslMessage;
        private System.Windows.Forms.ListView lvwWord;
        private System.Windows.Forms.ColumnHeader chWord;
        private System.Windows.Forms.ColumnHeader chSoundPath;
        private System.Windows.Forms.ColumnHeader chPhonogram;
        private System.Windows.Forms.ColumnHeader chExplain;
        private System.Windows.Forms.ToolStripMenuItem tsmOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
        private System.Windows.Forms.ToolStripMenuItem tsmhelp;
        private System.Windows.Forms.ToolStripMenuItem tsmAbout;
    }
}

