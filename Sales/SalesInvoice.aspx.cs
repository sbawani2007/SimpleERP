using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERP.BOL;
using ERP.Manager;
using System.Data;

namespace SimpleERP.Sales
{
    public partial class SalesInvoice : System.Web.UI.Page
    {
        #region Properties and variables
        SalesordersBOL objSalesordersBOL = new SalesordersBOL();

        public SalesordersBOL ObjSalesordersBOL
        {
            get
            {
                if (Session["ObjSalesordersBOL"] != null)
                {
                    objSalesordersBOL = (SalesordersBOL)Session["ObjSalesordersBOL"];
                }
                return objSalesordersBOL;
            }
            set
            {
                objSalesordersBOL = value;
                Session["ObjSalesordersBOL"] = objSalesordersBOL;
            }
        }
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
        List<SalesordersBOL> lstSalesordersBOL;
        public List<SalesordersBOL> LstSalesordersBOL
        {
            get
            {
                lstSalesordersBOL = (List<SalesordersBOL>)Session["LstSalesordersBOL"];
                return lstSalesordersBOL;
            }
            set
            {
                lstSalesordersBOL = value;
                Session["LstSalesordersBOL"] = lstSalesordersBOL;
            }
        }
        InvoicesBOL objInvoicesBOL = new InvoicesBOL();
        InvoicesManager objInvoicesManager = new InvoicesManager();

        #endregion

        #region Invoice

        public void LoadDataInvoice()
        {
            InvoicesBOL tmp = new InvoicesBOL();
            tmp.InvoiceType = GenericFunctions.ERPEnumerators.OrderType.SalesOrder.GetHashCode();
            gvInvoices.DataSource = objInvoicesManager.Select(tmp);
            gvInvoices.DataBind();
        }
        public void GetDataInvoice()
        {
            objInvoicesBOL.InvoiceNumber = Convert.ToString(txtInvoiceNumber.Text);
            objInvoicesBOL.InvoiceType = GenericFunctions.ERPEnumerators.OrderType.SalesOrder.GetHashCode();//for sale; //Convert.ToInt32(txtInvoiceType.Text);
            objInvoicesBOL.OrderID = ObjSalesordersBOL.SalesOrderID; //Convert.ToInt32(txtOrderID.Text);
            objInvoicesBOL.Refference = Convert.ToString(txtRefference.Text);
            objInvoicesBOL.PayType = Convert.ToInt32(ddlPayType.SelectedValue);
            objInvoicesBOL.ChequeNumber = Convert.ToString(txtChequeNumber.Text);
            objInvoicesBOL.TotalAmount = Convert.ToDouble(txtTotalAmount.Text);
            objInvoicesBOL.OrderAmount = Convert.ToDouble(txtOrderAmount.Text);
            objInvoicesBOL.InvoiceDate = Convert.ToDateTime(txtInvoiceDate.Text);
        }
        public void SetDataInvoice()
        {
            txtInvoiceNumber.Text = Convert.ToString(objInvoicesBOL.InvoiceNumber);
            txtInvoiceType.Text = Convert.ToString(objInvoicesBOL.InvoiceType);
            txtOrderID.Text = Convert.ToString(objInvoicesBOL.OrderID);
            txtRefference.Text = Convert.ToString(objInvoicesBOL.Refference);
            ddlPayType.SelectedValue = Convert.ToString(objInvoicesBOL.PayType);
            txtChequeNumber.Text = Convert.ToString(objInvoicesBOL.ChequeNumber);
            txtTotalAmount.Text = Convert.ToString(objInvoicesBOL.TotalAmount);
            txtOrderAmount.Text = Convert.ToString(objInvoicesBOL.OrderAmount);
            txtInvoiceDate.Text = Convert.ToString(objInvoicesBOL.InvoiceDate);
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ObjSalesordersBOL != null)
            {
                GetDataInvoice();
                objInvoicesManager.Insert(objInvoicesBOL);
                LstOrdedetailsBOL = null;
                Server.TransferRequest("SalesInvoice.aspx");
            }
        }

        #endregion

        #region Methods and Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LstOrdedetailsBOL = null;
                LoadSalesOrdersData();
                LoadCustomerData();
                LoadEmployeData();
                LoadDataInvoice();
            }
        }
        public List<SalesordersBOL> LoadSalesOrdersData()
        {
            LstSalesordersBOL = objSalesordersManager.LoadSalesOrdersData(new SalesordersBOL());
            //string orderIDs = string.Empty;
            if (LstSalesordersBOL != null && LstSalesordersBOL.Count > 0)
            {
                //foreach (SalesordersBOL obj in LstSalesordersBOL)
                //{
                //    orderIDs += obj.SalesOrderID.ToString() + ",";
                //}
                //if (!string.IsNullOrEmpty(orderIDs))
                {
                    LstOrdedetailsBOL = objOrdedetailsManager.LoadOrdedetailsData(new OrdedetailsBOL());
                    if (LstOrdedetailsBOL != null && LstOrdedetailsBOL.Count > 0)
                    {
                        foreach (SalesordersBOL objSOB in LstSalesordersBOL)
                        {
                            objSOB.LstOrdedetailsBOL = (List<OrdedetailsBOL>)LstOrdedetailsBOL.FindAll(t => t.OrderID == objSOB.SalesOrderID).ToList();
                        }
                    }
                }
                gvSalesorders.DataSource = LstSalesordersBOL;
                gvSalesorders.DataBind();
            }
            return LstSalesordersBOL;
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
        public void SetData(SalesordersBOL objSalesordersBOL1)
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

        protected void gvSalesorders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string salesOrderID = e.CommandArgument.ToString();
            if (!string.IsNullOrEmpty(salesOrderID) && Convert.ToInt32(salesOrderID) > 0)
            {
                SalesordersBOL objSO = (SalesordersBOL)LstSalesordersBOL.Find(t => t.SalesOrderID == Convert.ToInt32(salesOrderID));
                SetData(objSO);
                gvProducts.DataSource = objSO.LstOrdedetailsBOL;
                gvProducts.DataBind();
                ObjSalesordersBOL = (SalesordersBOL)objSO.Clone();
            }
            
        }

        protected void gvSalesorders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gvOrders = e.Row.FindControl("gvOrdedetails") as GridView;
                string salesID = gvSalesorders.DataKeys[e.Row.RowIndex].Value.ToString();
                gvOrders.DataSource = LstSalesordersBOL.Find(t => t.SalesOrderID == Convert.ToInt32(salesID)).LstOrdedetailsBOL;
                gvOrders.DataBind();
            }
        }
        #endregion
    }
}