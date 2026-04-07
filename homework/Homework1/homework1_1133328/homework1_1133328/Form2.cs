using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework1_1133328
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void SetValues(decimal loanTotal, decimal monthlyPayment, decimal firstInterest, decimal firstPrincipal, decimal totalInterest, decimal totalRepayment)
        {
            labelValue1.Text = loanTotal.ToString("N2");
            labelValue2.Text = monthlyPayment.ToString("N2");
            labelValue3.Text = firstInterest.ToString("N2");
            labelValue4.Text = firstPrincipal.ToString("N2");
            labelValue5.Text = totalInterest.ToString("N2");
            labelValue6.Text = totalRepayment.ToString("N2");
        }
    }
}
