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
    public partial class Categories : System.Web.UI.Page
    {
        #region Properties and variables
        CategoriesBOL objCategoriesBOL = new CategoriesBOL();
        CategoriesManager objCategoriesManager = new CategoriesManager();
        #endregion
        #region Methods and Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                LoadData();
        }
        public void LoadData()
        {
            gvCategories.DataSource = objCategoriesManager.Select(new CategoriesBOL());
            gvCategories.DataBind();
        }
        public void GetData()
        {
            objCategoriesBOL.CategoryName = txtCategoryName.Text;
            objCategoriesBOL.Description = txtDescription.Text;
        }
        public void SetData()
        {
            txtCategoryName.Text = objCategoriesBOL.CategoryName;
            txtDescription.Text = objCategoriesBOL.Description;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GetData();
            objCategoriesManager.Insert(objCategoriesBOL);
            LoadData();
        }
        #endregion

    }
}