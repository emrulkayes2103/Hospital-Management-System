using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using System.Text.RegularExpressions;

namespace HospitalManagementSystem.Users.Doctors
{
    public partial class VisitingDaysHours : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            dddlTimeEnd.AutoPostBack = false;
            ddlTimeStart.AutoPostBack = false;
            if (!IsPostBack)
            {
                
                populateDoctorsList();
                populateTime();
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
        protected void populateDoctorsList()
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string command = "select ID,Name from Doctors";
                    using (SqlDataAdapter da = new SqlDataAdapter(command,con))
                    {
                        con.Open();
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        ddlDoctorsList.DataSource = ds;
                        ddlDoctorsList.DataValueField = "ID";
                        ddlDoctorsList.DataTextField = "Name";
                        ddlDoctorsList.DataBind();
                       
                        ddlDoctorsList.Items.Insert(0,new ListItem("Please Select Doctor","0"));
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
        protected void populateTime()
        {
            DateTime startTime = DateTime.ParseExact("00:00", "HH:mm", null);
            DateTime endTime = DateTime.ParseExact("23:00", "HH:mm", null);

            TimeSpan interval = new TimeSpan(1, 0, 0);

            ddlTimeStart.Items.Clear();
            dddlTimeEnd.Items.Clear();

            while (startTime <= endTime)
            {
                ddlTimeStart.Items.Add(startTime.ToShortTimeString());
                dddlTimeEnd.Items.Add(startTime.ToShortTimeString());
                startTime = startTime.Add(interval);
            }
            ddlTimeStart.Items.Insert(0,new ListItem("Please select","0"));
            dddlTimeEnd.Items.Insert(0, new ListItem("Please select", "0"));
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            
            try
            {

                string name = ddlDoctorsList.SelectedItem.Text;
               
                string startTime = ddlTimeStart.SelectedValue.ToString();
                string endTime = dddlTimeEnd.SelectedValue.ToString();
                string days = "";
                for (int i = 0; i < chkBoxDays.Items.Count; i++)
                {
                    if (chkBoxDays.Items[i].Selected)
                    {
                        days += chkBoxDays.Items[i].Value;
                    }
                }

                if (name != string.Empty && days != string.Empty && startTime != string.Empty && endTime != string.Empty)
                {
                    string Email = getEmail();
                    if (_ifHasData() == true)
                    {
                        _updateData(name, days, startTime, endTime);
                        ddlDoctorsList.ClearSelection();
                        dddlTimeEnd.ClearSelection();
                        ddlTimeStart.ClearSelection();
                        chkBoxDays.ClearSelection();
                        errorMsg.Text = "";
                    }
                    else
                    {
                        insertData(name, Email, days, startTime, endTime);
                        ddlDoctorsList.ClearSelection();
                        dddlTimeEnd.ClearSelection();
                        ddlTimeStart.ClearSelection();
                        chkBoxDays.ClearSelection();
                        errorMsg.Text = "";
                    }
                }
                else
                {
                    errorMsg.Text = "Enter correct Year";
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
        public void getData()
        {
            try
            {
                 string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                 using (SqlConnection con = new SqlConnection(cs))
                 {
                     string comman = "select ID,Name,Day,StartTime,EndTime from DoctorsSchedule";
                     using (SqlDataAdapter da = new SqlDataAdapter(comman,con))
                     {
                         DataSet ds = new DataSet();
                         da.Fill(ds);
                         GridView1.DataSource = ds;
                         GridView1.DataBind();
                     }
                 }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
        protected void insertData(string name,string email, string days,string startTime,string endTime)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string command = "insert into DoctorsSchedule values(@name,@email,@days,@startTime,@endTime)";
                    using (SqlCommand cmd = new SqlCommand(command, con))
                    {
                        cmd.Parameters.AddWithValue("@name",name);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@days",days);
                        cmd.Parameters.AddWithValue("@startTime", startTime);
                        cmd.Parameters.AddWithValue("@endTime", endTime);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        getData();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            getData();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            getData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DropDownList ddlName = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlDoctorsList");
            DropDownList ddlStatTime = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlTimeStart");
            DropDownList ddlendTime = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("dddlTimeEnd");
          
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getData();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label ID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblID");
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
                string command = "delete from DoctorsSchedule where ID=@id";
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

        protected string getEmail()
        {
            string id = ddlDoctorsList.SelectedValue.ToString();
           

            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string command = "select Email from Doctors where ID=@id";
                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        string name = (string)dr["Email"];
                        return name;
                    }
                    else
                    {
                        string name = "Null";
                            return name;
                    }
                }
            }
        }
        protected bool _ifHasData()
        {
            string email = getEmail();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string command = "select Email from DoctorsSchedule where Email=@email";
                using (SqlCommand cmd = new SqlCommand(command, con))
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
        protected void _updateData(string name, string days, string startTime, string endTime)
        {
            string email = getEmail();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string command = "update DoctorsSchedule set Name=@name,Day=@day,StartTime=@startTime,EndTime=@endtTime where Email=@email";
                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@day", days);
                    cmd.Parameters.AddWithValue("@startTime", startTime);
                    cmd.Parameters.AddWithValue("@endtTime", endTime);
                    cmd.Parameters.AddWithValue("@email", email);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    getData();
                }
            }
        }
    }
}