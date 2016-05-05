using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace HospitalManagementSystem.Users.Admins
{
    public partial class depertment : System.Web.UI.Page
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
                string name = txtDeptName.Text;
                string desc = txtDescription.Text;
                if (name != string.Empty && desc != string.Empty)
                {
                    insertData(name, desc);
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
                Response.Write("Error :" + ex);
            }
        }
        protected void insertData(string name,string desc)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {


                string commandText = "insert into DepertmentList values (@name, @description)";
                using (SqlCommand cmd = new SqlCommand(commandText, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@description", desc);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                getData();
                txtDeptName.Text = "";
                txtDescription.Text = "";
                errorMsg.Text = "";
            }
        }
        public void getData()
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    string cmdText = "select * from DepertmentList";
                    using (SqlDataAdapter da = new SqlDataAdapter(cmdText, con))
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
                Response.Write("Error ");
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            getData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            getData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                TextBox deptNmae = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtDeptName");
                TextBox desc = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtDesc");
                Label Id = (Label)GridView1.Rows[e.RowIndex].FindControl("lblID");
               
                string name = deptNmae.Text;
                string description = desc.Text;
                string id = Id.Text;

                if (id!= string.Empty && name != string.Empty && description != string.Empty)
                {
                    updateData(id, name, description);
                    getData();
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "", "<script language='javascript'>alert('Enter all data')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
        protected void updateData(string id, string name, string description)
        {
             string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
             using (SqlConnection con = new SqlConnection(CS))
             {
                 string command = "update DepertmentList set Name=@name , Description=@desc where ID=@id";
                 using (SqlCommand cmd = new SqlCommand(command, con))
                 {
                     cmd.Parameters.AddWithValue("@id", id);
                     cmd.Parameters.AddWithValue("@name", name);
                     cmd.Parameters.AddWithValue("@desc", description);

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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label deptNmae = (Label)GridView1.Rows[e.RowIndex].FindControl("txtDeptName");
            string name = deptNmae.Text;
            deleteData(name);
        }
        protected void deleteData(string name)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string command = "delete from DepertmentList where Name=@name";
                using (SqlCommand cmd = new SqlCommand(command, con))
                {

                    cmd.Parameters.AddWithValue("@name", name);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    GridView1.EditIndex = -1;
                    getData();
                }

            }
        }
    }
}