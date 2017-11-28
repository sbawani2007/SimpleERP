using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERP.BOL;
using ERP.Manager;

namespace SimpleERP.Admin
{
    public partial class Users : System.Web.UI.Page
    {
        #region Properties and variables
        UsersBOL objUsersBOL = new UsersBOL();
        UsersManager objUsersManager = new UsersManager();
        #endregion
        #region Methods and Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                LoadData();
            GC.Collect();
        }
        public void LoadData()
        {
            gvUsers.DataSource = objUsersManager.Select(new UsersBOL());
            gvUsers.DataBind();
        }
        public void GetData()
        {
            objUsersBOL = new UsersBOL();
            objUsersBOL.UserName = txtUserName.Text;
            objUsersBOL.FirstName = txtFirstName.Text;
            objUsersBOL.LastName = txtLastName.Text;
            objUsersBOL.CreatedOn = Convert.ToDateTime(txtCreatedOn.Text);
        }
        public void SetData()
        {
            txtUserName.Text = objUsersBOL.UserName;
            txtFirstName.Text = objUsersBOL.FirstName;
            txtLastName.Text = objUsersBOL.LastName;
            txtCreatedOn.Text = objUsersBOL.CreatedOn.ToShortDateString();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GetData();
            objUsersManager.Insert(objUsersBOL);
        }
        #endregion

    }
}