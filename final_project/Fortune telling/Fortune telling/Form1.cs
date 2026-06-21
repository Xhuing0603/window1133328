using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fortune_telling
{
    public partial class frmStart : Form
    {
        public frmStart()
        {
            InitializeComponent();
        }
        public static bool login = false;
        public static string currentUsername = "";
        public static int currentUserId = -1;

        /// <summary>
        /// 更新菜單項根據登入狀態
        /// </summary>
        private void UpdateLoginMenuState()
        {
            if (login)
            {
                登入ToolStripMenuItem.Text = "登出";
            }
            else
            {
                登入ToolStripMenuItem.Text = "登入";
            }
        }
        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmStart();
        }

        private void 聯絡我們ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("聯絡我們：\n\n電話：09-12345678\n地址：桃園市中壢區遠東路135號\nEmail：fortuneYZU2026@gmail.com");
        }

        private void 過去紀錄ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (login == true)
            {
                this.Hide();
                var frmHistory = new frmHistory();
                frmHistory.StartPosition = FormStartPosition.CenterScreen;
                frmHistory.ShowDialog();
                this.Show();

                UpdateLoginMenuState();
            }
            else
            {
                MessageBox.Show("請先登入才能查看占卜記錄", "提示");
            }
        }

        private void 登入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (login)
            {
                DialogResult result = MessageBox.Show($"確定要登出嗎？\n當前用戶：{currentUsername}", "登出確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    login = false;
                    currentUsername = "";
                    currentUserId = -1;
                    UpdateLoginMenuState();
                    MessageBox.Show("已登出");
                }
            }
            else
            {
                this.Hide();
                var frm = new frmLogin();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
                this.Show();

                UpdateLoginMenuState();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if( login  == true)
            {
                this.Hide();
                var frm = new frmFortune();  
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
                this.Show();

                UpdateLoginMenuState();
            }
            else
            {
                this.Hide();
                var frm = new frmLogin();    
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
                this.Show();

                UpdateLoginMenuState();
            }
        }

        private void frmStart_Load(object sender, EventArgs e)
        {
            UpdateLoginMenuState();
        }

        private void frmStart_Shown(object sender, EventArgs e)
        {
            UpdateLoginMenuState();
        }
    }
}
