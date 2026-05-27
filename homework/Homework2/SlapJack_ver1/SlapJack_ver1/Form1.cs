using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlapJack_ver1
{
    public partial class frmStart : Form
    {
        public frmStart()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // 開始遊戲，開啟遊戲視窗
            using (var game = new frmGame())
            {
                this.Hide();
                game.StartPosition = FormStartPosition.CenterScreen;
                game.ShowDialog();
                this.Show();
            }
        }

    }
}
