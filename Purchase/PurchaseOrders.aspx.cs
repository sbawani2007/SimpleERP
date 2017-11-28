using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERP.BOL;
using ERP.Manager;
using GenericFunctions;

namespace SimpleERP.Purchase
{
    public partial class PurchaseOrders : System.Web.UI.Page
    {
        #region Properties and variables
        PurchaseordersBOL objPurchaseordersBOL = new PurchaseordersBOL();
        PurchaseordersManager objPurchaseordersManager = new PurchaseordersManager();
        OrdedetailsBOL objOrdedetailsBOL = new OrdedetailsBOL();
        OrdedetailsManager objOrdedetailsManager = new OrdedetailsManager();
        List<OrdedetailsBOL> lstOrdedetailsBOL = new List<OrdedetailsBOL>();

        public List<OrdedetailsBOL> LstOrdedetailsBOL
        {
            get
            {
                lstOrdedetailsBOL = (List<OrdedetailsBOL>)Session["LstOrdedetailsBOL"];
                if (lstOrdedetailsBOL == null)
                {
                    lstOrdedetailsBOL = new List<OrdedetailsBOL>();
                }
                return lstOrdedetailsBOL;
            }
            set
            {
                lstOrdedetailsBOL = value;
                Session["LstOrdedetailsBOL"] = lstOrdedetailsBOL;
            }
        }
        
        #endregion
        #region Methods and Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LstOrdedetailsBOL = null;
                LoadData();
                LoadSupplierData();
                LoadProductsDDL();
                LoadEmployeData();
            }
            LoadProductData();
        }
        public void LoadData()
        {
            gvPurchaseorders.DataSource = objPurchaseordersManager.Select(new PurchaseordersBOL());
            gvPurchaseorders.DataBind();
        }
        public void LoadProductData()
        {
            gvProducts.DataSource = LstOrdedetailsBOL;
            gvProducts.DataBind();
        }
        public void LoadSupplierData()
        {
            SuppliersManager objSuppliersManager = new SuppliersManager();
            ddlSupplierID.DataTextField = "CompanyName";
            ddlSupplierID.DataValueField = "SupplierID";
            ddlSupplierID.DataSource = objSuppliersManager.Select(new SuppliersBOL());
            ddlSupplierID.DataBind();

        }
        public void LoadEmployeData()
        {
            UsersManager objUsersManager = new UsersManager();
            ddlEmployee.DataTextField = "FirstName";
            ddlEmployee.DataValueField = "Userid";
            ddlEmployee.DataSource = objUsersManager.Select(new UsersBOL());
            ddlEmployee.DataBind();

        }
        public void LoadProductsDDL()
        {
            ProductsManager objUsersManager = new ProductsManager();
            ddlProducts.DataTextField = "ProductName";
            ddlProducts.DataValueField = "ProductID";
            ddlProducts.DataSource = objUsersManager.Select(new ProductsBOL());
            ddlProducts.DataBind();

        }
        
        public void GetData()
        {
            objPurchaseordersBOL.SupplierID = Convert.ToString(ddlSupplierID.SelectedValue);
            objPurchaseordersBOL.EmployeeID = Convert.ToInt32(ddlEmployee.SelectedValue);
            objPurchaseordersBOL.OrderDate = Convert.ToDateTime(txtOrderDate.Text);
            objPurchaseordersBOL.RequiredDate = Convert.ToDateTime(txtRequiredDate.Text);
            objPurchaseordersBOL.ShipName = Convert.ToString(txtShipName.Text);
            objPurchaseordersBOL.ShipAddress = Convert.ToString(txtShipAddress.Text);
            objPurchaseordersBOL.ShipCity = Convert.ToString(txtShipCity.Text);
            objPurchaseordersBOL.ShipCountry = Convert.ToString(txtShipCountry.Text);
        }
        public void SetData()
        {
            ddlSupplierID.SelectedValue = Convert.ToString(objPurchaseordersBOL.SupplierID);
            ddlEmployee.SelectedValue = Convert.ToString(objPurchaseordersBOL.EmployeeID);
            txtOrderDate.Text = Convert.ToString(objPurchaseordersBOL.OrderDate);
            txtRequiredDate.Text = Convert.ToString(objPurchaseordersBOL.RequiredDate);
            txtShipName.Text = Convert.ToString(objPurchaseordersBOL.ShipName);
            txtShipAddress.Text = Convert.ToString(objPurchaseordersBOL.ShipAddress);
            txtShipCity.Text = Convert.ToString(objPurchaseordersBOL.ShipCity);
            txtShipCountry.Text = Convert.ToString(objPurchaseordersBOL.ShipCountry);
        }
        public void GetDataOrderDetail()
        {
            objOrdedetailsBOL = new OrdedetailsBOL();
            objOrdedetailsBOL.OrderID = Convert.ToInt32(txtOrderID.Text);
            objOrdedetailsBOL.ProductID = Convert.ToInt32(ddlProducts.SelectedValue);
            objOrdedetailsBOL.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
            objOrdedetailsBOL.Quantity = Convert.ToInt32(txtQuantity.Text);
            objOrdedetailsBOL.Discount = Convert.ToDouble(txtDiscount.Text);
            objOrdedetailsBOL.OrderType = Convert.ToInt32(txtOrderType.Text);
            OrdedetailsBOL objTemp = (OrdedetailsBOL)objOrdedetailsBOL.Clone();
            List<OrdedetailsBOL> lstTmp = LstOrdedetailsBOL;
            lstTmp.Add(objTemp);
            LstOrdedetailsBOL = lstTmp;
            LoadProductData();
            
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GetData();
            int POID = objPurchaseordersManager.Insert(objPurchaseordersBOL);
            if (POID > 0 && LstOrdedetailsBOL != null && LstOrdedetailsBOL.Count > 0)
            {
                foreach (OrdedetailsBOL objOrderDetail in LstOrdedetailsBOL)
                {
                    objOrderDetail.OrderID = POID;
                    objOrderDetail.OrderType = ERPEnumerators.OrderType.PurchaseOrder.GetHashCode();
                    objOrdedetailsManager.Insert(objOrderDetail);
                }
            }
            LstOrdedetailsBOL = null;
            LoadProductData();
            LoadData();
        }
        protected void gvPurchaseorders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string poID = gvPurchaseorders.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView gvOrders = e.Row.FindControl("gvOrdedetails") as GridView;
                OrdedetailsBOL objOrdedetailsBOL = new OrdedetailsBOL();
                if (!string.IsNullOrEmpty(poID))
                {
                    objOrdedetailsBOL.OrderID = Convert.ToInt32(poID);
                    objOrdedetailsBOL.OrderType = ERPEnumerators.OrderType.PurchaseOrder.GetHashCode();                   
                    gvOrders.DataSource = objOrdedetailsManager.Select(objOrdedetailsBOL);
                    gvOrders.DataBind();
                }
            }
        }
        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            GetDataOrderDetail();
        }

        #endregion

        
        

       

    }
}