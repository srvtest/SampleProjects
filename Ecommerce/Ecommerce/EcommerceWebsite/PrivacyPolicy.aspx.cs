using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceWebsite
{
    public partial class PrivacyPolicy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShoWPanel(1);
                GetMasterPageById();
            }
        }

        private void GetMasterPageById()
        {
           // string Id = hdnPrivacyPolicyId.Value;            
            UserDL objUserCls = new UserDL();
            DataSet ds = objUserCls.GetMasterPageById(Convert.ToInt16(MasterStatus.PrivacyPolicy));
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                lstPrivacyPolicy.DataSource = ds.Tables[0];
                lstPrivacyPolicy.DataBind();
            }
        }

        protected void btnRefundPolicy_Click(object sender, EventArgs e)
        {
            ShoWPanel(2);
        }

        protected void btnBuyBackPolicy_Click(object sender, EventArgs e)
        {
            ShoWPanel(3);
        }

        protected void btnExchangePolicy_Click(object sender, EventArgs e)
        {
            ShoWPanel(4);
        }

        protected void btnShippingPolicy_Click(object sender, EventArgs e)
        {
            ShoWPanel(5);
        }

        protected void btnCancellationPolicy_Click(object sender, EventArgs e)
        {
            ShoWPanel(6);
        }

        private void ShoWPanel(int id)
        {
            pnlPrivacyPolicy.Visible = false;
            pnlRefundPolicy.Visible = false;
            pnlBuyBackPolicy.Visible = false;
            pnlCancellationPolicy.Visible = false;
            pnlExchangePolicy.Visible = false;
            pnlShippingPolicy.Visible = false;
            switch (id)
            {
                case 1:
                    pnlPrivacyPolicy.Visible = true;
                    break;
                case 2:
                    pnlRefundPolicy.Visible = true;
                   // string RefundPolicyId = hdnRefundPolicyId.Value;
                    UserDL objRefundPolicyCls = new UserDL();
                    DataSet dsRefundPolicy = objRefundPolicyCls.GetMasterPageById(Convert.ToInt16(MasterStatus.RefundPolicy));
                    if (dsRefundPolicy != null && dsRefundPolicy.Tables.Count > 0 && dsRefundPolicy.Tables[0].Rows.Count > 0)
                    {
                        lstRefundPolicy.DataSource = dsRefundPolicy.Tables[0];
                        lstRefundPolicy.DataBind();
                    }
                    break;
                case 3:
                    pnlBuyBackPolicy.Visible = true;
                   // string BuyBackPolicyId = hdnBuyBackPolicyId.Value;
                    UserDL objBuyBackPolicyCls = new UserDL();
                    DataSet dsBuyBackPolicy = objBuyBackPolicyCls.GetMasterPageById(Convert.ToInt16(MasterStatus.BuyBackPolicy));
                    if (dsBuyBackPolicy != null && dsBuyBackPolicy.Tables.Count > 0 && dsBuyBackPolicy.Tables[0].Rows.Count > 0)
                    {
                        lstBuyBackPolicy.DataSource = dsBuyBackPolicy.Tables[0];
                        lstBuyBackPolicy.DataBind();
                    }
                    break;
                case 4:
                    pnlExchangePolicy.Visible = true;
                   // string ExchangePolicyId = hdnExchangePolicyId.Value;
                    UserDL objExchangePolicyCls = new UserDL();
                    DataSet dsExchangePolicy = objExchangePolicyCls.GetMasterPageById(Convert.ToInt16(MasterStatus.ExchangePolicy));
                    if (dsExchangePolicy != null && dsExchangePolicy.Tables.Count > 0 && dsExchangePolicy.Tables[0].Rows.Count > 0)
                    {
                        lstExchangePolicy.DataSource = dsExchangePolicy.Tables[0];
                        lstExchangePolicy.DataBind();
                    }
                    break;
                case 5:
                    pnlShippingPolicy.Visible = true;
                   // string ShippingPolicyId = hdnShippingPolicyId.Value;
                    UserDL objShippingPolicyCls = new UserDL();
                    DataSet dsShippingPolicy = objShippingPolicyCls.GetMasterPageById(Convert.ToInt16(MasterStatus.ShippingPolicy));
                    if (dsShippingPolicy != null && dsShippingPolicy.Tables.Count > 0 && dsShippingPolicy.Tables[0].Rows.Count > 0)
                    {
                        lstShippingPolicy.DataSource = dsShippingPolicy.Tables[0];
                        lstShippingPolicy.DataBind();
                    }
                    break;
                case 6:
                    pnlCancellationPolicy.Visible = true;
                   // string CancellationPolicyId = hdnCancellationPolicyId.Value;
                    UserDL objCancellationPolicyCls = new UserDL();
                    DataSet dsCancellationPolicy = objCancellationPolicyCls.GetMasterPageById(Convert.ToInt16(MasterStatus.CancellationPolicy));
                    if (dsCancellationPolicy != null && dsCancellationPolicy.Tables.Count > 0 && dsCancellationPolicy.Tables[0].Rows.Count > 0)
                    {
                        lstCancellationPolicy.DataSource = dsCancellationPolicy.Tables[0];
                        lstCancellationPolicy.DataBind();
                    }
                    break;
                default:
                    break;
            }

        }
    }
}