using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERP.BOL;
using ERP.Manager;

namespace SimpleERP.Customer
{
    public partial class Customers : System.Web.UI.Page
    {
        #region Properties and variables
        CustomersBOL objCustomersBOL = new CustomersBOL();
        CustomersManager objCustomersManager = new CustomersManager();
        #endregion
        #region Methods and Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                LoadData();
        }
        public void LoadData()
        {
            gvCustomers.DataSource = objCustomersManager.Select(new CustomersBOL());
            gvCustomers.DataBind();
        }
        public void GetData()
        {
            objCustomersBOL.CompanyName = txtCompanyName.Text;
            objCustomersBOL.ContactName = txtContactName.Text;
            objCustomersBOL.ContactTitle = txtContactTitle.Text;
            objCustomersBOL.Address = txtAddress.Text;
            objCustomersBOL.City = txtCity.Text;
            objCustomersBOL.Country = txtCountry.Text;
            objCustomersBOL.Phone = txtPhone.Text;
            objCustomersBOL.Fax = txtFax.Text;
        }
        public void SetData()
        {
            txtCompanyName.Text = objCustomersBOL.CompanyName;
            txtContactName.Text = objCustomersBOL.ContactName;
            txtContactTitle.Text = objCustomersBOL.ContactTitle;
            txtAddress.Text = objCustomersBOL.Address;
            txtCity.Text = objCustomersBOL.City;
            txtCountry.Text = objCustomersBOL.Country;
            txtPhone.Text = objCustomersBOL.Phone;
            txtFax.Text = objCustomersBOL.Fax;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GetData();
            objCustomersManager.Insert(objCustomersBOL);
        }
        #endregion

    }
}