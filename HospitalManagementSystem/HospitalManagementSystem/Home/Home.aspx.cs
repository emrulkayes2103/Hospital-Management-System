using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace HospitalManagementSystem
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getNews();
        }
        protected void getNews()
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
    }
}