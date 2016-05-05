using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;

namespace HospitalManagementSystem.Users.Admins
{
    public partial class pharmasist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getData();
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

        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtLaboratoristName.Text;
                string Email = email.Text;
                string Password = txtPass.Text;
                string rePass = txtRepass.Text;
                string add = address.Text;
                string phone = phn.Text;
                string Sex = radioBtn.SelectedValue.ToString();

                if (name != string.Empty && Email != string.Empty && Password != string.Empty && rePass != string.Empty && add != string.Empty && phone != string.Empty && Sex != string.Empty)
                {
                    if (Password == rePass)
                    {
                        int number;
                        if (int.TryParse(phone, out number))
                        {
                            if (validateEmail(Email) == true)
                            {
                                if (chkEmail(Email) == false)
                                {
                                    sendData(name, Email, Password, add, phone, Sex);
                                    txtLaboratoristName.Text = "";
                                    email.Text = "";
                                    txtPass.Text = "";
                                    txtRepass.Text = "";
                                    address.Text = "";
                                    phn.Text = "";
                                    errorMsg.Text = "";
                                    radioBtn.ClearSelection();
                                }
                                else
                                {
                                    errorMsg.Text = "Email is already exists";
                                    errorMsg.ForeColor = System.Drawing.Color.Red;
                                    ClientScript.RegisterStartupScript(Page.GetType(), "",
                                    "<script language='javascript'>var div = document.getElementById('addDept');div.style.display = 'block';</script>");
                    
                       
                                }
                            }
                            else
                            {
                                errorMsg.Text = "Enter correct format of Email";
                                errorMsg.ForeColor = System.Drawing.Color.Red;
                                ClientScript.RegisterStartupScript(Page.GetType(), "",
                                "<script language='javascript'>var div = document.getElementById('addDept');div.style.display = 'block';</script>");
                    
                            }
                        }
                        else
                        {
                            errorMsg.Text = "Enter phone number without (+) sign";
                            errorMsg.ForeColor = System.Drawing.Color.Red;
                            ClientScript.RegisterStartupScript(Page.GetType(), "",
                            "<script language='javascript'>var div = document.getElementById('addDept');div.style.display = 'block';</script>");
                    
                        }

                    }
                    else
                    {
                        errorMsg.Text = "Password and Re-type Password do not match";
                        errorMsg.ForeColor = System.Drawing.Color.Red;
                        ClientScript.RegisterStartupScript(Page.GetType(), "",
                            "<script language='javascript'>var div = document.getElementById('addDept');div.style.display = 'block';</script>");
                    }
                }
                else
                {
                    errorMsg.Text = "Enter all Information";
                    errorMsg.ForeColor = System.Drawing.Color.Red;
                    ClientScript.RegisterStartupScript(Page.GetType(), "",
                        "<script language='javascript'>var div = document.getElementById('addDept');div.style.display = 'block';</script>");
                }
            }
               
            catch (Exception ex)
            {
                Response.Write("Error :" + ex);
            }
        }
        protected void sendData(string name , string Email,string Pass ,string add,string phone,string sex)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string commandText = "insert into laboratorist values (@name,@email,@pass,@add,@phone,@sex)";
                using (SqlCommand cmd = new SqlCommand(commandText, con))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", Email);
                    cmd.Parameters.AddWithValue("@pass", Pass);
                    cmd.Parameters.AddWithValue("@add", add);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@sex", sex);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    getData();
                }
            }
        }
        protected void getData()
        {
             string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
             using (SqlConnection con = new SqlConnection(CS))
             {
                 string cmndTxt = "select ID,Name,Email,Address,Phone,Sex from laboratorist order by ID ASC";
                 using (SqlDataAdapter da = new SqlDataAdapter(cmndTxt, con))
                 {
                     DataSet ds = new DataSet();
                     da.Fill(ds);
                     GridView1.DataSource = ds;
                     GridView1.DataBind();
                 }
             }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            getData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Label ID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblId");
                TextBox Name = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtName");
                TextBox Email = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEmail");
                TextBox Add = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtAdd");
                TextBox Phone = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPhone");
                TextBox Sex = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtSex");

                string id = ID.Text;
                string name = Name.Text;
                string email = Email.Text;
                string add = Add.Text;
                string phn = Phone.Text;
                string sex = Sex.Text;

                if (name != string.Empty && email != string.Empty && add != string.Empty && phn != string.Empty && sex != string.Empty)
                {
                    int number;
                    if (int.TryParse(phn, out number))
                    {
                        if (validateEmail(email) == true)
                        {
                            if (chkEmail(email) == false)
                            {
                                updateInformation(id, name, email, add, phn, sex);
                                getData();
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(Page.GetType(), "",
                            "<script language='javascript'>alert('Email is already exists')</script>");
                            }
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(Page.GetType(), "",
                            "<script language='javascript'>alert('Enter Correct Format of Email')</script>");
                  
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(Page.GetType(), "",
                            "<script language='javascript'>alert('Enter Phone number without (+) sign')</script>");
                    }
                }
                else
                {

                    ClientScript.RegisterStartupScript(Page.GetType(), "",
                        "<script language='javascript'>alert('Enter all information')</script>");

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label ID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblId");
            string id = ID.Text;
            ClientScript.RegisterStartupScript(Page.GetType(), "",
        "<script language='javascript'>alert('Are you sure want to delete ?')</script>");
            if (id != string.Empty)
            {
                deleteData(id);

                getData();
                ClientScript.RegisterStartupScript(Page.GetType(), "",
         "<script language='javascript'>alert('Delete successfully')</script>");
            }
        }
        protected void deleteData(string id)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string command = "delete from laboratorist where ID=@id";
                using (SqlCommand cmd = new SqlCommand(command, con))
                {

                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    GridView1.EditIndex = -1;
                    getData();
                }

            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getData();
        }
        protected void updateInformation(string id, string name, string email, string add, string phn, string sex)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string command = "update laboratorist set Name=@name , Email=@email ,Address = @add ,Phone = @phn ,Sex = @sex where ID=@id";
                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@add", add);
                    cmd.Parameters.AddWithValue("@phn", phn);
                    cmd.Parameters.AddWithValue("@sex", sex);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    GridView1.EditIndex = -1;
                    getData();
                }
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            getData();
        }
        public bool validateEmail(string email)
        {
            string pattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            if (Regex.IsMatch(email, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool chkEmail(string email)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string commandText = "select Email from Doctors where Email=@email";
                    using (SqlCommand cmd = new SqlCommand(commandText, con))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
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
    }
}