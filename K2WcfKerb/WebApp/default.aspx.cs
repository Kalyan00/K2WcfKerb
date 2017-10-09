using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.WcvSvcRef;

namespace WebApp
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRun_Click(object sender, EventArgs e)
        {
            List<K2UserInfo> userInfos = this.getUserInfos();
            if(userInfos?.Count > 0)
            {
                btnRun.Enabled = false;
                Table tab = new Table();
                userInfos.ForEach(x => tab.Rows.Add(getUserInfoRow(x)));
                pnlContainer.Controls.Add(tab);
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "No users found";
            }
        }

        public List<K2UserInfo> getUserInfos()
        {
            List<K2UserInfo> ret = new List<K2UserInfo>();
            try
            {
                AppSvcClient client = new AppSvcClient();
                var users = client.GetUsers();
                ret.AddRange(users);
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }

            return ret;
        }

        private TableRow getUserInfoRow(K2UserInfo ui)
        {
            TableRow tr = new TableRow();
            tr.Cells.Add(getTd(ui.Fqn));
            tr.Cells.Add(getTd(ui.DisplayName));
            tr.Cells.Add(getTd(ui.Email));
            tr.Cells.Add(getTd(ui.Username));
            tr.Cells.Add(getTd(ui.Manager));
            return tr;
        }

        private TableCell getTd(string text)
        {
            Label lblText = new Label();
            lblText.Text = text;
            TableCell td = new TableCell();
            td.Controls.Add(lblText);
            return td;
        }
    }
}