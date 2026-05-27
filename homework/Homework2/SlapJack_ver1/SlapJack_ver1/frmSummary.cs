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
            // lblSummary
            // 
            this.lblSummary.Font = new System.Drawing.Font("Microsoft JhengHei", 12F);
            this.lblSummary.Location = new System.Drawing.Point(12, 12);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(360, 120);
            this.lblSummary.TabIndex = 0;
            this.lblSummary.Text = "結果...";
            this.lblSummary.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnContinue
            // 
            this.btnContinue.Font = new System.Drawing.Font("Microsoft JhengHei", 12F);
            this.btnContinue.Location = new System.Drawing.Point(120, 150);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(140, 40);
            this.btnContinue.TabIndex = 1;
            this.btnContinue.Text = "繼續";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += BtnContinue_Click;
            // 
            // frmSummary
            // 
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
