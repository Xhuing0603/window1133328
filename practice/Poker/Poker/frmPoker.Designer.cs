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
            this.grpPoker = new System.Windows.Forms.GroupBox();
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
            // frmPoker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 232);
            this.Controls.Add(this.grpPoker);
            this.Name = "frmPoker";
            this.Text = "frmPoker";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPoker;
    }
}