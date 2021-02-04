using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mortgage_Calculator
{
    public partial class _Default : Page
    {
        double mortgage_amt;
        double years;
        double paymentPerYear;
        double downpayment;
        double requiredPayment;
        double rate;
        bool recurring = false;
        double extraPay;




        protected void Page_Load(object sender, EventArgs e)
        {

            if (Double.TryParse(Session["Mortgage Amt"].ToString(), out mortgage_amt))
            {
                TextBox1.ForeColor = System.Drawing.Color.Black;
            }

            else
            {
                TextBox1.ForeColor = System.Drawing.Color.Red;
                TextBox1.Text = "Invalid Input";
            }

            if (Double.TryParse(Session["Years"].ToString(), out years)) 
            {
                TextBox2.ForeColor = System.Drawing.Color.Black;
            }

            else
            {
                TextBox2.ForeColor = System.Drawing.Color.Red;
                TextBox2.Text = "Invalid Input";
            }

            if ( Double.TryParse(Session["Payments Per year"].ToString(), out paymentPerYear))
            {
                TextBox3.ForeColor = System.Drawing.Color.Black;
            }

            else
            {
                TextBox3.ForeColor = System.Drawing.Color.Red;
                TextBox3.Text = "Invalid Input";
            }

            if (Double.TryParse(Session["DownPayment"].ToString(), out downpayment))
            {
                TextBox4.ForeColor = System.Drawing.Color.Black;
            }

            else
            {
                TextBox4.ForeColor = System.Drawing.Color.Red;
                TextBox4.Text = "Invalid Input";
            }

            if (Double.TryParse(Session["Rate"].ToString(), out rate)) 
            {
                TextBox7.ForeColor = System.Drawing.Color.Black;
            }

            else
            {
                TextBox7.ForeColor = System.Drawing.Color.Red;
                TextBox7.Text = "Invalid Input";
            }

            if (Double.TryParse(Session["Extra Payment"].ToString(), out extraPay))
            {
                TextBox6.ForeColor = System.Drawing.Color.Black;
            }

            else
            {
                TextBox6.ForeColor = System.Drawing.Color.Red;
                TextBox6.Text = "Invalid Input";
            }




        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton1.Checked)
            {
                recurring = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Create table with the required columns.
            CreateHeaderRow();

            int term = 0;
            int cells = 6;
            double interestAmt = 0;
            double principalAmt = 0;
            while (mortgage_amt > 0)
            {
                CreateValueRow(cells, term, requiredPayment, extraPay, interestAmt, principalAmt, mortgage_amt);
                interestAmt = rate / (100 * paymentPerYear) * mortgage_amt;
                principalAmt = requiredPayment - interestAmt;
                mortgage_amt -= principalAmt;
                term += 1;


            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            TextBox4.Text = string.Empty;
            TextBox5.Text = string.Empty;
            TextBox6.Text = string.Empty;
            TextBox7.Text = string.Empty;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            requiredPayment = CalcMinPayment();
        }

        private void CreateHeaderRow()
        {
            //Create table with the required columns.
            TableRow columnRow = new TableRow();
            Table1.Rows.Add(columnRow);


            TableCell termCount = new TableCell();
            termCount.Text = "Num. of Terms";
            columnRow.Cells.Add(termCount);

            TableCell monthlyPay = new TableCell();
            monthlyPay.Text = "Monthly Payment";
            columnRow.Cells.Add(monthlyPay);


            TableCell extraPayment = new TableCell();
            extraPayment.Text = "Extra Payment";
            columnRow.Cells.Add(extraPayment);


            TableCell paidInterest = new TableCell();
            paidInterest.Text = "Paid Interest";
            columnRow.Cells.Add(paidInterest);


            TableCell paidPrincipal = new TableCell();
            paidPrincipal.Text = "Paid Principal";
            columnRow.Cells.Add(paidPrincipal);


            TableCell loanRemaining = new TableCell();
            loanRemaining.Text = "Loan Balance Remaining";
            columnRow.Cells.Add(loanRemaining);
        }

        private void CreateValueRow(int cells, int termcount, double monthlypay, double extrapay, double interestpay, double principalpay, double remaining)
        {
            TableRow columnRow = new TableRow();
            Table1.Rows.Add(columnRow);
            if (termcount == 0)
            {
                for (int i = 1; i < cells;  i++)
                {

                    TableCell termCount = new TableCell();
                    columnRow.Cells.Add(termCount);

                    TableCell monthlyPay = new TableCell();
                    columnRow.Cells.Add(monthlyPay);


                    TableCell extraPayment = new TableCell();
                    columnRow.Cells.Add(extraPayment);


                    TableCell paidInterest = new TableCell();
                    columnRow.Cells.Add(paidInterest);


                    TableCell paidPrincipal = new TableCell();
                    columnRow.Cells.Add(paidPrincipal);
                }
                TableCell loanRemaining = new TableCell();
                loanRemaining.Text = remaining.ToString();
                columnRow.Cells.Add(loanRemaining);
            }
            else
            {
                TableCell termCount = new TableCell();
                termCount.Text = termcount.ToString();
                columnRow.Cells.Add(termCount);

                TableCell monthlyPay = new TableCell();
                monthlyPay.Text = monthlypay.ToString();
                columnRow.Cells.Add(monthlyPay);


                TableCell extraPayment = new TableCell();
                extraPayment.Text = extrapay.ToString();
                columnRow.Cells.Add(extraPayment);


                TableCell paidInterest = new TableCell();
                paidInterest.Text = interestpay.ToString();
                columnRow.Cells.Add(paidInterest);


                TableCell paidPrincipal = new TableCell();
                paidPrincipal.Text = principalpay.ToString();
                columnRow.Cells.Add(paidPrincipal);


                TableCell loanRemaining = new TableCell();
                loanRemaining.Text = remaining.ToString();
                columnRow.Cells.Add(loanRemaining);

            }
        }

        private double CalcMinPayment()
        {
            if(mortgage_amt > 0 && years > 0 && paymentPerYear > 0 && downpayment >= 0 && rate > 0)
            {
                TextBox5.ForeColor = System.Drawing.Color.Black;
                TextBox5.Text = Math.Ceiling(mortgage_amt * (rate / (100 * paymentPerYear))* Math.Pow(1 + (rate / (100 * paymentPerYear)),years * paymentPerYear)/
                                (Math.Pow(1 + (rate / (100 * paymentPerYear)), years * paymentPerYear) -1 )).ToString();
                return double.Parse(TextBox5.Text);
            }
            else
            {
                TextBox5.ForeColor = System.Drawing.Color.Red;
                TextBox5.Text = "Invalid Input/s";               
                return 0;
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Session["Mortgage Amt"] = TextBox1.Text;
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            Session["Years"] = TextBox2.Text;
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {
            Session["Payments Per year"] = TextBox3.Text;
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {
            Session["DownPayment"] = TextBox4.Text;
        }

        protected void TextBox7_TextChanged(object sender, EventArgs e)
        {
            Session["Rate"] = TextBox7.Text;
        }

        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {
            Session["Extra Payment"] = TextBox6.Text;
        }
    }
}