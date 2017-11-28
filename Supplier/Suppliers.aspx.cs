using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERP.BOL;
using ERP.Manager;

namespace SimpleERP.Supplier
{
    public partial class Suppliers : System.Web.UI.Page
    {
        #region Properties and variables
        SuppliersBOL objSuppliersBOL = new SuppliersBOL();
        SuppliersManager objSuppliersManager = new SuppliersManager();
        #endregion
        #region Methods and Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                LoadData();
        }
        public void LoadData()
        {
            gvSuppliers.DataSource = objSuppliersManager.Select(new SuppliersBOL());
            gvSuppliers.DataBind();
        }
        public void GetData()
        {
            objSuppliersBOL.CompanyName = txtCompanyName.Text;
            objSuppliersBOL.ContactName = txtContactName.Text;
            objSuppliersBOL.ContactTitle = txtContactTitle.Text;
            objSuppliersBOL.Address = txtAddress.Text;
            objSuppliersBOL.City = txtCity.Text;
            objSuppliersBOL.Country = txtCountry.Text;
            objSuppliersBOL.Mobile = txtMobile.Text;
            objSuppliersBOL.Phone = txtPhone.Text;
            objSuppliersBOL.HomePage = txtHomePage.Text;
        }
        public void SetData()
        {
            txtCompanyName.Text = objSuppliersBOL.CompanyName;
            txtContactName.Text = objSuppliersBOL.ContactName;
            txtContactTitle.Text = objSuppliersBOL.ContactTitle;
            txtAddress.Text = objSuppliersBOL.Address;
            txtCity.Text = objSuppliersBOL.City;
            txtCountry.Text = objSuppliersBOL.Country;
            txtMobile.Text = objSuppliersBOL.Mobile;
            txtPhone.Text = objSuppliersBOL.Phone;
            txtHomePage.Text = objSuppliersBOL.HomePage;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GetData();
            objSuppliersManager.Insert(objSuppliersBOL);
            LoadData();
        }
        #endregion

    }
}