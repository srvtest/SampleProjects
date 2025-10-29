using DataLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceWebsite
{
    public partial class OrderHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
                int pageSize = Convert.ToInt16(ConfigurationManager.AppSettings["OrderPageSize"]);
                int pageNo = Convert.ToInt32(hdPageNo.Value);
                GetOrders(idCustomer, pageSize, pageNo);
            }
                
        }

        private void GetOrders(int idCustomer,int pageSize, int pageNo)
        {
            int recordCount = 0;
            UserDL objUserDL = new UserDL();
            DataSet ds = objUserDL.GetAllOrder(idCustomer, pageSize, pageNo);
            if (ds != null)
            {
                ViewState["AllOrder"] = ds;
                if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                {

                    rptOrder.DataSource = ds.Tables[2];
                    rptOrder.DataBind();
                }
                if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    recordCount = Convert.ToInt32(ds.Tables[1].Rows[0]["RecordCount"]);
                }
            }
            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    ViewState["AllOrder"] = ds;
            //    rptOrder.DataSource = ds.Tables[0];
            //    rptOrder.DataBind();
            //}
            double dPageCount = (double)((decimal)recordCount / Convert.ToDecimal(pageSize));
            int iPageCount = (int)Math.Ceiling(dPageCount);
            ViewState["iPageCount"] = iPageCount;
            List<ListItem> lPages = new List<ListItem>();
            if (iPageCount > 0)
            {
                for (int i = 1; i <= iPageCount; i++)
                    lPages.Add(new ListItem(i.ToString(), i.ToString(), i != pageNo));
            }
            rptPagination.DataSource = lPages;
            rptPagination.DataBind();
        }

        protected void rptOrder_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater lstCountryConfig = e.Item.FindControl("rptOrderproduct") as Repeater;

            HiddenField hdnidOrder = e.Item.FindControl("hdnidOrder") as HiddenField;

            AdminDL objAdminCls = new AdminDL();
            DataSet ds = (DataSet)ViewState["AllOrder"];
            ds.Tables[0].DefaultView.RowFilter = "idCustomerOrder = " + hdnidOrder.Value;
            DataTable dt = (ds.Tables[0].DefaultView).ToTable();
            lstCountryConfig.DataSource = dt;
            lstCountryConfig.DataBind();
        }

        protected void rptPagination_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int pageSize = Convert.ToInt16(ConfigurationManager.AppSettings["OrderPageSize"]);
            int idCustomer = Convert.ToInt32(CommonControl.Decrypt(Convert.ToString(Session["CustomerId"])));
            //HiddenField hdnidOrder = e.Item.FindControl("hdnidOrder") as HiddenField;
            //int customerID = Convert.ToInt32(hdnidOrder.Value);
            int pageNum = Convert.ToInt32(e.CommandArgument);
            if (pageNum == -1)
            {
                pageNum = 1;
            }
            else if (pageNum == -2)
            {
                pageNum = (int)ViewState["iPageCount"];
            }

            hdPageNo.Value = pageNum.ToString();
            GetOrders(idCustomer, pageSize, pageNum);
        }
    }
}