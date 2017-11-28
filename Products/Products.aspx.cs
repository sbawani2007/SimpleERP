using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERP.BOL;
using ERP.Manager;

namespace SimpleERP.Products
{
    public partial class Products : System.Web.UI.Page
    {
        #region Properties and variables
        ProductsBOL objProductsBOL = new ProductsBOL();
        ProductsManager objProductsManager = new ProductsManager();
        SuppliersManager objSuppliersManager = new SuppliersManager();
        CategoriesManager objCategoriesManager = new CategoriesManager();
        #endregion
        #region Methods and Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadData();
                LoadSuppliers();
                LoadCategories();
            }
        }
        public void LoadData()
        {
            gvProducts.DataSource = objProductsManager.Select(new ProductsBOL());
            gvProducts.DataBind();
        }
        public void LoadSuppliers()
        {
            ddlSupplier.DataSource = objSuppliersManager.Select(new SuppliersBOL());
            ddlSupplier.DataTextField = "CompanyName";
            ddlSupplier.DataValueField = "SupplierID";
            ddlSupplier.DataBind();
        }
        public void LoadCategories()
        {
            ddlCategory.DataSource = objCategoriesManager.Select(new CategoriesBOL());
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryID";
            ddlCategory.DataBind();
        }
        public void GetData()
        {
            objProductsBOL.ProductName = Convert.ToString(txtProductName.Text);
            objProductsBOL.SupplierID = Convert.ToInt32(ddlSupplier.SelectedValue);
            objProductsBOL.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
            objProductsBOL.QuantityPerUnit = Convert.ToString(txtQuantityPerUnit.Text);
            objProductsBOL.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
            objProductsBOL.UnitsInStock = Convert.ToInt32(txtUnitsInStock.Text);
            objProductsBOL.UnitsOnOrder = Convert.ToInt32(txtUnitsOnOrder.Text);
            objProductsBOL.ReorderLevel = Convert.ToInt32(txtReorderLevel.Text);
            objProductsBOL.Discontinued = Convert.ToInt32(txtDiscontinued.Text);
        }
        public void SetData()
        {
            txtProductName.Text = Convert.ToString(objProductsBOL.ProductName);
            ddlSupplier.SelectedValue = Convert.ToString(objProductsBOL.SupplierID);
            ddlCategory.SelectedValue = Convert.ToString(objProductsBOL.CategoryID);
            txtQuantityPerUnit.Text = Convert.ToString(objProductsBOL.QuantityPerUnit);
            txtUnitPrice.Text = Convert.ToString(objProductsBOL.UnitPrice);
            txtUnitsInStock.Text = Convert.ToString(objProductsBOL.UnitsInStock);
            txtUnitsOnOrder.Text = Convert.ToString(objProductsBOL.UnitsOnOrder);
            txtReorderLevel.Text = Convert.ToString(objProductsBOL.ReorderLevel);
            txtDiscontinued.Text = Convert.ToString(objProductsBOL.Discontinued);
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GetData();
            objProductsManager.Insert(objProductsBOL);
            LoadData();
        }
        #endregion


    }
}