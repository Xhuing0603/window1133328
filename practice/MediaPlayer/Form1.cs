using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaPlayer
{
    public partial class frmMediaPlayer : Form
    {
        public frmMediaPlayer()
        {
            InitializeComponent();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "WMV files (*.wmv)|*.wmv|MP4 files(*.mp4)|*.mp4|AVI files(*.avi)|*.avi|Allfiles (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                wmpVideo.URL = ofd.FileName;
                wmpVideo.Ctlcontrols.stop(); // 停止
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            wmpVideo.Ctlcontrols.play();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            wmpVideo.Ctlcontrols.pause();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            wmpVideo.Ctlcontrols.stop();
        }
    }
}
