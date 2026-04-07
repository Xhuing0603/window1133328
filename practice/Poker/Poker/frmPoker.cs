using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker
{
    public partial class frmPoker : Form
    {
        PictureBox[] pic = new PictureBox[5];
        public frmPoker()
        {
            InitializeComponent();
            InitializePoker();
        }

        private Bitmap GetPic(string name)
        {
            return Properties.Resources.ResourceManager.
            GetObject(name) as Bitmap;
        }

        private void pic_Click(object sender, MouseEventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            MessageBox.Show("你選擇了" + pic.Name);
        }

        private void InitializePoker()
        {
            // 動態產生5張牌
            for (int i = 0; i < 5; i++)
            {
                pic[i] = new PictureBox();
                pic[i].Image = GetPic("back");
                pic[i].Name = "pic" + i;
                pic[i].SizeMode = PictureBoxSizeMode.AutoSize;
                pic[i].Top = 30;
                pic[i].Left = 10 + ((pic[i].Width + 10) * i);
                pic[i].Visible = true;
                // 將pic 丟至到grpPorker內
                this.grpPoker.Controls.Add(pic[i]);
                pic[i].MouseClick += new MouseEventHandler(pic_Click);
            }
        }
    }
}
