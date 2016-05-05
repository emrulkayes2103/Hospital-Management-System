using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem.Admin
{
    public partial class admins : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       
        public Label lblforUserName
        {
            get
            {
                return this.lblForUser;
            }
        }
    }
}