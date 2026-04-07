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
        public Form1()
        {
            InitializeComponent();
            try { comboBox1.SelectedIndex = 1; } catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
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
    }
}
