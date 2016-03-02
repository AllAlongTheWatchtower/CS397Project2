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
    public partial class Part3__3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetGenderDdlItems();
                DisplayStudentsByGender();
            }
        }

        protected void GenderDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayStudentsByGender();
        }

        private void DisplayStudentsByGender()
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["StudentsCS"].ConnectionString);
            String query = "SELECT * from Students where Gender=@g";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@g", GenderDdl.SelectedValue);
            OleDbDataAdapter da = new OleDbDataAdapter(command);
            DataSet dataSet = new DataSet();
            da.Fill(dataSet, "StudentInfo");
            gvStudents.DataSource = dataSet.Tables["StudentInfo"];
            gvStudents.DataBind();
        }

        private void SetGenderDdlItems()
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["StudentsCS"].ConnectionString);
            String query = "SELECT Distinct Gender from Students";
            OleDbCommand command = new OleDbCommand(query, connection);
            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListItem li = new ListItem(reader["Gender"].ToString(), reader["Gender"].ToString());
                GenderDdl.Items.Add(li);
            }
            reader.Close();
            connection.Close();
        }

        protected void gvStudents_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridViewRowEventArgs ea = e as GridViewRowEventArgs;
            if (ea.Row.RowType == DataControlRowType.DataRow)
            {
                FormatPhoneNumber(ea);
                FormatSSN(ea);
                FormatPostalCode(ea);
            }
        }

        private void FormatPostalCode(GridViewRowEventArgs ea)
        {
            DataRowView drv = ea.Row.DataItem as DataRowView;
            Object ob = drv["PostalCode"];
            if (!Convert.IsDBNull(ob))
            {
                Int64 iParsedValue = 0;
                if (Int64.TryParse(ob.ToString(), out iParsedValue))
                {
                    TableCell cell = ea.Row.Cells[6];
                    cell.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture,
                       "{0:#####-####}", new object[] { iParsedValue });
                }
            }
        }

        private void FormatSSN(GridViewRowEventArgs ea)
        {
            DataRowView drv = ea.Row.DataItem as DataRowView;
            Object ob = drv["SSN"];
            if (!Convert.IsDBNull(ob))
            {
                Int64 iParsedValue = 0;
                if (Int64.TryParse(ob.ToString(), out iParsedValue))
                {
                    TableCell cell = ea.Row.Cells[0];
                    cell.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture,
                       "{0:###-##-####}", new object[] { iParsedValue });
                }
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
                    TableCell cell = ea.Row.Cells[7];
                    cell.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture,
                       "{0:(###) ###-####}", new object[] { iParsedValue });
                }
            }
        }
    }
}