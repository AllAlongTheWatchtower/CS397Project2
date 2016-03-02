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
    public partial class Part3__1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetMajorDdlItems();
                SearchStudentsByMajor();
            }
        }

        protected void MajorDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchStudentsByMajor();
        }

        private void SearchStudentsByMajor()
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["StudentsCS"].ConnectionString);
            String query = "SELECT FirstName, LastName from Students where Major=@m";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@m", MajorDdl.SelectedValue);
            OleDbDataAdapter da = new OleDbDataAdapter(command);
            DataSet dataSet = new DataSet();
            da.Fill(dataSet, "StudentInfo");
            gvStudents.DataSource = dataSet.Tables["StudentInfo"];
            gvStudents.DataBind();
        }

        private void SetMajorDdlItems()
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["StudentsCS"].ConnectionString);
            String query = "SELECT Distinct Major from Students";
            OleDbCommand command = new OleDbCommand(query, connection);
            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListItem li = new ListItem(reader["Major"].ToString(), reader["Major"].ToString());
                MajorDdl.Items.Add(li);
            }
            reader.Close();
            connection.Close();
        }
    }
}