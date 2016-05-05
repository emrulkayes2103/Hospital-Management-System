using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace HospitalManagementSystem.Users.Doctors
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getProfileInfo();
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
                    string command = "select Name from Doctors where Email=@email";
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
                    string command = "select * from Doctors where Email=@name and pass=@oldPass";
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
                    string command = "update Doctors set pass=@newPass where Email=@name";
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
            string Name = txtName.Text;
            string add = txtAddress.Text;
            string Email = txtEmail.Text;
            string phone = txtPhone.Text;
            string Dept = txtDept.Text;
            if (Dept!=string.Empty && Name != string.Empty && add != string.Empty && Email != string.Empty && phone != string.Empty)
            {
                int number;
                if (int.TryParse(phone, out number))
                {
                    updateProfileInfo(Name, Email, add, phone,Dept);
                    ClientScript.RegisterStartupScript(Page.GetType(), "", "<script language='javascript'>alert('Profile Successfully Updated')</script>");
                    errorMsgPro.Text = "";
                }
                else
                {
                    errorMsgPro.Text = "Enter valid phone number without (+) sign";
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
        protected void getProfileInfo()
        {
            try
            {
                if (Session["Username"] != null)
                {
                    string email = Session["Username"].ToString();
                    string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        string command = "select * from Doctors where Email=@email";
                        using (SqlCommand cmd = new SqlCommand(command, con))
                        {
                            con.Open();
                            cmd.Parameters.AddWithValue("@email", email);
                            SqlDataReader dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                txtName.Text = (string)dr["Name"];
                                txtEmail.Text = (string)dr["Email"];
                                txtAddress.Text = (string)dr["Address"];
                                txtPhone.Text = (string)dr["Phone"];
                                txtDept.Text = (string)dr["Depertment"];
                            }
                        }
                    }
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
        protected void updateProfileInfo(string name, string emai, string add, string phn,string dept)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string command = "update Doctors set Name=@name,Address=@add,Phone=@phn,Depertment=@dept where Email=@email";
                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@add", add);
                    cmd.Parameters.AddWithValue("@phn", phn);
                    cmd.Parameters.AddWithValue("@dept", dept);
                    cmd.Parameters.AddWithValue("@email", emai);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}