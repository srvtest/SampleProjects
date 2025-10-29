using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class DiscountCoupon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCountryDDL();
                GetDiscountCoupon();
                resetControl();
                frmDiscountCoupon.Style.Add("display", "none");
            }
        }

        private void BindCountryDDL()
        {
            List<ListItem> lstCountry = new List<ListItem>() {
               new ListItem() { Text="India", Value="1", Selected=true },
               new ListItem() { Text="USA", Value="2"}
            };
            ddlCountry.DataSource = lstCountry;
            ddlCountry.DataTextField = "Text";
            ddlCountry.DataValueField = "Value";
            ddlCountry.DataBind();
            ddlCountry.SelectedValue = "1";
        }

        private void GetDiscountCoupon()
        {
            AdminDL objAdminCls = new AdminDL();
            rptDiscountCoupon.DataSource = null;
            DataSet ds = objAdminCls.GetAllDiscountCoupon();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                rptDiscountCoupon.DataSource = ds.Tables[0];
                rptDiscountCoupon.DataBind();
            }
        }

        private void resetControl()
        {
            txtName.Text = "";
            txtCouponValue.Text = "";
            txtFrom.Text = "";
            txtTo.Text = "";
            txtMinCartValue.Text = "";
            txtMaxDiscountValue.Text = "";
            txtDescription.Text = "";
            chkStatus.Checked = false;
            frmDiscountCoupon.Style.Add("display", "none");
            tblDiscountCoupon.Style.Add("display", "inline");
        }

        protected void rptDiscountCoupon_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                AdminDL objAdminCls = new AdminDL();
                DataSet ds = objAdminCls.GetDiscountCoupon(Convert.ToInt32(e.CommandArgument));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lblbStatus.Text = Convert.ToBoolean(ds.Tables[0].Rows[0]["bActive"]) ? "Active" : "Inactive";
                    txtName.Text = Convert.ToString(ds.Tables[0].Rows[0]["sName"]);
                    txtCouponValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["CouponValue"]);
                    txtFrom.Text = Convert.ToString(ds.Tables[0].Rows[0]["PeriodFrom"]);
                    txtTo.Text = Convert.ToString(ds.Tables[0].Rows[0]["PeriodTo"]);
                    txtMinCartValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["MinCartValue"]);
                    txtMaxDiscountValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["MaxDisCountValue"]);
                    txtDescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["Description"]);
                    chkStatus.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["bActive"]);
                    ddlCountry.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["idCountry"]);

                    frmDiscountCoupon.Style.Add("display", "flex");
                    tblDiscountCoupon.Style.Add("display", "none");
                }
                hdnDiscountCouponId.Value = Convert.ToString(e.CommandArgument);
            }
            else if (e.CommandName == "Delete")
            {
                DeleteDiscountCoupon(Convert.ToInt32(e.CommandArgument));
            }
        }

        private void DeleteDiscountCoupon(int Id)
        {
            DiscountCouponCls objDiscountCouponCls = new DiscountCouponCls();
            objDiscountCouponCls.idCoupon = Id;
            objDiscountCouponCls.isDelete = 1;
            AdminDL objAdminCls = new AdminDL();
            hdMessage.Value = "Discount Coupon Delete |";
            int Response = objAdminCls.InsertUpdateDelteDiscountCoupon(objDiscountCouponCls);
            if (Response > 0)
            {
                hdMessage.Value += "Discount Coupon Delete successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
                frmDiscountCoupon.Style.Add("display", "none");
                tblDiscountCoupon.Style.Add("display", "block");
                GetDiscountCoupon();
            }
            else if (Response == 0)
            {
                hdMessage.Value += "Discount Coupon does not exists.";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
        }

        protected void btnSaveDiscountCoupon_Click(object sender, EventArgs e)
        {
            DiscountCouponCls objDiscountCouponCls = new DiscountCouponCls();
            objDiscountCouponCls.sName = txtName.Text;
            objDiscountCouponCls.CouponValue = Convert.ToDecimal(txtCouponValue.Text.Trim());
            objDiscountCouponCls.PeriodFrom = Convert.ToDateTime(txtFrom.Text.Trim());
            objDiscountCouponCls.PeriodTo = Convert.ToDateTime(txtTo.Text.Trim());
            objDiscountCouponCls.MinCartValue = Convert.ToDecimal(txtMinCartValue.Text);
            objDiscountCouponCls.MaxDisCountValue = Convert.ToDecimal(txtMaxDiscountValue.Text.Trim());
            objDiscountCouponCls.Description = txtDescription.Text.Trim();
            objDiscountCouponCls.bActive = (Int16)(chkStatus.Checked ? 1 : 0);
            objDiscountCouponCls.idCoupon = Convert.ToInt32(hdnDiscountCouponId.Value);
            objDiscountCouponCls.idCountry = Convert.ToInt32(ddlCountry.SelectedValue);
            
            AdminDL objAdminCls = new AdminDL();
            if (Convert.ToInt32(hdnDiscountCouponId.Value) > 0)
            {
                hdMessage.Value = "Discount Coupon Update |";
                objDiscountCouponCls.ModifiedBy = Convert.ToInt32(Session["UserId"]);
            }
            else
            {
                hdMessage.Value = "Discount Coupon Insert |";
                objDiscountCouponCls.CreatedBy = Convert.ToInt32(Session["UserId"]);
            }
            int Response = objAdminCls.InsertUpdateDelteDiscountCoupon(objDiscountCouponCls);
            if (Response > 0)
            {
                GetDiscountCoupon();
                hdMessage.Value += "Data saved successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
                frmDiscountCoupon.Style.Add("display", "none");
                tblDiscountCoupon.Style.Add("display", "block");
            }
            else if (Response == 0)
            {
                hdMessage.Value += "Data not saved. Because already exists.";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
        }

        protected void btnCancelDiscountCoupon_Click(object sender, EventArgs e)
        {
            frmDiscountCoupon.Style.Add("display", "none");
            tblDiscountCoupon.Style.Add("display", "inline");
        }

        protected void btnDiscountCoupon_Click(object sender, EventArgs e)
        {
            resetControl();
            frmDiscountCoupon.Style.Add("display", "flex");
            tblDiscountCoupon.Style.Add("display", "none");
        }
    }
}