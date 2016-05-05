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

namespace HospitalManagementSystem.Users.Receptionist
{
    public partial class getToken : System.Web.UI.Page
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
                    string command = "select Name from Receptionist where Email=@email";
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
        protected void getData()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string commnd = "select top 10 serialNo,PatientName,fathersName,phone,Paid from AdmitedPatient order by ID desc";
                using (SqlCommand cmd = new SqlCommand(commnd, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    
                }
            }
        }


        protected void findSerial(string serial)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string command = "select serialNo,PatientName,fathersName,phone,Paid from AdmitedPatient where PatientName=@name and (Paid='NO' or Paid='N')";
                    using (SqlCommand cmd = new SqlCommand(command, con))
                    {
                        cmd.Parameters.AddWithValue("@name", serial);
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            GridView2.DataSource = dr;
                            GridView2.DataBind();
                            errorMsg.Text = "";
                            GridView1.Visible = false;
                        }
                        else
                        {
                            errorMsg.Text = "Data not Found";
                            errorMsg.ForeColor = System.Drawing.Color.Red;
                            getData();
                        }
                    }
                }
            }
            catch
                (Exception Ex)
            {
                Response.Write(Ex);
            }
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            string name = txtSerial.Text;
            if (name != string.Empty)
            {
                findSerial(name);
            }
            else
            {
                errorMsg.Text = "Enter Patient Name";
                errorMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}