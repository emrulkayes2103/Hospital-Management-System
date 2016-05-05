using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace HospitalManagementSystem.Users.Accountent
{
    public partial class paymentHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getPaymentHIstory();
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
                    string command = "select Name from Accountant where Email=@email";
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
        protected void getPaymentHIstory()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string command = "select seialNo,Name,FathersName,PayableAmmount,PaidAmmount,due,Date from Payment";
                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
            }
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            string serial = txtTokenNumber.Text;
            if (serial != string.Empty)
            {
                findHistory(serial);
            }
            else
            {
                errorMsg.Text = "Enter serial number";
                errorMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void findHistory(string serial)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string command = "select seialNo,Name,FathersName,PayableAmmount,PaidAmmount,due,Date from Payment where seialNo=@serial";
                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                    cmd.Parameters.AddWithValue("@serial", serial);
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
                        errorMsg.Text = "No Data Found";
                        errorMsg.ForeColor = System.Drawing.Color.Red;
                        getPaymentHIstory();
                    }
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getPaymentHIstory();
        }
    }
}