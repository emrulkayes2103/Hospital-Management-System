using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace HospitalManagementSystem.Services
{
    public partial class doctorDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            string name = Request.QueryString["title"];
            
            if (name != null)
            {
                lblName.Text = name;
                lblName.NavigateUrl = "~/Services/doctorDetails.aspx?title=" + name;
                getDetails(name);
            }
            else
            {
                Response.Redirect("~/Services/FindDoctors.aspx");
            }
        }
        protected void getDetails(string Name)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string command = "select Name,Day,StartTime,EndTime from DoctorsSchedule where Name=@name";
                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                    cmd.Parameters.AddWithValue("@name", Name);
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        lblName.Text = (string)rd["Name"];
                        visitingDays.Text = (string)rd["Day"];
                        lblStartTime.Text = (string)rd["StartTime"];
                        lblEndTime.Text = (string)rd["EndTime"];
                    }
                    else
                    {
                        visitingDays.Text = "No records Found";
                        visitingDays.ForeColor = System.Drawing.Color.Red;
                        lblStartTime.Visible = false;
                        lblEndTime.Text = "No records Found";
                        lblEndTime.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
    }
}