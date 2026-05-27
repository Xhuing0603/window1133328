using System;
using System.Drawing;
using System.Windows.Forms;

namespace SlapJack_ver1
{
    public class frmSummary : Form
    {
        private Label lblSummary;
        private Button btnContinue;

        public frmSummary(string message)
        {
            InitializeComponent();
            lblSummary.Text = message;
        }

        private void InitializeComponent()
        {
            this.lblSummary = new Label();
            this.btnContinue = new Button();

            this.SuspendLayout();
            // 
            // lblSummary (結算文字) - 放大加粗，深碳黑質感
            // 
            this.lblSummary.Font = new System.Drawing.Font("微軟正黑體", 13F, System.Drawing.FontStyle.Bold);
            this.lblSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41))))); // 深碳黑
            this.lblSummary.Location = new System.Drawing.Point(12, 20);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(360, 100);
            this.lblSummary.TabIndex = 0;
            this.lblSummary.Text = "結果...";
            this.lblSummary.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnContinue (繼續按鈕) - 扁平化森林綠按鈕
            // 
            this.btnContinue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(157)))), ((int)(((byte)(143))))); // 森林綠
            this.btnContinue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinue.Font = new System.Drawing.Font("微軟正黑體", 11F, System.Drawing.FontStyle.Bold);
            this.btnContinue.ForeColor = System.Drawing.Color.White; // 白色字體
            this.btnContinue.Location = new System.Drawing.Point(120, 140);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(140, 40);
            this.btnContinue.TabIndex = 1;
            this.btnContinue.Text = "繼 續";
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += BtnContinue_Click;
            // 
            // frmSummary (結算主視窗) - 質感雪白背景
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250))))); // 質感雪白
            this.ClientSize = new System.Drawing.Size(384, 211);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.btnContinue);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "遊戲結算";
            this.ResumeLayout(false);
        }

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            // signal the caller that user chose to continue and close the summary
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}