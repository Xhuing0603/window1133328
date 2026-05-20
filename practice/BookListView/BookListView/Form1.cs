using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;

namespace BookListView
{
    public partial class frmBooks : Form
    {

        string[] b_name = { "三國演義", "西遊記","唐詩三百首","楚辭",
"西廂記","水滸傳","紅樓夢", "牡丹亭", "聊齋誌異", "史記" }; //書名
        string[] author = {"羅貫中", "吳承恩", "孫洙", "劉向",
"王實甫","施耐庵", "曹雪芹", "湯顯祖", "蒲松齡", "司馬遷" }; //作者
        string[] kind = { "章回小說", "章回小說", "詩選", "詩歌", "戲曲",
"章回小說","章回小說", "戲曲", "短篇小說", "史書" };
        public frmBooks()
        {
            InitializeComponent();
        }

        private void frmBooks_Load(object sender, EventArgs e)
        {
            cmbView.Items.Add("大圖示");
            cmbView.Items.Add("詳細資料");
            cmbView.Items.Add("小圖示");
            cmbView.Items.Add("清單");
            cmbView.Items.Add("大圖示加詳細資料");
            cmbView.SelectedIndex = 0; //預設選取第一個項目
            // 確保影像清單有足夠的圖示，若缺少則以書名產生簡單的占位圖示
            for (int i = imgL.Images.Count; i < b_name.Length; i++)
            {
                Image imgLarge = null;
                Image imgSmall = null;
                try
                {
                    string imgDir = Path.Combine(Application.StartupPath, "Images");
                    string customKey = null;
                    if (b_name[i] == "聊齋誌異") customKey = "liaozhai";
                    else if (b_name[i] == "史記") customKey = "shiji";

                    if (!string.IsNullOrEmpty(customKey))
                    {
                        string largePath = Path.Combine(imgDir, customKey + "_large.png");
                        string smallPath = Path.Combine(imgDir, customKey + "_small.png");
                        string defaultPath = Path.Combine(imgDir, customKey + ".png");

                        if (File.Exists(largePath)) imgLarge = Image.FromFile(largePath);
                        else if (File.Exists(defaultPath)) imgLarge = Image.FromFile(defaultPath);

                        if (File.Exists(smallPath)) imgSmall = Image.FromFile(smallPath);
                        else if (File.Exists(defaultPath)) imgSmall = Image.FromFile(defaultPath);

                        if (imgLarge != null)
                        {
                            imgLarge = new Bitmap(imgLarge, new Size(64, 64));
                        }
                        if (imgSmall != null)
                        {
                            imgSmall = new Bitmap(imgSmall, new Size(32, 32));
                        }
                    }
                }
                catch { }

                if (imgLarge == null || imgSmall == null)
                {
                    Bitmap bmpL = new Bitmap(64, 64);
                    using (Graphics gL = Graphics.FromImage(bmpL))
                    {
                        gL.Clear(System.Drawing.Color.Beige);
                        gL.DrawRectangle(Pens.Brown, 0, 0, 63, 63);
                        string textL = b_name[i];
                        if (textL.Length > 4) textL = textL.Substring(0, 4);
                        using (Font f = new Font("標楷體", 12F, FontStyle.Bold, GraphicsUnit.Point))
                        {
                            StringFormat sf = new StringFormat();
                            sf.Alignment = StringAlignment.Center;
                            sf.LineAlignment = StringAlignment.Center;
                            gL.DrawString(textL, f, Brushes.DarkBlue, new RectangleF(0, 0, 64, 64), sf);
                        }
                    }
                    Bitmap bmpS = new Bitmap(32, 32);
                    using (Graphics gS = Graphics.FromImage(bmpS))
                    {
                        gS.Clear(System.Drawing.Color.Beige);
                        gS.DrawRectangle(Pens.Brown, 0, 0, 31, 31);
                        string textS = b_name[i];
                        if (textS.Length > 2) textS = textS.Substring(0, 2);
                        using (Font fs = new Font("標楷體", 8F, FontStyle.Bold, GraphicsUnit.Point))
                        {
                            StringFormat sf2 = new StringFormat();
                            sf2.Alignment = StringAlignment.Center;
                            sf2.LineAlignment = StringAlignment.Center;
                            gS.DrawString(textS, fs, Brushes.DarkBlue, new RectangleF(0, 0, 32, 32), sf2);
                        }
                    }
                    if (imgLarge == null) imgLarge = bmpL;
                    else bmpL.Dispose();
                    if (imgSmall == null) imgSmall = bmpS;
                    else bmpS.Dispose();
                }

                imgL.Images.Add(imgLarge);
                imgS.Images.Add(imgSmall);
                imgLarge.Dispose();
                imgSmall.Dispose();
            }
            lvwBooks.Columns.Add("書名", 100); //新增 書名 欄位，寬度為100
            lvwBooks.Columns.Add("作者", 60); //新增 作者 欄位，寬度為60
            lvwBooks.Columns.Add("類別", 60); //新增 類別 欄位
            lvwBooks.BeginUpdate(); //暫停重繪
            for (int i = 0; i < b_name.Length; i++)
            { //宣告一個ListViewItem物件
                ListViewItem lvi = new ListViewItem(b_name[i]);
                lvi.SubItems.Add(author[i].ToString()); //新增 作者 欄位資料
                lvi.SubItems.Add(kind[i]); //新增 類別 欄位資料
                lvwBooks.Items.Add(lvi); //新增項目
                // 指定影像的索引值（僅在影像存在時設定，避免超出範圍）
                if (i < imgL.Images.Count)
                    lvwBooks.Items[i].ImageIndex = i;
                else
                    lvwBooks.Items[i].ImageIndex = 0;
            }
            lvwBooks.EndUpdate(); //重繪;
        }

        private void cmbView_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbView.SelectedIndex)
            {
                case 0: //大圖示
                    lvwBooks.View = View.LargeIcon;
                    break;
                case 1: //詳細資料
                    lvwBooks.View = View.Details;
                    break;
                case 2: //小圖示
                    lvwBooks.View = View.SmallIcon;
                    break;
                case 3: //清單
                    lvwBooks.View = View.List;
                    break;
                case 4: //大圖示加詳細資料
                    lvwBooks.View = View.Tile;
                    break;
            }
        }

        private void lvwBooks_ItemActivate(object sender, EventArgs e)
        {
            //取得書名
            string strBookname = b_name[lvwBooks.SelectedIndices[0]];
            bool exist = lstBorrow.Items.Contains(strBookname);
            if (exist != true) // 若選取的書名不存在借書清單中
            {
                DialogResult dr = MessageBox.Show("確定要借閱嗎?",
                strBookname, MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes) // 若按 <是> 鈕
                { // 新增項目到借書清單
                    lstBorrow.Items.Add(strBookname);
                }
            }
        }
        private void timerMarquee_Tick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblMarquee.Text)) return;
            // simple marquee: move first character to the end
            lblMarquee.Text = lblMarquee.Text.Substring(1) + lblMarquee.Text[0];
        }
    }
}
