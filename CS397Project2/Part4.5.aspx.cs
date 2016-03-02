using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS397Project2
{
    public partial class Part4__5 : System.Web.UI.Page
    {
        private DataSet dataSet;
        private int rows;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            GetDataSet();
            rows = dataSet.Tables["VolunteerInfo"].Rows.Count;
            DeleteRowsBelowMinimum();

            if (rows == 0)
            {
                ErrorLbl.Text = "No results!  Please try again.";
                gvVolunteers.DataSource = null;
                gvVolunteers.DataBind();
            }
            else {
                gvVolunteers.DataSource = dataSet.Tables["VolunteerInfo"];
                gvVolunteers.DataBind();
                ErrorLbl.Text = "";
            }
        }

        private void DeleteRowsBelowMinimum()
        {
            foreach (DataRow dr in dataSet.Tables["VolunteerInfo"].Rows)
            {
                Double cholesterol = Double.Parse(dr["Cholesterol"].ToString());
                Double targetCholesterol = Double.Parse(CholesterolTbx.Text);
                if (cholesterol < targetCholesterol)
                {
                    dr.Delete();
                    rows--;
                }
            }
        }

        private void GetDataSet()
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["ResearchCS"].ConnectionString);
            String query = "SELECT * FROM Volunteers";
            OleDbCommand command = new OleDbCommand(query, connection);
            OleDbDataAdapter da = new OleDbDataAdapter(command);
            dataSet = new DataSet();
            da.Fill(dataSet, "VolunteerInfo");
        }
    }
}