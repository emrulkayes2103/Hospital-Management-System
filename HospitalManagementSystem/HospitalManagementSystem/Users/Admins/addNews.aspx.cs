using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;

namespace HospitalManagementSystem.Users.Admins
{
    public partial class addNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Username"] != null)
                {
                    string username = Session["Username"].ToString();
                    sendNametoMasterpage(username);
                }
                else
                {
                    Response.Redirect("~/userlogin.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
        protected void sendNametoMasterpage(string email)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string command = "select Name from admin where email=@email";
                    using (SqlCommand cmd = new SqlCommand(command, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@email", email);
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            string username = (string)dr["Name"];
                            Master.lblforUserName.Text = username;
                        }
                        else
                        {
                            Master.lblforUserName.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
        protected void publish_Click(object sender, EventArgs e)
        {
            string title = txtTitleNews.Text;
            string details = txtDescription.Text;
            if (title != string.Empty && details != string.Empty)
            {
                sendNews(title, details);
                ClientScript.RegisterStartupScript(Page.GetType(), "",
                    "<script language='javascript'>alert('Successfully Published')</script>");
                txtTitleNews.Text = "";
                txtDescription.Text = "";
            }
            else
            {
                lblMsg.Text = "Fill uo all";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void sendNews(string newsTitle, string newsDescription)
        {
            try
            {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string command = "insert into recentNews values (@newstitle,@newsDescription)";
                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                    cmd.Parameters.AddWithValue("@newstitle", newsTitle);
                    cmd.Parameters.AddWithValue("@newsDescription", newsDescription);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            }
            catch(Exception ex)
            {
                Response.Write(ex);
            }
        }
    }
}