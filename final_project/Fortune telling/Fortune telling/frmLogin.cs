using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fortune_telling.Database;

namespace Fortune_telling
{
    public partial class frmLogin : Form
    {
        private DatabaseManager dbManager;

        public frmLogin()
        {
            InitializeComponent();
            dbManager = new DatabaseManager();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("帳號和密碼不能為空！");
                return;
            }

            // 使用數據庫驗證
            if (dbManager.LoginUser(username, password))
            {
                frmStart.login = true;
                frmStart.currentUsername = username;
                frmStart.currentUserId = dbManager.GetUserId(username);

                MessageBox.Show("登入成功！");

                // 登入成功後，跳轉到占卜頁面
                this.Hide();
                var frmFortune = new frmFortune();
                frmFortune.StartPosition = FormStartPosition.CenterScreen;
                frmFortune.ShowDialog();
                this.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("帳號或密碼錯誤！");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("帳號和密碼不能為空！");
                return;
            }

            if (username.Length < 3)
            {
                MessageBox.Show("帳號長度至少3個字元！");
                return;
            }

            if (password.Length < 3)
            {
                MessageBox.Show("密碼長度至少3個字元！");
                return;
            }

            if (dbManager.UserExists(username))
            {
                MessageBox.Show("此帳號已被使用！");
                return;
            }

            if (dbManager.RegisterUser(username, password))
            {
                MessageBox.Show("註冊成功！請重新登入");
                txtUsername.Clear();
                txtPassword.Clear();
            }
            else
            {
                MessageBox.Show("註冊失敗，請稍後重試");
            }
        }
    }
}
