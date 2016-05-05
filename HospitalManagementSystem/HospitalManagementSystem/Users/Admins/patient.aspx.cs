using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Globalization;
using System.Text.RegularExpressions;


namespace HospitalManagementSystem.Users.Admins
{
    public partial class patient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getPatientData();
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
                string Name = txtPatientName.Text;
                string Mail = email.Text;
                string Address = address.Text;
                string Phone = phn.Text;
                string Age = age.Text;
                string year = dobYear.Text;
                string month = dobMonth.Text;
                string day = dobDay.Text;
                string bloodGroup = ddlList.SelectedValue.ToString();
                string Sex = radioBtn.SelectedValue.ToString();

                if (Name != string.Empty && Mail != string.Empty && Address != string.Empty && Age != string.Empty && year != string.Empty && month != string.Empty && day != string.Empty && bloodGroup != string.Empty && Sex != string.Empty)
                {

                    int chckValue;
                    if (int.TryParse(Age, out chckValue) && int.TryParse(year, out chckValue) && int.TryParse(month, out chckValue) && int.TryParse(day, out chckValue))
                    {
                        if ((Convert.ToInt32(Age) >= 1 && (Convert.ToInt32(year) >= 1901 && Convert.ToInt32(year) <= 2020) && Convert.ToInt32(month) >= 1 && Convert.ToInt32(month) <= 12 && Convert.ToInt32(day) >= 1 && Convert.ToInt32(day) <= 31))
                        {
                            if (Convert.ToInt32(year) >= DateTime.Now.Year)
                            {
                                errorMsg.Text = "Enter correct Year";
                                errorMsg.ForeColor = System.Drawing.Color.Red;
                                ClientScript.RegisterStartupScript(Page.GetType(), "",
                               "<script language='javascript'>var div = document.getElementById('addDept');div.style.display = 'block';</script>");

                            }
                            else
                            {
                                if(validateEmail(Mail) == true)
                                {
                                    if (chkEmail(Mail) == false)
                                    {
                                        string Dob = year + "-" + month + "-" + day;
                                        sendPetientData(Name, Mail, Address, Phone, Age, Dob, bloodGroup, Sex);

                                        txtPatientName.Text = "";
                                        email.Text = "";
                                        address.Text = "";
                                        phn.Text = "";
                                        age.Text = "";
                                        dobYear.Text = "";
                                        dobMonth.Text = "";
                                        dobDay.Text = "";
                                        radioBtn.ClearSelection();
                                        errorMsg.Text = "";
                                        ddlList.ClearSelection();
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
                            
                        }
                        else
                        {
                            if (Convert.ToInt32(Age) < 1)
                            {
                                errorMsg.Text = "Enter correct Age";
                                errorMsg.ForeColor = System.Drawing.Color.Red;
                                ClientScript.RegisterStartupScript(Page.GetType(), "",
                               "<script language='javascript'>var div = document.getElementById('addDept');div.style.display = 'block';</script>");

                            }
                            if (Convert.ToInt32(month) < 1 || Convert.ToInt32(month) > 12)
                            {
                                errorMsg.Text = "Enter correct Month";
                                errorMsg.ForeColor = System.Drawing.Color.Red;
                                ClientScript.RegisterStartupScript(Page.GetType(), "",
                               "<script language='javascript'>var div = document.getElementById('addDept');div.style.display = 'block';</script>");

                            }
                            if (Convert.ToInt32(day) < 1 || Convert.ToInt32(day) > 31)
                            {
                                errorMsg.Text = "Enter correct Date";
                                errorMsg.ForeColor = System.Drawing.Color.Red;
                                ClientScript.RegisterStartupScript(Page.GetType(), "",
                               "<script language='javascript'>var div = document.getElementById('addDept');div.style.display = 'block';</script>");

                            }

                        }

                    }
                    else
                    {
                        errorMsg.Text = "Enter correct format of Age or Date of Birth";
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
                Response.Write("Error" + ex);
            }

        }
        protected void sendPetientData(string name,string mail,string add,string phone,string age,string dob,string bloodgroup,string sex)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string CommandText = "insert into Patient values (@name,@mail,@add,@phone,@age,@dob,@bloodGroup,@sex)";
                using (SqlCommand cmd = new SqlCommand(CommandText, con))
                {

                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@add", add);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@dob", dob);
                    cmd.Parameters.AddWithValue("@bloodGroup", bloodgroup);
                    cmd.Parameters.AddWithValue("@sex", sex);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    getPatientData();
                    con.Close();
                }
            }
        }
        protected void getPatientData()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string cmndTxt = "select ID,Name,Email,Address,Phone,Age,DOB,bloodGroup,Sex from Patient order by ID ASC";
                using (SqlDataAdapter da = new SqlDataAdapter(cmndTxt, con))
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
            getPatientData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            getPatientData();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            getPatientData();
        }
      

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label ID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblId");
            TextBox Name = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtName");
            TextBox Email = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEmail");
            TextBox Address = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtAdd");
            TextBox Phone = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPhn");
            TextBox Age = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtAge");
            TextBox DOB = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtDob");
            DropDownList ddlList = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList1") as DropDownList ;
            TextBox Sex = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtSex");

            

            string id = ID.Text;
            string name = Name.Text;
            string email = Email.Text;
            string address = Address.Text;
            string phone = Phone.Text;
            string age = Age.Text;
            string dob = DOB.Text;
            string DdList = ddlList.SelectedValue.ToString();
            string sex = Sex.Text;

            if (name != string.Empty && email != string.Empty && address != string.Empty && phone != string.Empty && age != string.Empty && dob != string.Empty && DdList != string.Empty && sex != string.Empty)
            {
                DateTime validate;

                bool validDate = DateTime.TryParseExact(dob, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None
                    , out validate);
                if (validDate)
                {
                    int number;
                    if (int.TryParse(phone, out number))
                    {
                        if (validateEmail(email) == true)
                        {
                            if (chkEmail(email) == false)
                            {
                                updateData(id, name, email, address, phone, age, dob, DdList, sex);
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
                  "<script language='javascript'>alert('Enter correct format of Email')</script>");
                
                 
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
                    "<script language='javascript'>alert('Enter correct format of Date YYYY-MM-DD')</script>");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "",
                    "<script language='javascript'>alert('Enter all information')</script>");
            }
        }

        protected void updateData(string id,string name,string email, string add, string phn,string age,string dob, string bGroop,string sex)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string command = "update Patient set Name=@name , Email = @email ,Address = @add , Phone = @phn ,Age =@age,DOB =@dob,bloodGroup=@bgroup, Sex = @sex where ID=@id";
                    using (SqlCommand cmd = new SqlCommand(command, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@add", add);
                        cmd.Parameters.AddWithValue("@phn", phn);
                        cmd.Parameters.AddWithValue("@age", age);
                        cmd.Parameters.AddWithValue("@dob", dob);
                        cmd.Parameters.AddWithValue("@bgroup", bGroop);
                        cmd.Parameters.AddWithValue("@sex", sex);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        GridView1.EditIndex = -1;
                        getPatientData();
                    }

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
            if (id != string.Empty)
            {
                deleteData(id);
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "",
                  "<script language='javascript'>alert('Data not found')</script>");
            }
        }
        protected void deleteData(string id)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string command = "delete from Patient where ID=@id";
                using (SqlCommand cmd = new SqlCommand(command, con))
                {

                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    GridView1.EditIndex = -1;
                    getPatientData();
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