﻿using System;
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
                int totalMonths = years * 12;
                double monthlyInterestRate = (interestRate / 12) / 100; // get the monthly interest rate, expressed as a decimal
                double accountValue = 0;

                for (int month = 0; month < totalMonths; month++)
                {
                    accountValue += monthlyInvestment;
                    double interestEarned = accountValue * monthlyInterestRate; // the interest earned on the principal this month
                    accountValue += interestEarned; 
                }

                txtFutureValue.Text = accountValue.ToString("c");
            }
            else
            {
                MessageBox.Show("Invalid input.", "Error");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
