using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERP.BOL;
using ERP.Manager;
using System.Data;

namespace SimpleERP.Purchase
{
    public partial class PurchaseInvoice : System.Web.UI.Page
    {
        #region Properties and variables
        PurchaseordersBOL objPurchaseordersBOL = new PurchaseordersBOL();

        public PurchaseordersBOL ObjPurchaseordersBOL
        {
            get
            {
                if (Session["ObjPurchaseordersBOL"] != null)
                {
                    objPurchaseordersBOL = (PurchaseordersBOL)Session["ObjPurchaseordersBOL"];
                }
                return objPurchaseordersBOL;
            }
            set
            {
                objPurchaseordersBOL = value;
                Session["ObjPurchaseordersBOL"] = objPurchaseordersBOL;
            }
        }
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
        List<SuppliersBOL> lstSuppliersBOL = new List<SuppliersBOL>();
        public List<SuppliersBOL> LstSuppliersBOL
        {
            get
            {
                lstSuppliersBOL = (List<SuppliersBOL>)Session["LstSuppliersBOL"];
                if (lstSuppliersBOL == null)
                {
                    lstSuppliersBOL = new List<SuppliersBOL>();
                }
                return lstSuppliersBOL;
            }
            set
            {
                lstSuppliersBOL = value;
                Session["LstSuppliersBOL"] = lstSuppliersBOL;
            }
        }
        List<PurchaseordersBOL> lstPurchaseordersBOL;
        public List<PurchaseordersBOL> LstPurchaseordersBOL
        {
            get
            {
                lstPurchaseordersBOL = (List<PurchaseordersBOL>)Session["LstPurchaseordersBOL"];
                return lstPurchaseordersBOL;
            }
            set
            {
                lstPurchaseordersBOL = value;
                Session["LstPurchaseordersBOL"] = lstPurchaseordersBOL;
            }
        }
        InvoicesBOL objInvoicesBOL = new InvoicesBOL();
        InvoicesManager objInvoicesManager = new InvoicesManager();

        #endregion

        #region Invoice

        public void LoadDataInvoice()
        {
            InvoicesBOL tmp = new InvoicesBOL();
            tmp.InvoiceType = GenericFunctions.ERPEnumerators.OrderType.PurchaseOrder.GetHashCode();
            gvInvoices.DataSource = objInvoicesManager.Select(tmp);
            gvInvoices.DataBind();
        }
        public void GetDataInvoice()
        {
            objInvoicesBOL.InvoiceNumber = Convert.ToString(txtInvoiceNumber.Text);
            objInvoicesBOL.InvoiceType = GenericFunctions.ERPEnumerators.OrderType.PurchaseOrder.GetHashCode();//for sale; //Convert.ToInt32(txtInvoiceType.Text);
            objInvoicesBOL.OrderID = ObjPurchaseordersBOL.PurchaseOrderID; //Convert.ToInt32(txtOrderID.Text);
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
            if (ObjPurchaseordersBOL != null)
            {
                GetDataInvoice();
                objInvoicesManager.Insert(objInvoicesBOL);
                LstOrdedetailsBOL = null;
                Server.TransferRequest("PurchaseInvoice.aspx");
            
            }
        }

        #endregion

        #region Methods and Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadSalesOrdersData();
                LoadSupplierData();
                LoadEmployeData();
                LoadDataInvoice();
            }
        }
        public List<PurchaseordersBOL> LoadSalesOrdersData()
        {
            LstPurchaseordersBOL = objPurchaseordersManager.LoadPurchaseordersData(new PurchaseordersBOL());
            //string orderIDs = string.Empty;
            if (LstPurchaseordersBOL != null && LstPurchaseordersBOL.Count > 0)
            {
                //foreach (PurchaseordersBOL obj in LstPurchaseordersBOL)
                //{
                //    orderIDs += obj.SalesOrderID.ToString() + ",";
                //}
                //if (!string.IsNullOrEmpty(orderIDs))
                {
                    LstOrdedetailsBOL = objOrdedetailsManager.LoadOrdedetailsData(new OrdedetailsBOL());
                    if (LstOrdedetailsBOL != null && LstOrdedetailsBOL.Count > 0)
                    {
                        foreach (PurchaseordersBOL objSOB in LstPurchaseordersBOL)
                        {
                            objSOB.LstOrdedetailsBOL = (List<OrdedetailsBOL>)LstOrdedetailsBOL.FindAll(t => t.OrderID == objSOB.PurchaseOrderID).ToList();
                        }
                    }
                }
                gvPurchaseOrder.DataSource = LstPurchaseordersBOL;
                gvPurchaseOrder.DataBind();
            }
            return LstPurchaseordersBOL;
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
        public void SetData(PurchaseordersBOL objPurchaseordersBOL1)
        {
            ddlSupplierID.SelectedValue = Convert.ToString(objPurchaseordersBOL1.SupplierID);
            ddlEmployee.SelectedValue = Convert.ToString(objPurchaseordersBOL1.EmployeeID);
            txtOrderDate.Text = Convert.ToString(objPurchaseordersBOL1.OrderDate);
            txtRequiredDate.Text = Convert.ToString(objPurchaseordersBOL1.RequiredDate);
            txtShipName.Text = Convert.ToString(objPurchaseordersBOL1.ShipName);
            txtShipAddress.Text = Convert.ToString(objPurchaseordersBOL1.ShipAddress);
            txtShipCity.Text = Convert.ToString(objPurchaseordersBOL1.ShipCity);
            txtShipCountry.Text = Convert.ToString(objPurchaseordersBOL1.ShipCountry);
        }

        protected void gvPurchaseOrder_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string OrderID = e.CommandArgument.ToString();
            if (!string.IsNullOrEmpty(OrderID) && Convert.ToInt32(OrderID) > 0)
            {
                PurchaseordersBOL objSO = (PurchaseordersBOL)LstPurchaseordersBOL.Find(t => t.PurchaseOrderID == Convert.ToInt32(OrderID));
                SetData(objSO);
                gvProducts.DataSource = objSO.LstOrdedetailsBOL;
                gvProducts.DataBind();
                ObjPurchaseordersBOL = (PurchaseordersBOL)objSO.Clone();
            }

        }

        protected void gvPurchaseOrder_RowCommand(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gvOrders = e.Row.FindControl("gvOrdedetails") as GridView;
                string orderID = gvPurchaseOrder.DataKeys[e.Row.RowIndex].Value.ToString();
                gvOrders.DataSource = LstPurchaseordersBOL.Find(t => t.PurchaseOrderID == Convert.ToInt32(orderID)).LstOrdedetailsBOL;
                gvOrders.DataBind();
            }
        }
        #endregion
    }
}