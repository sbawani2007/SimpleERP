using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERP.BOL;
using ERP.Manager;
using System.Data;

namespace SimpleERP.Reports
{
    public partial class CashTransactionReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadReport();
        }
        public void LoadReport()
        {
            SalesordersManager objSalesordersManager = new SalesordersManager();
            gvCash.DataSource = objSalesordersManager.SelectCashReport(new SalesordersBOL());
            gvCash.DataBind();
            DataSet ds = (DataSet)gvCash.DataSource;
            double debit =0.0;
            double credit = 0.0;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    debit = debit + Convert.ToDouble(Convert.ToString(dr["Debit"]));
                    credit = credit + Convert.ToDouble(Convert.ToString(dr["credit"]));
                }
            }
            lblCredit.Text = credit.ToString();
            lblDebit.Text = debit.ToString();
            lblCalculation.Text = Convert.ToString(debit - credit);
        }
    }
}