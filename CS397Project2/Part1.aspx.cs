using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS397Project2
{
    public partial class Part1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetDdlItems();
            }
        }

        protected void CalculateBtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                decimal carCost = Decimal.Parse(CarTypeDdl.SelectedValue);
                int days;
                try
                {
                    days = Int32.Parse(DaysTbx.Text);
                    decimal totalCost = days * carCost;
                    ErrorLbl.Text = "";
                    RentalCostLbl.Text = "The total cost of your rental will be: $" + String.Format(totalCost.ToString("0.00"));
                }
                catch (Exception)
                {
                    RentalCostLbl.Text = "";
                    ErrorLbl.Text = "Please enter an integer to indicate the number of days.";
                }
            }
            else
            {
                ErrorLbl.Text = "Please enter an integer to indicate the number of days.";
                RentalCostLbl.Text = "";
            }
        }

        private void SetDdlItems()
        {
            ListItem economy = new ListItem("Economy ($24.99)", "24.99");
            ListItem compact = new ListItem("Compact ($29.99)", "29.99");
            ListItem intermediate = new ListItem("Intermediate ($34.99)", "34.99");
            ListItem standard = new ListItem("Standard ($44.99)", "44.99");
            ListItem full = new ListItem("Full ($49.99)", "49.99");

            CarTypeDdl.Items.Add(economy);
            CarTypeDdl.Items.Add(compact);
            CarTypeDdl.Items.Add(intermediate);
            CarTypeDdl.Items.Add(standard);
            CarTypeDdl.Items.Add(full);
        }
    }
}