using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Mortgage_Calculator
{
    public partial class _Default : Page
    {
        decimal mortgage_amt;
        double years;
        double paymentPerYear;
        decimal downpayment;
        decimal requiredPayment;
        double rate;
        bool recurring;
        decimal extraPay;
        int addAt;
        decimal totalInterestPaid;




        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Mortgage Amt"] != null)
            {
                mortgage_amt = Decimal.Parse(Session["Mortgage Amt"].ToString());
            }
            if (Session["Years"] != null) 
            {
                years = Double.Parse(Session["Years"].ToString());
            }

            if (Session["Payments Per year"] != null) 
            {
                paymentPerYear = Double.Parse(Session["Payments Per year"].ToString());
            }

            if (Session["Rate"] != null)
            {
                rate = Double.Parse(Session["Rate"].ToString());
            }

            if (Session["Extra Payment"] != null)
            {
                extraPay = Decimal.Parse(Session["Extra Payment"].ToString());
            }

            if (Session["Required Payment"] != null)
            {
                requiredPayment = Decimal.Parse(Session["Required Payment"].ToString());

            }
            if (Session["DownPayment"] != null)
            {
                downpayment = Decimal.Parse(Session["DownPayment"].ToString());

            }
            if (Session["Add at"] != null)
            {
                addAt = Int32.Parse(Session["Add at"].ToString());

            }
            if (Session["Checked"] != null)
            {
                recurring = Convert.ToBoolean(Session["Checked"]);

            }

        }
                
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Create amortization table with the required number of rows and columns.
            requiredPayment = CalcMinPayment();
            if (mortgage_amt > 0 && years > 0 && paymentPerYear > 0 && downpayment >= 0 && rate > 0 && extraPay >= 0 && addAt >= 0)
            {
                CreateHeaderRow();
                decimal interestStraightWay = requiredPayment * (decimal)(years * paymentPerYear) - mortgage_amt;

                int term = 0;
                decimal interestAmt = 0;
                decimal principalAmt = 0;
                decimal initialpay = 0;
                decimal additionalPay = 0;
                CreateValueRow(term, initialpay, additionalPay, interestAmt, principalAmt, mortgage_amt);
                while (mortgage_amt > 0 && term < (years * paymentPerYear))
                {
                    term += 1;
                    if (recurring || addAt == term)
                    {
                        additionalPay = extraPay;
                    }
                    else
                    {
                        additionalPay = 0;
                    }
                    interestAmt = Math.Round((decimal)(rate / (100 * paymentPerYear)) * mortgage_amt,2);
                    totalInterestPaid += interestAmt;
                    principalAmt = Math.Round(requiredPayment - interestAmt + additionalPay,2);
                    mortgage_amt -= principalAmt;
                    CreateValueRow(term, requiredPayment, additionalPay, interestAmt, principalAmt, mortgage_amt);

                }

                //Printing out some valueable information.
                P1.Visible = true;
                P2.Visible = true;
                P3.Visible = true;
                StringBuilder content1 = new StringBuilder();
                StringBuilder content2 = new StringBuilder();
                StringBuilder content3 = new StringBuilder();
                content1.AppendLine("Interest without additional payment = ");
                content1.Append(interestStraightWay);
                content2.AppendLine("Interest this way = ");
                content2.Append(totalInterestPaid);
                content3.AppendLine("Total saving in Interest = ");
                content3.Append(interestStraightWay - totalInterestPaid);

                P1.InnerText = content1.ToString();
                P2.InnerText = content2.ToString();
                P3.InnerText = content3.ToString();



            }
            else
            {
                TableCell error = new TableCell();
                error.ForeColor = System.Drawing.Color.Red;
                error.Text = "Check your Inputs";

                TableRow errorRow = new TableRow();
                errorRow.Cells.Add(error);

                Table1.Rows.Add(errorRow);
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
            TextBox8.Text = string.Empty;
            CheckBox1.Checked = false;
            TextBox8.Visible = true;
            Label5.Visible = true;
            P1.Visible = false;
            P2.Visible = false;
            P3.Visible = false;
            Session.Clear();
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

        private void CreateValueRow(int termcount, decimal monthlypay, decimal extrapay, decimal interestpay, decimal principalpay, decimal remaining)
        {
            TableRow columnRow = new TableRow();
            Table1.Rows.Add(columnRow);
            
            TableCell termCount = new TableCell();
            termCount.Text = termcount.ToString();
            columnRow.Cells.Add(termCount);

            TableCell monthlyPay = new TableCell();
            monthlyPay.Text = Math.Round(monthlypay,2).ToString();
            columnRow.Cells.Add(monthlyPay);


            TableCell extraPayment = new TableCell();
            extraPayment.Text = Math.Round(extrapay,2).ToString();
            columnRow.Cells.Add(extraPayment);


            TableCell paidInterest = new TableCell();
            paidInterest.Text = Math.Round(interestpay,2).ToString();
            columnRow.Cells.Add(paidInterest);


            TableCell paidPrincipal = new TableCell();
            paidPrincipal.Text = Math.Round(principalpay,2).ToString();
            columnRow.Cells.Add(paidPrincipal);


            TableCell loanRemaining = new TableCell();
            loanRemaining.Text = Math.Round(remaining,2).ToString();
            columnRow.Cells.Add(loanRemaining);
            //}
        }

        private decimal CalcMinPayment()
        {
            if(mortgage_amt > 0 && years > 0 && paymentPerYear > 0 && downpayment >= 0 && rate > 0)
            {
                mortgage_amt -= downpayment;
                TextBox5.ForeColor = System.Drawing.Color.Black;
                TextBox5.Text = Math.Round((mortgage_amt * (decimal)(rate / (100 * paymentPerYear))* (decimal)Math.Pow(1 + (rate / (100 * paymentPerYear)),years * paymentPerYear)/
                                (decimal)(Math.Pow(1 + (rate / (100 * paymentPerYear)), years * paymentPerYear) -1 ))).ToString();
                Session["Required Payment"] = TextBox5.Text;
                return Decimal.Parse(TextBox5.Text);
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
            if (!decimal.TryParse(Session["Mortgage Amt"].ToString(), out mortgage_amt))
            {
                Session["Mortgage Amt"] = 0;
                mortgage_amt = 0;
            }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            Session["Years"] = TextBox2.Text;
            if (!Double.TryParse(Session["Years"].ToString(), out years))
            {            
                Session["Years"] = 0;
                years = 0;
            }
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {
            Session["Payments Per year"] = TextBox3.Text;
            if (!Double.TryParse(Session["Payments Per year"].ToString(), out paymentPerYear))
            {
                Session["Payments Per year"] = 0;
                paymentPerYear = 0;
            }
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {
            Session["DownPayment"] = TextBox4.Text;
            if (!decimal.TryParse(Session["DownPayment"].ToString(), out downpayment))
            {
                Session["DownPayment"] = 0;
                downpayment = 0;
            }
            //else
            //{
            //    Session["Mortgage Amt"] = decimal.Parse(Session["Mortgage Amt"].ToString()) - decimal.Parse(Session["DownPayment"].ToString());
            //    mortgage_amt = decimal.Parse(Session["Mortgage Amt"].ToString());
            //}
        }

        protected void TextBox7_TextChanged(object sender, EventArgs e)
        {
            Session["Rate"] = TextBox7.Text;
            if (!Double.TryParse(Session["Rate"].ToString(), out rate))
            {
                Session["Rate"] = 0;
                rate = 0;
            }
        }

        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {
            Session["Extra Payment"] = TextBox6.Text;
            if (!decimal.TryParse(Session["Extra Payment"].ToString(), out extraPay))
            {
                Session["Extra Payment"] = 0;
                extraPay = 0;
            }
        }

        protected void TextBox8_TextChanged(object sender, EventArgs e)
        {
            if (!recurring)
            {
                Session["Add at"] = TextBox8.Text;
                if (!int.TryParse(Session["Add at"].ToString(), out addAt))
                {
                    Session["Add at"] = 0;
                    addAt = 0;
                }
            }

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            Session["Checked"] = CheckBox1.Checked;
            recurring = Convert.ToBoolean(Session["Checked"]);
            if (CheckBox1.Checked)
            {
                TextBox8.Visible = false;
                Label5.Visible = false;
                //Session["Add at"] = 0;
                //addAt = 0;
            }
            else
            {
                TextBox8.Visible = true;
                Label5.Visible = true;
            }
        }
    }
}