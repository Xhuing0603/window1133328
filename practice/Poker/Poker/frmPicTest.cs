using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Poker
{
    public partial class frmPicTest : Form
    {
        public frmPicTest()
        {
            InitializeComponent();
        }

        private Bitmap GetImage(string name)
        {
            return Properties.Resources.ResourceManager.
            GetObject(name) as Bitmap;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int picNum = random.Next(1, 53);

            picTest.Image = GetImage($"pic{picNum}");

            //picTest.Image = Properties.Resources.ResourceManager.GetObject($"pic{picNum}") as Bitmap;//2026版本匯入變成bitmap
            lblNum.Text = picNum.ToString();
        } 
    
    }
}
