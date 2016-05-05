using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Security;

namespace HospitalManagementSystem
{
    public partial class userlogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string username
        {
            get
            {
                return txtEmail.Text;
            }
        }
        public string password
        {
            get
            {
                return txtPass.Text;
            }
        }
        protected void submit_Click(object sender, EventArgs e)
        {
            Session["Username"] = username;
            

            if (username != string.Empty && password != string.Empty)
            {
                logUser(username,password);
            }
            else
            {
                errorMsg.Text = "Please enter your E-mail and password";
                errorMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void logUser(string username,string password)
        {
            try
            {
                        if (AdminLogin(username,password)==true)
                        {
                            Response.Redirect("~/Users/Admins/admin.aspx",false);
                        }
                        else if(DoctorsLogin(username,password)==true)
                        {
                            Response.Redirect("~/Users/Doctors/dashboard.aspx",false);
                        }
                        else if (laboratoristLogin(username,password)==true)
                        {
                            Response.Redirect("~/Users/Laboratorist/dashboard.aspx",false);
                        }
                        else if(ReceptionistLogin(username,password)==true)
                        {
                            Response.Redirect("~/Users/Receptionist/dashBoard.aspx",false);
                            
                        }
                        else if (accountantLogin(username, password) == true)
                        {
                            Response.Redirect("~/Users/Accountent/dashboard.aspx", false);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(Page.GetType(), "validation",
                                "<script language='javascript'>alert('Invalid Username and Password')</script>");
                        }
                    }
            catch(Exception ex)
            {
                Response.Write("Error " + ex);
            }
        }
        public bool AdminLogin(string email, string pass)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                using (SqlConnection con = new SqlConnection(CS))
                {
                    string command = "select * from admin where Email=@email and pass=@password";
                    using (SqlCommand cmd = new SqlCommand(command, con))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", pass);

                        con.Open();
                        SqlDataReader da = cmd.ExecuteReader();

                        if (da.HasRows)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                return true;
            }
        }
        public bool DoctorsLogin(string email,string pass)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                using (SqlConnection con = new SqlConnection(CS))
                {
                    string command = "select * from Doctors where Email=@email and pass=@password";
                    using (SqlCommand cmd = new SqlCommand(command, con))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", pass);

                        con.Open();
                        SqlDataReader da = cmd.ExecuteReader();

                        if (da.HasRows)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                return true;
            }      
        }
        public bool laboratoristLogin(string email,string pass)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                using (SqlConnection con = new SqlConnection(CS))
                {
                    string command = "select * from laboratorist where Email=@email and pass=@password";
                    using (SqlCommand cmd = new SqlCommand(command, con))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", pass);

                        con.Open();
                        SqlDataReader da = cmd.ExecuteReader();

                        if (da.HasRows)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                return true;
            }
        }
        public bool ReceptionistLogin(string email, string pass)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                using (SqlConnection con = new SqlConnection(CS))
                {
                    string command = "select * from Receptionist where Email=@email and pass=@password";
                    using (SqlCommand cmd = new SqlCommand(command, con))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", pass);

                        con.Open();
                        SqlDataReader da = cmd.ExecuteReader();

                        if (da.HasRows)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                return true;
            }
        }
        public bool accountantLogin(string email, string pass)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                using (SqlConnection con = new SqlConnection(CS))
                {
                    string command = "select * from Accountant where Email=@email and pass=@password";
                    using (SqlCommand cmd = new SqlCommand(command, con))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", pass);

                        con.Open();
                        SqlDataReader da = cmd.ExecuteReader();

                        if (da.HasRows)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                return true;
            }
        }
    }
}