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
    public partial class Employee : System.Web.UI.Page
    {
        #region Properties and variables
        UsersBOL usersBOL = new UsersBOL();
        UsersManager usersManager = new UsersManager();
        #endregion
        #region Methods and Events
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            //usersBOL.UserName = txtUserName.Text;
            //usersBOL.FirstName = txtFirstName.Text;
            //usersBOL.LastName = txtLastName.Text;
            //usersBOL.CreatedOn = DateTime.Now;
            //if (usersManager.Insert(usersBOL))
            //{
            //    LoadUsers();
            //}
        }
        public void LoadUsers()
        {
            //gvUsers.DataSource = usersManager.Select(new UsersBOL());
            //gvUsers.DataBind();
        }

        #endregion
    }
}