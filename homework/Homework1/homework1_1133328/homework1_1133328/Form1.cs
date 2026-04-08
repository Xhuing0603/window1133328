using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace homework1_1133328
{
    public partial class Form1 : Form
    {
        private Label messageLabel;

        public Form1()
        {
            InitializeComponent();
            try { comboBox1.SelectedIndex = 1; } catch { }
           
            messageLabel = new Label();
            messageLabel.AutoSize = false;
            messageLabel.Location = new System.Drawing.Point(0, 27);
            messageLabel.Size = new System.Drawing.Size(396, 306);
            messageLabel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            messageLabel.Text = "本App是2026年製作，可能隨著政策變動，需要及時訊息請上內政部官網查看";
            messageLabel.Visible = false;
            this.Controls.Add(messageLabel);

            this.計算器ToolStripMenuItem.Click += 計算器ToolStripMenuItem_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // If any input is empty, use the requested default values
                if (string.IsNullOrWhiteSpace(textBox1.Text)) textBox1.Text = "10000000";
                if (string.IsNullOrWhiteSpace(textBox2.Text)) textBox2.Text = "0";
                if (string.IsNullOrWhiteSpace(textBox3.Text)) textBox3.Text = "1.5";
                if (string.IsNullOrWhiteSpace(textBox4.Text)) textBox4.Text = "20";
                if (string.IsNullOrWhiteSpace(textBox5.Text)) textBox5.Text = "0";

                double totalHousePrice = double.Parse(textBox1.Text);
                double downPayment = double.Parse(textBox2.Text);

                
                if (comboBox1.SelectedIndex == 1) 
                {
                    downPayment = totalHousePrice * (downPayment / 100.0);
                }

                double loanAmount = totalHousePrice - downPayment;
                double annualRate = double.Parse(textBox3.Text) / 100.0; 
                int years = int.Parse(textBox4.Text);
                int gracePeriodMonths = int.Parse(textBox5.Text) * 12; 

                double monthlyRate = annualRate / 12.0;
                int totalMonths = years * 12;
                int repaymentMonths = totalMonths - gracePeriodMonths; 

                double temp = Math.Pow(1 + monthlyRate, repaymentMonths);
                double monthlyAmortizationRate = (temp * monthlyRate) / (temp - 1);

                double monthlyPayment = loanAmount * monthlyAmortizationRate; 
                double firstInterest = loanAmount * monthlyRate;

                double firstPrincipal = (gracePeriodMonths > 0) ? 0 : (monthlyPayment - firstInterest);

                double totalInterest = 0;
                double currentBalance = loanAmount;

                for (int i = 1; i <= totalMonths; i++)
                {
                    double interestThisMonth = currentBalance * monthlyRate;
                    totalInterest += interestThisMonth;

                    if (i > gracePeriodMonths)
                    {
                        double principalThisMonth = monthlyPayment - interestThisMonth;
                        currentBalance -= principalThisMonth;
                    }
                }

                double totalRepayment = loanAmount + totalInterest;

                Form2 resultForm = new Form2();
                resultForm.SetValues(
                    (decimal)loanAmount,
                    (decimal)monthlyPayment,
                    (decimal)firstInterest,
                    (decimal)firstPrincipal,
                    (decimal)totalInterest,
                    (decimal)totalRepayment
                );
                resultForm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("請輸入正確的數值格式"); 
            }
        }

        private void 計算器ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                groupBox1.Visible = false;
                label7.Visible = false;
                if (messageLabel != null) messageLabel.Visible = true;
            }
            catch { }
        }

        private void 計算器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                groupBox1.Visible = true;
                label7.Visible = true;
                if (messageLabel != null) messageLabel.Visible = false;
            }
            catch { }
        }
    }
}
