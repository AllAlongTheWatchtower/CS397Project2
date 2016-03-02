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
    public partial class Part3__4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                String LastName = LastNameTbx.Text;
                if (LastName != "")
                {
                    OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["StudentsCS"].ConnectionString);
                    String query = "SELECT * from Students where LastName=@n";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@n", LastNameTbx.Text);
                    OleDbDataAdapter da = new OleDbDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    da.Fill(dataSet, "StudentInfo");
                    if (dataSet.Tables[0].Rows.Count == 0)
                    {
                        ErrorLbl.Text = "No search results.  Please try again!";
                        ClearGridView();
                    }
                    else
                    {
                        ErrorLbl.Text = "";
                        gvStudents.DataSource = dataSet.Tables["StudentInfo"];
                        gvStudents.DataBind();
                    }
                }
                else
                {
                    ErrorLbl.Text = "Please enter a last name in the search box";
                    ClearGridView();
                }
            }
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

        private void ClearGridView()
        {
            gvStudents.DataSource = null;
            gvStudents.DataBind();
        }
    }
}