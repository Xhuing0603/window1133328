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
        public FrmBMI()
        {
            InitializeComponent();
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
            if (this.txtHeight.Text == "" || this.txtWeight.Text == "") { 
                MessageBox.Show("請輸入身高和體重。")  ;
                return;
            }
            bool isHeightValid = double.TryParse(txtHeight.Text, out double height);
            bool isWeightValid = double.TryParse(txtWeight.Text, out double weight);

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
    }
}
