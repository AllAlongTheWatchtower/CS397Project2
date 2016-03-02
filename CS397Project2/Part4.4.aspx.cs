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
    public partial class Part4__4 : System.Web.UI.Page
    {
        private List<int> physicianId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetStudyIdDdlList();
                PopulatePhysicianDdlList();
            }
        }

        protected void StudiesDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulatePhysicianDdlList();
        }

        protected void PhysiciansDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            PhysicianNameLbl.Text = PhysiciansDdl.SelectedValue;
        }

        private void PopulatePhysicianDdlList()
        {
            SetListOfPhysicianIds();
            OleDbDataReader reader = GetListOfPhysicians();
            PhysiciansDdl.Items.Clear();
            while (reader.Read())
            {
                int id;
                try
                {
                    id = Int32.Parse(reader["PhysicianID"].ToString());
                    if (physicianId.Contains(id))
                    {
                        String name = reader["FirstName"].ToString() + " " + reader["LastName"].ToString();
                        ListItem li = new ListItem(id.ToString(), name);
                        PhysiciansDdl.Items.Add(li);
                    }
                }
                catch (Exception)
                {
                    ErrorLbl.Text = "Error!  Please try again!";
                }
            }
            PhysicianNameLbl.Text = PhysiciansDdl.SelectedValue;
        }

        private void SetStudyIdDdlList()
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
        }

        private OleDbDataReader GetListOfPhysicians()
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["ResearchCS"].ConnectionString);
            String query = "SELECT * FROM Physicians";
            OleDbCommand command = new OleDbCommand(query, connection);
            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            return reader;
        }

        private void SetListOfPhysicianIds()
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["ResearchCS"].ConnectionString);
            String query = "SELECT * FROM [Study-Physician] WHERE StudyID=@i";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@i", StudiesDdl.SelectedValue);
            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            physicianId = new List<int>();
            while (reader.Read())
            {
                physicianId.Add(Int32.Parse(reader["PhysicianID"].ToString()));
            }
            reader.Close();
            connection.Close();
        }
    }
}