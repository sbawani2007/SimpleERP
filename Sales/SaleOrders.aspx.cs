using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERP.BOL;
using ERP.Manager;
using GenericFunctions;

namespace SimpleERP.Sales
{
    public partial class SaleOrders : System.Web.UI.Page
    {
        #region Properties and variables
        SalesordersBOL objSalesordersBOL1 = new SalesordersBOL();
        SalesordersManager objSalesordersManager = new SalesordersManager();
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
        List<CustomersBOL> lstCustomersBOL = new List<CustomersBOL>();
        public List<CustomersBOL> LstCustomersBOL
        {
            get
            {
                lstCustomersBOL = (List<CustomersBOL>)Session["LstCustomersBOL"];
                if (lstCustomersBOL == null)
                {
                    lstCustomersBOL = new List<CustomersBOL>();
                }
                return lstCustomersBOL;
            }
            set
            {
                lstCustomersBOL = value;
                Session["LstCustomersBOL"] = lstCustomersBOL;
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
                LoadCustomerData();
                LoadEmployeData();
                LoadProductsDDL();
            }

            LoadProductData();
        }
        public void LoadData()
        {
            gvSalesorders.DataSource = objSalesordersManager.Select(new SalesordersBOL());
            gvSalesorders.DataBind();
        }
        public void LoadProductData()
        {
            gvProducts.DataSource = LstOrdedetailsBOL;
            gvProducts.DataBind();
        }
        public void LoadCustomerData()
        {
            CustomersManager objCustomersManager = new CustomersManager();
            ddlCustomerID.DataTextField = "CompanyName";
            ddlCustomerID.DataValueField = "CustomerID";
            ddlCustomerID.DataSource = objCustomersManager.Select(new CustomersBOL());           
            ddlCustomerID.DataBind();

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
            objSalesordersBOL1.CustomerID = Convert.ToString(ddlCustomerID.SelectedValue);
            objSalesordersBOL1.EmployeeID = Convert.ToInt32(ddlEmployee.SelectedValue);
            objSalesordersBOL1.OrderDate = Convert.ToDateTime(txtOrderDate.Text);
            objSalesordersBOL1.RequiredDate = Convert.ToDateTime(txtRequiredDate.Text);
            objSalesordersBOL1.ShipName = Convert.ToString(txtShipName.Text);
            objSalesordersBOL1.ShipAddress = Convert.ToString(txtShipAddress.Text);
            objSalesordersBOL1.ShipCity = Convert.ToString(txtShipCity.Text);
            objSalesordersBOL1.ShipCountry = Convert.ToString(txtShipCountry.Text);
        }
        public void SetData()
        {
            ddlCustomerID.SelectedValue = Convert.ToString(objSalesordersBOL1.CustomerID);
            ddlEmployee.SelectedValue = Convert.ToString(objSalesordersBOL1.EmployeeID);
            txtOrderDate.Text = Convert.ToString(objSalesordersBOL1.OrderDate);
            txtRequiredDate.Text = Convert.ToString(objSalesordersBOL1.RequiredDate);
            txtShipName.Text = Convert.ToString(objSalesordersBOL1.ShipName);
            txtShipAddress.Text = Convert.ToString(objSalesordersBOL1.ShipAddress);
            txtShipCity.Text = Convert.ToString(objSalesordersBOL1.ShipCity);
            txtShipCountry.Text = Convert.ToString(objSalesordersBOL1.ShipCountry);
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
            int POID = objSalesordersManager.Insert(objSalesordersBOL1);
            if (POID > 0 && LstOrdedetailsBOL != null && LstOrdedetailsBOL.Count > 0)
            {
                foreach (OrdedetailsBOL objOrderDetail in LstOrdedetailsBOL)
                {
                    objOrderDetail.OrderID = POID;
                    objOrderDetail.OrderType = ERPEnumerators.OrderType.SalesOrder.GetHashCode();
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
                string salesID = gvSalesorders.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView gvOrders = e.Row.FindControl("gvOrdedetails") as GridView;
                OrdedetailsBOL objOrdedetailsBOL = new OrdedetailsBOL();
                if (!string.IsNullOrEmpty(salesID))
                {
                    objOrdedetailsBOL.OrderID = Convert.ToInt32(salesID);
                    objOrdedetailsBOL.OrderType = ERPEnumerators.OrderType.SalesOrder.GetHashCode();
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