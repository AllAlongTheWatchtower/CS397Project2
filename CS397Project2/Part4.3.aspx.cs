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
    public partial class Part4__2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetStudyTitlesDdlItems();
            }
        }

        private void SetStudyTitlesDdlItems()
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["ResearchCS"].ConnectionString);
            String query = "SELECT * FROM Studies";
            OleDbCommand command = new OleDbCommand(query, connection);
            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListItem li = new ListItem(reader["Title"].ToString(), reader["StudyID"].ToString());
                StudiesDdl.Items.Add(li);
            }
            reader.Close();
            connection.Close();
            SearchVolunteers();
        }

        protected void StudiesDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchVolunteers();
        }

        private void SearchVolunteers()
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["ResearchCS"].ConnectionString);
            String query = "SELECT FirstName, LastName FROM Volunteers WHERE StudyID=@s";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@s", StudiesDdl.SelectedValue);
            OleDbDataAdapter da = new OleDbDataAdapter(command);
            DataSet dataSet = new DataSet();
            da.Fill(dataSet, "ParticipantInfo");
            gvVolunteers.DataSource = dataSet.Tables["ParticipantInfo"];
            gvVolunteers.DataBind();
        }
    }
}