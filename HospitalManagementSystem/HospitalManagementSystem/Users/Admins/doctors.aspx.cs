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
    public partial class doctors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getDoctorsData();
                populatedeEpertment();
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
                string name = txtDoctName.Text;
                string Email = email.Text;
                string pass = txtPass.Text;
                string rePass = txtRepass.Text;
                string add = address.Text;
                string no = phn.Text;
                string sex = radioBtn.SelectedValue.ToString();
                string depertMent = dept.SelectedValue.ToString();

                if (name != string.Empty && Email != string.Empty && pass != string.Empty && rePass != string.Empty && add != string.Empty && no != string.Empty && sex != string.Empty && depertMent != string.Empty)
                {
                    if (pass == rePass)
                    {
                        if (validateEmail(Email) == true)
                        {
                            if (chkEmail(Email) == false)
                            {
                                sendDocotorsData(name, Email, pass, add, no, sex, depertMent);

                                txtDoctName.Text = "";
                                email.Text = "";
                                txtPass.Text = "";
                                txtRepass.Text = "";
                                address.Text = "";
                                phn.Text = "";
                                errorMsg.Text = "";
                                radioBtn.ClearSelection();
                                dept.ClearSelection();
                            }
                            else
                            {
                                errorMsg.Text = "Email id is already exists";
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
                        errorMsg.Text = "Password and Re-type Password do not match";
                        errorMsg.ForeColor = System.Drawing.Color.Red;
                        ClientScript.RegisterStartupScript(Page.GetType(), "",
                            "<script language='javascript'>var div = document.getElementById('addDept');div.style.display = 'block';</script>");
                    }
                }
                else
                {

                    errorMsg.Text = "Enter all Information Please";
                        errorMsg.ForeColor = System.Drawing.Color.Red;
                        ClientScript.RegisterStartupScript(Page.GetType(),"",
                            "<script language='javascript'>var div = document.getElementById('addDept');div.style.display = 'block';</script>");
                }

            }
            catch (Exception ex)
            {
              ClientScript.RegisterStartupScript(Page.GetType(),"Error",
                  "<script language='javascript'>alert ('Error Is '"+ex+")</script>");
            }
        }
        protected void sendDocotorsData(string name, string email,string pass,string add,string no,string sex , string dept)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string commandText = "insert into Doctors values (@name,@email,@Pass,@address,@no,@dept,@sex)";
                using (SqlCommand cmd = new SqlCommand(commandText, con))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    cmd.Parameters.AddWithValue("@address", add);
                    cmd.Parameters.AddWithValue("@no", no);
                    cmd.Parameters.AddWithValue("@dept", dept);
                    cmd.Parameters.AddWithValue("@sex", sex);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();  
                    getDoctorsData();
                }
            }
        }
        protected void getDoctorsData()
        {
            
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string commandText = "select ID,Name,Email,[Address],Phone,Depertment,Sex from Doctors order by ID ASC";
                using (SqlDataAdapter da = new SqlDataAdapter(commandText,con))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();

                }

            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getDoctorsData();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            getDoctorsData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            getDoctorsData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label ID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblID");
            TextBox Name = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtName");
            TextBox Email = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEmail");
            TextBox Address = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtAdd");
            TextBox Phone = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPhn");
            TextBox Depertment = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtDept");
            TextBox Sex = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtSex");

            string id = ID.Text;
            string name = Name.Text;
            string email = Email.Text;
            string add = Address.Text;
            string phn = Phone.Text;
            string dept = Depertment.Text;
            string sex = Sex.Text;
            if (name != string.Empty && email != string.Empty && add != string.Empty && phn != string.Empty && dept != string.Empty && sex != string.Empty)
            {
                if (sex == "Male" || sex == "Female")
                {
                    int number;
                    if (int.TryParse(phn, out number))
                    {
                        if (validateEmail(email) == true)
                        {
                            if (chkEmail(email) == false)
                            {
                                updateData(id, name, email, add, phn, dept, sex);
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(Page.GetType(), "Error",
                                                "<script language='javascript'>alert ('Email id is already exists')</script>");
                    
                            }
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(Page.GetType(), "Error",
                 "<script language='javascript'>alert ('Enter correct format of Email')</script>");
                    
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(Page.GetType(), "Error",
                  "<script language='javascript'>alert ('Enter phone number without (+) sign')</script>");
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "Error",
                  "<script language='javascript'>alert ('Enter Sex only Male or Female')</script>");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "",
                  "<script language='javascript'>alert ('Enter all information')</script>");
            }
            
        }
        protected void updateData(string id,string name,string email,string add,string phn, string dept,string sex)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string command = "update Doctors set Name=@name , Email = @email ,Address = @add , Phone = @phn ,Depertment =@dept, Sex = @sex where ID=@id";
                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@add", add);
                    cmd.Parameters.AddWithValue("@phn", phn);
                    cmd.Parameters.AddWithValue("@dept", dept);
                    cmd.Parameters.AddWithValue("@sex", sex);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    GridView1.EditIndex = -1;
                    getDoctorsData();
                }

            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label ID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblID");
            string id = ID.Text;
            if (id != string.Empty)
            {
                deleteData(id);
                getDoctorsData();
                ClientScript.RegisterStartupScript(Page.GetType(), "",
         "<script language='javascript'>alert('Delete successfully')</script>");
            }
        }
        protected void deleteData(string id)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string command = "delete from Doctors where ID=@id";
                using (SqlCommand cmd = new SqlCommand(command, con))
                {

                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    GridView1.EditIndex = -1;
                    getDoctorsData();
                }

            }
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
        protected void populatedeEpertment()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string cmnd = "select Name from DepertmentList";
                using (SqlDataAdapter da = new SqlDataAdapter(cmnd, con))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dept.DataSource = ds;
                    dept.DataTextField = "Name";
                    dept.DataValueField = "Name";
                    dept.DataBind();
                    dept.Items.Insert(0, new ListItem("--Please select Depertment", "0"));
                }
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