using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FutureValue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            if (Double.TryParse(txtInvestment.Text, out double monthlyInvestment) &&
                Double.TryParse(txtRate.Text, out double interestRate) &&
                Int32.TryParse(txtYears.Text, out int years))
            {
                CalculateFutureValue(monthlyInvestment, interestRate, years, out double accountValue);

                txtFutureValue.Text = accountValue.ToString("c"); // display account balance after the specified number of years
            }
            else
            {
                MessageBox.Show("Invalid input.", "Error");
            }
        }

        private void CalculateFutureValue(double monthlyInvestment, double interestRate, int years, out double accountValue)
        {
            int totalMonths = years * 12;
            double monthlyInterestRate = (interestRate / 12) / 100; // get the monthly interest rate, expressed as a decimal
            accountValue = 0;

            for (int month = 0; month < totalMonths; month++)
            {
                accountValue += monthlyInvestment;
                double interestEarned = accountValue * monthlyInterestRate; // the interest earned on the principal this month
                accountValue += interestEarned;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearFutureValue(object sender, EventArgs e)
        {
            txtFutureValue.Text = "";
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            txtFutureValue.Text = "";
            txtInvestment.Text = "";
            txtRate.Text = "";
            txtYears.Text = "";
        }

        private void txtRate_DoubleClick(object sender, EventArgs e)
        {
            txtRate.Text = "12";
        }
    }
}
