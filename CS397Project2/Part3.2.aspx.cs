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
    public partial class Part3__2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetStateDdlItems();
                SearchForStudentsByState();
            }
        }

        protected void StateDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchForStudentsByState();
        }

        private void SearchForStudentsByState()
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["StudentsCS"].ConnectionString);
            String query = "SELECT FirstName, LastName from Students where State=@s";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@s", StateDdl.SelectedValue);
            OleDbDataAdapter da = new OleDbDataAdapter(command);
            DataSet dataSet = new DataSet();
            da.Fill(dataSet, "StudentInfo");
            gvStudents.DataSource = dataSet.Tables["StudentInfo"];
            gvStudents.DataBind();
        }

        private void SetStateDdlItems()
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["StudentsCS"].ConnectionString);
            String query = "SELECT Distinct State from Students";
            OleDbCommand command = new OleDbCommand(query, connection);
            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListItem li = new ListItem(reader["State"].ToString(), reader["State"].ToString());
                StateDdl.Items.Add(li);
            }
            reader.Close();
            connection.Close();
        }
    }
}