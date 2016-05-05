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
    public partial class recentNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getNews1();
            string newsTitle = Request.QueryString["title"];
            if (newsTitle != null)
            {
                txtTitle.NavigateUrl = "~/Services/recentNews.aspx?title=" + newsTitle;
                getNews(newsTitle);
            }
            else
            {
                getNews1();
            }
        }
        protected void getNews1()
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string command = "select top 2 NewsTitle from recentNews order by ID desc";
                    using (SqlCommand cmd = new SqlCommand(command, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        repeter.DataSource = ds;
                        repeter.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
        protected void getNews(string title)
        {

            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string command = "select * from recentNews where NewsTitle=@title";
                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                   
                    con.Open();
                    cmd.Parameters.AddWithValue("@title", title);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        txtTitle.Text = (string)dr["NewsTitle"];
                        txtBody.Text = (string)dr["NewsDetails"];
                    }
                }
            }
        }
    }
}