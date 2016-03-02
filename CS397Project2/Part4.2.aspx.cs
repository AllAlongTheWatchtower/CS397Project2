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
    public partial class Part4__1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetSpecializationDdlItems();
                SearchForPhysiciansBySpecialization();
            }
        }

        protected void SpecializationDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchForPhysiciansBySpecialization();
        }

        private void SearchForPhysiciansBySpecialization()
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["ResearchCS"].ConnectionString);
            String query = "SELECT FirstName, LastName, PhoneNumber from Physicians WHERE Specialization=@s";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@s", SpecializationDdl.SelectedValue);
            OleDbDataAdapter da = new OleDbDataAdapter(command);
            DataSet dataSet = new DataSet();
            da.Fill(dataSet, "PhysicianInfo");
            gvPhysicians.DataSource = dataSet.Tables["PhysicianInfo"];
            gvPhysicians.DataBind();
        }

        private void SetSpecializationDdlItems()
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["ResearchCS"].ConnectionString);
            String query = "SELECT Distinct Specialization from Physicians";
            OleDbCommand command = new OleDbCommand(query, connection);
            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListItem li = new ListItem(reader["Specialization"].ToString(), reader["Specialization"].ToString());
                SpecializationDdl.Items.Add(li);
            }
            reader.Close();
            connection.Close();
        }

        protected void gvPhysicians_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridViewRowEventArgs ea = e as GridViewRowEventArgs;
            if (ea.Row.RowType == DataControlRowType.DataRow)
            {
                FormatPhoneNumber(ea);
            }
        }

        private void FormatPhoneNumber(GridViewRowEventArgs ea)
        {
            DataRowView drv = ea.Row.DataItem as DataRowView;
            Object ob = drv["PhoneNumber"];
            if (!Convert.IsDBNull(ob))
            {
                Int64 iParsedValue = 0;
                if (Int64.TryParse(ob.ToString(), out iParsedValue))
                {
                    TableCell cell = ea.Row.Cells[2];
                    cell.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture,
                       "{0:(###) ###-####}", new object[] { iParsedValue });
                }
            }
        }
    }
}