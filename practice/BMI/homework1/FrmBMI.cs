using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework1
{
    public partial class FrmBMI : Form
    {
        private readonly string placeholderHeight = "例：165";
        private readonly string placeholderWeight = "例：55";
        public FrmBMI()
        {
            InitializeComponent();
            FrmBMI_LoadKeyboardHandlers();

            // create picture box for displaying reference image (initialized here because
            // designer declares the field but did not create the control)
            this.picUser = new PictureBox();
            this.picUser.Location = new Point(0, 31);
            this.picUser.Size = new Size(this.ClientSize.Width, 194);
            this.picUser.SizeMode = PictureBoxSizeMode.StretchImage;
            this.picUser.Visible = false; // start hidden
            this.picUser.BackColor = Color.White;
            this.Controls.Add(this.picUser);
        }

        // allow keyboard-only switching between height and weight fields
        // Enter or Down in height -> move to weight
        // Enter or Up in weight   -> move to height
        private void FrmBMI_LoadKeyboardHandlers()
        {
            this.KeyPreview = true;
            this.txtHeight.KeyDown += TxtHeight_KeyDown;
            this.txtWeight.KeyDown += TxtWeight_KeyDown;
            this.txtHeight.Enter += TxtHeight_Enter;
            this.txtHeight.Leave += TxtHeight_Leave;
            this.txtWeight.Enter += TxtWeight_Enter;
            this.txtWeight.Leave += TxtWeight_Leave;

            // initialize placeholder text
            this.txtHeight.Text = placeholderHeight;
            this.txtHeight.ForeColor = Color.Gray;
            this.txtWeight.Text = placeholderWeight;
            this.txtWeight.ForeColor = Color.Gray;
        }

        private void TxtHeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                this.txtWeight.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void TxtWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up)
            {
                this.txtHeight.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void TxtHeight_Enter(object sender, EventArgs e)
        {
            if (this.txtHeight.Text == placeholderHeight)
            {
                this.txtHeight.Text = "";
                this.txtHeight.ForeColor = Color.Black;
            }
        }

        private void TxtHeight_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtHeight.Text))
            {
                this.txtHeight.Text = placeholderHeight;
                this.txtHeight.ForeColor = Color.Gray;
            }
        }

        private void TxtWeight_Enter(object sender, EventArgs e)
        {
            if (this.txtWeight.Text == placeholderWeight)
            {
                this.txtWeight.Text = "";
                this.txtWeight.ForeColor = Color.Black;
            }
        }

        private void TxtWeight_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtWeight.Text))
            {
                this.txtWeight.Text = placeholderWeight;
                this.txtWeight.ForeColor = Color.Gray;
            }
        }

        string[] strResultList = { "體重過輕", "健康體位", "體位過重", "輕度肥胖", "中度肥胖", "重度肥胖" };
        Color[] colorList = { Color.Blue, Color.Green, Color.Orange, Color.DarkOrange, Color.Red, Color.Purple };


        private void btnRun_Click(object sender, EventArgs e)
        {
            //double height = double.Parse(txtHeight.Text);
            //double weight = double.Parse(txtWeight.Text);

            //double bmi = weight / ( height * height );
            //lblBmiResult.Text = bmi.ToString();
            //lblBmiResult.Text = $"{bmi:F2}";
            string heightText = this.txtHeight.Text == placeholderHeight ? "" : this.txtHeight.Text;
            string weightText = this.txtWeight.Text == placeholderWeight ? "" : this.txtWeight.Text;
            if (string.IsNullOrWhiteSpace(heightText) || string.IsNullOrWhiteSpace(weightText))
            {
                MessageBox.Show("請輸入身高和體重。");
                return;
            }
            bool isHeightValid = double.TryParse(heightText, out double height);
            bool isWeightValid = double.TryParse(weightText, out double weight);

            if (isHeightValid)
            {
                if (height <= 0)
                {
                    MessageBox.Show("身高必須大於0。", "身高值錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("請輸入有效的身高數字。", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (isWeightValid)
            {
                if (weight <= 0)
                {
                    MessageBox.Show("體重必須大於0。", "體重值錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("請輸入有效的體重數字。", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (isHeightValid && isWeightValid)
            {
                height /= 100;

                double bmi = weight / (height * height);

                //lblBmiResult.Text = $"{bmi:F2}";

                string strResult = "";
                Color colorResult = Color.Black;
                int resultIndex = 0;
                if (bmi < 18.5)
                {
                    resultIndex = 0;
                }
                else if (bmi >= 18.5 && bmi < 24)
                {
                    resultIndex = 1;
                } 
                else if (bmi >= 24 && bmi < 27)
                {
                    resultIndex = 2;
                }
                else if (bmi >= 27 && bmi < 30) 
                {
                    resultIndex = 3;
                }
                else if (bmi >= 30 && bmi < 35)
                {
                    resultIndex = 4;
                }
                else
                {
                    resultIndex = 5;
                }
                strResult = strResultList[resultIndex];
                colorResult = colorList[resultIndex];

                lblBmiResult.Text = $"{bmi:F2} ({strResult})";
                lblBmiResult.BackColor = colorResult;

            }
            else
            {
                MessageBox.Show("請輸入有效的數字。", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            // show input/output groups and hide the reference image
            if (this.grpInput != null) this.grpInput.Visible = true;
            if (this.grpOutput != null) this.grpOutput.Visible = true;
            if (this.picUser != null)
            {
                this.picUser.Visible = false;
                this.picUser.Image = null;
            }
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            // hide input controls and show the BMI reference image
            if (this.grpInput != null) this.grpInput.Visible = false;
            if (this.grpOutput != null) this.grpOutput.Visible = false;
            if (this.picUser != null)
            {
                this.picUser.Image = Properties.Resources.BMI_image;
                this.picUser.Visible = true;
            }
        }
    }
}
