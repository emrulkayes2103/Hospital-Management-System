using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text.RegularExpressions;

namespace HospitalManagementSystem.Users.Admins
{
    public partial class nurse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getNurseDetails();
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
                string name = txtNurseName.Text;
                string Email = email.Text;
                string add = address.Text;
                string phone = phn.Text;
                string sex = radioBtn.SelectedValue.ToString();
                if (name != string.Empty && Email != string.Empty && add != string.Empty && phone != string.Empty && sex != string.Empty)
                {
                    int phnNumber;
                    if (int.TryParse(phone, out phnNumber))
                    {
                        if (validateEmail(Email) == true)
                        {
                            if (chkEmail(Email) == false)
                            {
                                sendNurseData(name, Email, add, phone, sex);
                                txtNurseName.Text = "";
                                email.Text = "";
                                address.Text = "";
                                phn.Text = "";
                                radioBtn.ClearSelection();
                                errorMsg.Text = "";
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
                        errorMsg.Text = "Enter Phone number";
                        errorMsg.ForeColor = System.Drawing.Color.Red;
                        ClientScript.RegisterStartupScript(Page.GetType(), "",
                   "<script language='javascript'>var div = document.getElementById('addDept');div.style.display = 'block';</script>");

                   
                        
                    }
                }
                else
                {
                    errorMsg.Text = "Enter all information";
                    errorMsg.ForeColor = System.Drawing.Color.Red;
                    ClientScript.RegisterStartupScript(Page.GetType(), "",
                   "<script language='javascript'>var div = document.getElementById('addDept');div.style.display = 'block';</script>");

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void sendNurseData(string name, string Email,string add,string phone,string sex )
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string command = "insert into Nurse values (@name,@email,@add,@phn,@sex)";
                    using (SqlCommand cmd = new SqlCommand(command, con))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@email", Email);
                        cmd.Parameters.AddWithValue("@add", add);
                        cmd.Parameters.AddWithValue("@phn", phone);
                        cmd.Parameters.AddWithValue("@sex", sex);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        getNurseDetails();
                    }

                }

            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }

        }
        protected void getNurseDetails()
        {
             string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
             using (SqlConnection con = new SqlConnection(CS))
             {
                 string command = "select ID,Name,Email,Address,Phone,Sex from Nurse order by ID asc";
                 using (SqlDataAdapter da = new SqlDataAdapter(command, con))
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
            getNurseDetails();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                TextBox Name = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtName");
                TextBox Email = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEmail");
                TextBox Address = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtAdd");
                TextBox Phone = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPhone");
                Label Id = (Label)GridView1.Rows[e.RowIndex].FindControl("lblID");
                //RadioButtonList Sex = (RadioButtonList)GridView1.Rows[e.RowIndex].FindControl("sex");

                //Sex.Items.Add(new ListItem("Male", "Male"));
                //Sex.Items.Add(new ListItem("Female", "Female"));
                TextBox Sex = (TextBox)GridView1.Rows[e.RowIndex].FindControl("Sex");

                string name = Name.Text;
                string email = Email.Text;
                string add = Address.Text;
                string phone = Phone.Text;
                string sex = Sex.Text;
                string id = Id.Text;

                if (name != string.Empty && email != string.Empty && add != string.Empty && phone != string.Empty && sex != string.Empty)
                {
                    if (sex == "Male" || sex == "Female")
                    {
                        if (validateEmail(email) == true)
                        {
                            int number;
                            if (int.TryParse(phone, out number))
                            {
                                if (chkEmail(email) == false)
                                {
                                    updateInformation(id, name, email, add, phone, sex);
                                }
                                else
                                {
                                    ClientScript.RegisterStartupScript(Page.GetType(), "",
                    "<script language='javascript'>alert('Email is already Exists')</script>");

                                }
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(Page.GetType(), "",
                    "<script language='javascript'>alert('Enter phone number without (+) sign')</script>");

                            }
                        }
                        else
                        {

                            ClientScript.RegisterStartupScript(Page.GetType(), "",
                    "<script language='javascript'>alert('Enter correct format of Email')</script>");

                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(Page.GetType(), "",
                "<script language='javascript'>alert('Sex column is only Male or Female')</script>");

                    }

                }
                else
                {
                    if (name == string.Empty)
                    {
                        ClientScript.RegisterStartupScript(Page.GetType(), "",
                "<script language='javascript'>alert('Enter Your Name')</script>");
                    }
                    if (email == string.Empty)
                    {
                        ClientScript.RegisterStartupScript(Page.GetType(), "",
             "<script language='javascript'>alert('Enter Your Email')</script>");
                    }
                    if (add == string.Empty)
                    {
                        ClientScript.RegisterStartupScript(Page.GetType(), "",
             "<script language='javascript'>alert('Enter Your Address')</script>");
                    }
                    if (phone == string.Empty)
                    {
                        ClientScript.RegisterStartupScript(Page.GetType(), "",
             "<script language='javascript'>alert('Enter Your Phone Number')</script>");
                    }
                    if (sex == string.Empty)
                    {
                        ClientScript.RegisterStartupScript(Page.GetType(), "",
             "<script language='javascript'>alert('Enter Your Gender')</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }

        }
        protected void updateInformation(string id, string name,string email,string add,string phn,string sex)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string command = "update Nurse set Name=@name , Email = @email ,Address = @add , Phone = @phn , Sex = @sex where ID=@id";
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
                    getNurseDetails();
                }

            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            getNurseDetails();
         
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label Email = (Label)GridView1.Rows[e.RowIndex].FindControl("txtEmail");
            string email = Email.Text;
           
            if (email != string.Empty)
            {
                deleteInformation(email);

                getNurseDetails();
                ClientScript.RegisterStartupScript(Page.GetType(), "",
         "<script language='javascript'>alert('Delete successfully')</script>");
            }
        }
        protected void deleteInformation(string email)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string command = "delete from Nurse where Email=@email";
                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                    
                    cmd.Parameters.AddWithValue("@email", email);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    GridView1.EditIndex = -1;
                    getNurseDetails();
                }

            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getNurseDetails();
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