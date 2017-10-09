using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRun_Click(object sender, EventArgs e)
        {
            lblError.Visible = !lblError.Visible;
            lblError.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        }
    }
}