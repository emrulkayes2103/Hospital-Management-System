using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace HospitalManagementSystem.Services
{
    public partial class FindDoctors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlDeptofDocs.AutoPostBack = false;
            if (!IsPostBack)
            {
                populateDepartment();
                getDoctorsData();
            }
        }

        protected void populateDepartment()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string command = "select Name from DepertmentList";
                using (SqlDataAdapter da = new SqlDataAdapter(command, cs))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    ddlDeptofDocs.DataSource = ds;
                    ddlDeptofDocs.DataTextField = "Name";
                    ddlDeptofDocs.DataValueField = "Name";
                    ddlDeptofDocs.DataBind();

                    ddlDeptofDocs.Items.Insert(0,new ListItem("<Any>","0"));
                }
            }
        }

        protected void btnfindDoc_Click(object sender, EventArgs e)
        {
            string name = txtFindDoctor.Text;
            string dept = ddlDeptofDocs.SelectedValue.ToString();
            if (name != string.Empty && dept != string.Empty)
            {
                if (dept == "<Any>")
                {
                    err.Text = "You must have to select a depertment";
                    err.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    findDoctors(name, dept);
                    txtFindDoctor.Text = "";
                    docDesignation.Text = "";
                    ddlDeptofDocs.ClearSelection();
                }
            }
            else
            {
                if (name == string.Empty)
                {
                    err.Text = "Enter Name";
                    err.ForeColor = System.Drawing.Color.Red;
                }
                else if (dept == string.Empty)
                {
                    err.Text = "Enter Depertment";
                    err.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    err.Text = "Enter all correct Information";
                    err.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        protected void findDoctors(string name,string dept)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string command = "select Name,Depertment from Doctors where Name like '%@name%' and Depertment like '%@dept%'";
                    using (SqlCommand cmd = new SqlCommand(command, con))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@dept", dept);
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds);

                            GridView1.DataSource = ds;
                            GridView1.DataBind();
                        }
                        else
                        {
                            errorMsg.Text = "Data not Found";
                            errorMsg.ForeColor = System.Drawing.Color.Red;
                            GridView1.Visible = false;
                        }

                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
        protected void getDoctorsData()
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string command = "select Name,Depertment from Doctors";
                    using (SqlCommand cmd = new SqlCommand(command, con))
                    {
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
        }
    }
}