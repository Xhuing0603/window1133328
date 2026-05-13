namespace BookListView
{
    partial class frmBooks
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBooks));
            this.pnlTools = new System.Windows.Forms.Panel();
            this.grpBorrow = new System.Windows.Forms.GroupBox();
            this.lstBorrow = new System.Windows.Forms.ListBox();
            this.grpView = new System.Windows.Forms.GroupBox();
            this.cmbView = new System.Windows.Forms.ComboBox();
            this.lvwBooks = new System.Windows.Forms.ListView();
            this.imgL = new System.Windows.Forms.ImageList(this.components);
            this.imgS = new System.Windows.Forms.ImageList(this.components);
            this.pnlBooks = new System.Windows.Forms.Panel();
            this.pnlTools.SuspendLayout();
            this.grpBorrow.SuspendLayout();
            this.grpView.SuspendLayout();
            this.pnlBooks.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTools
            // 
            this.pnlTools.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlTools.Controls.Add(this.grpBorrow);
            this.pnlTools.Controls.Add(this.grpView);
            this.pnlTools.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlTools.Location = new System.Drawing.Point(536, 0);
            this.pnlTools.Name = "pnlTools";
            this.pnlTools.Size = new System.Drawing.Size(264, 450);
            this.pnlTools.TabIndex = 0;
            // 
            // grpBorrow
            // 
            this.grpBorrow.Controls.Add(this.lstBorrow);
            this.grpBorrow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBorrow.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.grpBorrow.Location = new System.Drawing.Point(0, 61);
            this.grpBorrow.Name = "grpBorrow";
            this.grpBorrow.Size = new System.Drawing.Size(264, 389);
            this.grpBorrow.TabIndex = 1;
            this.grpBorrow.TabStop = false;
            this.grpBorrow.Text = "借書清單：";
            // 
            // lstBorrow
            // 
            this.lstBorrow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBorrow.FormattingEnabled = true;
            this.lstBorrow.ItemHeight = 16;
            this.lstBorrow.Location = new System.Drawing.Point(3, 23);
            this.lstBorrow.Name = "lstBorrow";
            this.lstBorrow.Size = new System.Drawing.Size(258, 363);
            this.lstBorrow.TabIndex = 0;
            // 
            // grpView
            // 
            this.grpView.Controls.Add(this.cmbView);
            this.grpView.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpView.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.grpView.Location = new System.Drawing.Point(0, 0);
            this.grpView.Name = "grpView";
            this.grpView.Size = new System.Drawing.Size(264, 61);
            this.grpView.TabIndex = 0;
            this.grpView.TabStop = false;
            this.grpView.Text = "檢視方式：";
            // 
            // cmbView
            // 
            this.cmbView.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbView.FormattingEnabled = true;
            this.cmbView.Location = new System.Drawing.Point(6, 26);
            this.cmbView.Name = "cmbView";
            this.cmbView.Size = new System.Drawing.Size(246, 24);
            this.cmbView.TabIndex = 0;
            this.cmbView.SelectedIndexChanged += new System.EventHandler(this.cmbView_SelectedIndexChanged);
            // 
            // lvwBooks
            // 
            this.lvwBooks.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.lvwBooks.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lvwBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwBooks.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lvwBooks.ForeColor = System.Drawing.Color.Black;
            this.lvwBooks.HideSelection = false;
            this.lvwBooks.LargeImageList = this.imgL;
            this.lvwBooks.Location = new System.Drawing.Point(0, 0);
            this.lvwBooks.Name = "lvwBooks";
            this.lvwBooks.Size = new System.Drawing.Size(535, 450);
            this.lvwBooks.SmallImageList = this.imgS;
            this.lvwBooks.TabIndex = 1;
            this.lvwBooks.UseCompatibleStateImageBehavior = false;
            this.lvwBooks.ItemActivate += new System.EventHandler(this.lvwBooks_ItemActivate);
            // 
            // imgL
            // 
            this.imgL.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgL.ImageStream")));
            this.imgL.TransparentColor = System.Drawing.Color.Transparent;
            this.imgL.Images.SetKeyName(0, "Book5.bmp");
            this.imgL.Images.SetKeyName(1, "Book6.bmp");
            this.imgL.Images.SetKeyName(2, "Book7.bmp");
            this.imgL.Images.SetKeyName(3, "Book8.bmp");
            this.imgL.Images.SetKeyName(4, "Book3.bmp");
            this.imgL.Images.SetKeyName(5, "Book4.bmp");
            this.imgL.Images.SetKeyName(6, "Book1.bmp");
            this.imgL.Images.SetKeyName(7, "Book2.bmp");
            // 
            // imgS
            // 
            this.imgS.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgS.ImageStream")));
            this.imgS.TransparentColor = System.Drawing.Color.Transparent;
            this.imgS.Images.SetKeyName(0, "Book5.bmp");
            this.imgS.Images.SetKeyName(1, "Book6.bmp");
            this.imgS.Images.SetKeyName(2, "Book7.bmp");
            this.imgS.Images.SetKeyName(3, "Book8.bmp");
            this.imgS.Images.SetKeyName(4, "Book3.bmp");
            this.imgS.Images.SetKeyName(5, "Book4.bmp");
            this.imgS.Images.SetKeyName(6, "Book1.bmp");
            this.imgS.Images.SetKeyName(7, "Book2.bmp");
            // 
            // pnlBooks
            // 
            this.pnlBooks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(9)))));
            this.pnlBooks.Controls.Add(this.lvwBooks);
            this.pnlBooks.Location = new System.Drawing.Point(2, 0);
            this.pnlBooks.Name = "pnlBooks";
            this.pnlBooks.Size = new System.Drawing.Size(535, 450);
            this.pnlBooks.TabIndex = 2;
            // 
            // frmBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlBooks);
            this.Controls.Add(this.pnlTools);
            this.Font = new System.Drawing.Font("標楷體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Name = "frmBooks";
            this.Text = "圖書管理程式";
            this.Load += new System.EventHandler(this.frmBooks_Load);
            this.pnlTools.ResumeLayout(false);
            this.grpBorrow.ResumeLayout(false);
            this.grpView.ResumeLayout(false);
            this.pnlBooks.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTools;
        private System.Windows.Forms.GroupBox grpView;
        private System.Windows.Forms.ListView lvwBooks;
        private System.Windows.Forms.GroupBox grpBorrow;
        private System.Windows.Forms.ListBox lstBorrow;
        private System.Windows.Forms.ImageList imgL;
        private System.Windows.Forms.ImageList imgS;
        private System.Windows.Forms.ComboBox cmbView;
        private System.Windows.Forms.Panel pnlBooks;
    }
}

