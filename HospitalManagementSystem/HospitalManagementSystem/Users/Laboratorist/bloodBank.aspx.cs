using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace HospitalManagementSystem.Users.Laboratorist
{
    public partial class bloodBank : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getBloodData();
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
                    string command = "select Name from laboratorist where Email=@email";
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
        protected void getBloodData()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string command = "select * from bloodBank";
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
            getBloodData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label ID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblID");
            TextBox Quantity = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtQuantity");

            string id = ID.Text;
            string quantity = Quantity.Text;
            if (id != string.Empty && quantity != string.Empty)
            {
                updateData(id, quantity);
                getBloodData();
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Error",
                 "<script language='javascript'>alert ('Enter all information')</script>");
                
            }
        }

        protected void updateData(string id,string quantity)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string command = "update bloodBank set Quantity=@quantity where ID=@id";
                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.EditIndex = -1;
                }
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            getBloodData();
        }
    }
}