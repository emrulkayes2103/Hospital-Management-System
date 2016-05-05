using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace HospitalManagementSystem.Users.Admins
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getAdminData();
            }
            try
            {
                if (Session["Username"] != null)
                {
                    string name = Session["Username"].ToString();
                    sendNametoMasterpage(name);
                   
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

       
        protected void updatePass_Click(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                string name = Session["Username"].ToString();
                string oldpass = txtPrePass.Text;
                string newPass = txtNewPass.Text;
                string reTypeNewpass = txtReTypeNewPass.Text;
                if (name != string.Empty && oldpass != string.Empty && newPass != string.Empty && reTypeNewpass != string.Empty)
                {
                    if (newPass == reTypeNewpass)
                    {
                        if (chkPassMatch(oldpass, name) == true)
                        {
                            updatePassword(name, newPass);
                            txtPrePass.Text = "";
                            txtNewPass.Text = "";
                            txtReTypeNewPass.Text = "";
                            errorMsg.Text = "";
                            ClientScript.RegisterStartupScript(Page.GetType(), "",
                                "<script language='javascript'>alert('Your password is updated')</script>");

                        }
                        else
                        {
                            errorMsg.Text = "Previous password is incorrect";
                            errorMsg.ForeColor = System.Drawing.Color.Red;
                            ClientScript.RegisterStartupScript(Page.GetType(), "",
                                "<script language='javascript'>var div = document.getElementById('UpdatePasswordblock');div.style.display = 'block';</script>");

                        }
                    }
                    else
                    {
                        errorMsg.Text = "New password and retype new Password do not match";
                        errorMsg.ForeColor = System.Drawing.Color.Red;
                        ClientScript.RegisterStartupScript(Page.GetType(), "",
                            "<script language='javascript'>var div = document.getElementById('UpdatePasswordblock');div.style.display = 'block';</script>");

                    }
                }
                else
                {
                    errorMsg.Text = "Enter all information Please";
                    errorMsg.ForeColor = System.Drawing.Color.Red;
                    ClientScript.RegisterStartupScript(Page.GetType(), "",
                        "<script language='javascript'>var div = document.getElementById('UpdatePasswordblock');div.style.display = 'block';</script>");

                }
            }
            else
            {
                errorMsg.Text = "Password Could not updated";
                errorMsg.ForeColor = System.Drawing.Color.Red;
                ClientScript.RegisterStartupScript(Page.GetType(), "",
                    "<script language='javascript'>var div = document.getElementById('UpdatePasswordblock');div.style.display = 'block';</script>");

            }
        }
        protected bool chkPassMatch(string oldPass, string name)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string command = "select * from admin where email=@name and pass=@oldPass";
                    using (SqlCommand cmd = new SqlCommand(command, con))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@oldPass", oldPass);
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
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
        protected void updatePassword(string name, string newPass)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string command = "update admin set pass=@newPass where email=@name";
                    using (SqlCommand cmd = new SqlCommand(command, con))
                    {
                        cmd.Parameters.AddWithValue("@newPass", newPass);
                        cmd.Parameters.AddWithValue("@name", name);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string add = txtAddress.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;

            if (name != string.Empty && add != string.Empty && email != string.Empty && phone != string.Empty)
            {
                int number;
                if (int.TryParse(phone, out number))
                {
                    updateAdminData(name, email, add, phone);
                    ClientScript.RegisterStartupScript(Page.GetType(), "",
                       "<script language='javascript'>alert('Profile successfully Updated')</script>");

                }
                else
                {
                    errorMsgPro.Text = "Enter phone number in correct format without(+) sign";
                    errorMsgPro.ForeColor = System.Drawing.Color.Red;
                    ClientScript.RegisterStartupScript(Page.GetType(), "",
                        "<script language='javascript'>var div = document.getElementById('updateProBlock');div.style.display = 'block';</script>");

                }
            }
            else
            {
                errorMsgPro.Text = "Enter all information Please";
                errorMsgPro.ForeColor = System.Drawing.Color.Red;
                ClientScript.RegisterStartupScript(Page.GetType(), "",
                    "<script language='javascript'>var div = document.getElementById('updateProBlock');div.style.display = 'block';</script>");

            }
        }
        protected void getAdminData()
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string Email = Session["Username"].ToString();
                    string command = "select Name,email,address,mob from admin where email=@email";
                    using (SqlCommand cmd = new SqlCommand(command, con))
                    {

                        cmd.Parameters.AddWithValue("@email", Email);
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            txtName.Text = (string)dr["Name"];
                            txtEmail.Text = (string)dr["email"];
                            txtAddress.Text = (string)dr["address"].ToString();
                            txtPhone.Text = (string)dr["mob"];
                        }
                        else
                        {
                            Response.Redirect("~/~/userlogin.aspx");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
        protected void updateAdminData(string name,string email,string add, string phone)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string command = "update admin set Name=@name,address=@add,mob=@phn where email=@email";
                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@add", add);
                    cmd.Parameters.AddWithValue("@phn", phone);
                    cmd.Parameters.AddWithValue("@email", email);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}