using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS397Project2
{
    public partial class Part2 : System.Web.UI.Page
    {
        private int hours;
 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CalculateCostBtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try {
                    hours = (int) Math.Ceiling(Double.Parse(HoursTbx.Text));
                }
                catch (Exception)
                {
                    ErrorLbl.Text = "Please check that you have entered the correct data and retry.";
                    CostLbl.Text = "";
                }
                decimal cost = CalculateCost();
                CostLbl.Text = "$" + cost.ToString("0.00");
            }
            else
            {
                ErrorLbl.Text = "Please check that you have entered the correct data and retry.";
                CostLbl.Text = "";
            }
        }

        private decimal CalculateCost()
        {
            decimal cost;
            if (hours >= 12)
            {
                cost = 18;
            }
            else if (hours <= 3)
            {
                cost = 5;
            }
            else
            {
                cost = Convert.ToDecimal(5 + (hours - 3) * 1.5);
            }
            return cost;
        }
    }
}