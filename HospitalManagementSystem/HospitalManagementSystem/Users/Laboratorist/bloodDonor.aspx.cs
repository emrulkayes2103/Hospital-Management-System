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
using System.Globalization;

namespace HospitalManagementSystem.Users.Laboratorist
{
    public partial class bloodDonor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getDonorData();
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
                    string command = "select Name from Laboratorist where Email=@email";
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
            string name = txtDonortName.Text;
            string Email = email.Text;
            string add = address.Text;
            string phone = phn.Text;
            string bloogGroup = ddlbloodGroup.SelectedValue.ToString();
            string Sex = radioBtn.SelectedValue.ToString();

            if (name != string.Empty && Email != string.Empty && add != string.Empty && phone != string.Empty && bloogGroup != string.Empty && Sex != string.Empty)
            {
                if (validateEmail(Email) == true)
                {
                    if (chkEmail(Email) == false)
                    {
                        int number;
                        if (int.TryParse(phone, out number))
                        {
                            bloodDonorList(name, Email, add, phone, bloogGroup, Sex);
                            getDonorData();
                            txtDonortName.Text = "";
                            email.Text = "";
                            address.Text = "";
                            phn.Text = "";
                            ddlbloodGroup.ClearSelection();
                            radioBtn.ClearSelection();
                            errorMsg.Text = "";
                        }
                        else
                        {
                            errorMsg.Text = "Enter phone number withour (+) sign";
                            errorMsg.ForeColor = System.Drawing.Color.Red;
                            ClientScript.RegisterStartupScript(Page.GetType(), "",
                                "<script language='javascript'>var div = document.getElementById('addDept');div.style.display = 'block';</script>");

                        }
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
                    errorMsg.Text = "Inavlid Email";
                    errorMsg.ForeColor = System.Drawing.Color.Red;
                    ClientScript.RegisterStartupScript(Page.GetType(), "",
                        "<script language='javascript'>var div = document.getElementById('addDept');div.style.display = 'block';</script>");

                }
            }
            else
            {
                errorMsg.Text = "Enter all Information Please";
                errorMsg.ForeColor = System.Drawing.Color.Red;
                ClientScript.RegisterStartupScript(Page.GetType(), "",
                    "<script language='javascript'>var div = document.getElementById('addDept');div.style.display = 'block';</script>");
               
            }
        }
        protected void bloodDonorList(string name, string email,string add,string phn,string bGroup,string sex)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string command = "insert into bloodDonor values(@name,@email,@add,@phn,@bgroup,@sex)";
                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@add", add);
                    cmd.Parameters.AddWithValue("@phn", phn);
                    cmd.Parameters.AddWithValue("@bgroup", bGroup);
                    cmd.Parameters.AddWithValue("@sex", sex);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        protected void getDonorData()
        {
             string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
             using (SqlConnection con = new SqlConnection(CS))
             {
                 string command = "select * from bloodDonor order by ID ASC";
                 using (SqlDataAdapter da = new SqlDataAdapter(command,con))
                 {
                     con.Open();
                     DataSet ds = new DataSet();
                     da.Fill(ds);
                     GridView1.DataSource = ds;
                     GridView1.DataBind();
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
        public bool chkEmail(string email)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string commandText = "select Email from bloodDonor where Email=@email";
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getDonorData();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            getDonorData();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label Email = (Label)GridView1.Rows[e.RowIndex].FindControl("txtEmail");
            string email = Email.Text;
            if (email != string.Empty)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "",
                    "<script language='javascript'>confirm('Are you sure want to delete ?')</script>");
                deleteData(email);
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "",
                    "<script language='javascript'>alert('Data not found')</script>");
            }
        }
        protected void deleteData(string email)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string command = "delete from bloodDonor where Email =@email";
                using (SqlCommand cmd = new SqlCommand(command,con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    getDonorData();
                }
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            getDonorData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label ID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblID");
            TextBox Name = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtName");
            TextBox Email = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEmail");
            TextBox Add = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtAdd");
            TextBox Phone = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPhone");
            DropDownList ddlBloogGroup = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("bGroupDDl");
            TextBox Sex = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtSex");

            string id = ID.Text;
            string name = Name.Text;
            string email = Email.Text;
            string address = Add.Text;
            string phn = Phone.Text;
            string bloodGroup = ddlBloogGroup.SelectedValue.ToString();
            string sex = Sex.Text;

            if (id != string.Empty && name != string.Empty && email != string.Empty && address != string.Empty && phn != string.Empty && bloodGroup != string.Empty && sex != string.Empty)
            {
                if (validateEmail(email) == true)
                {
                    int number;
                    if (int.TryParse(phn, out number))
                    {
                        if (sex == "Male" || sex == "Female")
                        {
                           
                                updateDonorData(id, name, email, address, phn, bloodGroup, sex);
                                getDonorData();
                                ClientScript.RegisterStartupScript(Page.GetType(), "",
                     "<script language='javascript'>alert('Data successfully Updated')</script>");
                            }
                        else
                        {
                            ClientScript.RegisterStartupScript(Page.GetType(), "",
                  "<script language='javascript'>alert('Enter sex only Male or Female ')</script>");
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
                   "<script language='javascript'>alert('Invalid Email ID')</script>");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "",
                    "<script language='javascript'>alert('Enter all information')</script>");
            }
        }
        protected void updateDonorData(string id , string name, string email,string add,string phone,string bGroup,string sex)
        {
            try
            {
                 string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                 using (SqlConnection con = new SqlConnection(cs))
                 {
                     string command = "update bloodDonor set Name=@name,Email=@email,Address=@add,Phone=@phn,BloodGroup=@bgroup,Sex=@sex where ID=@id";
                     using (SqlCommand cmd = new SqlCommand(command, con))
                     {
                         cmd.Parameters.AddWithValue("@id", id);
                         cmd.Parameters.AddWithValue("@name", name);
                         cmd.Parameters.AddWithValue("@email", email);
                         cmd.Parameters.AddWithValue("@add", add);
                         cmd.Parameters.AddWithValue("@phn", phone);
                         cmd.Parameters.AddWithValue("@bgroup", bGroup);
                         cmd.Parameters.AddWithValue("@sex", sex);
                         con.Open();
                         cmd.ExecuteNonQuery();
                         GridView1.EditIndex = -1;
                         getDonorData();
                     }
                 }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
    }
}