using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using System.Data;
using EntityLayer;

namespace HotalManagment
{
    public partial class HotelPlan : System.Web.UI.Page
    {
        DL_HotalManagment objHotalManagment = new DL_HotalManagment();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getControlData();
                btnsave.Text = "Add";
                BindGrid();
                ClearControl();
                hdnUpadteId.Value = "0";
            }
        }
        public void BindGrid()
        {
            DL_HotalManagment objDL_HotalManagment = new DL_HotalManagment();
            if (Session["UserId"] != null && Convert.ToInt32(Session["UserId"]) > 0)
            {
                DataSet ds = objDL_HotalManagment.GetHotelPlans(Convert.ToInt32(Session["UserId"]));
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    grdHotalPlan.DataSource = ds;
                    grdHotalPlan.DataBind();
                }
                else
                {
                    grdHotalPlan.DataSource = null;
                    grdHotalPlan.DataBind();
                }
            }
            pnlEdit.Attributes.Add("style", "display:none");
            pnlList.Attributes.Add("style", "display:block");
        }

        public void ClearControl()
        {
            ddlHotels.ClearSelection();
            ddlPlan.ClearSelection();
        }

        public void getControlData()
        {
            DataSet dsPlan = objHotalManagment.GetPlan(Convert.ToInt32(Session["UserId"]));
            ddlPlan.DataValueField = "Id";
            ddlPlan.DataTextField = "PlanName";
            ddlPlan.DataSource = dsPlan.Tables[0];
            ddlPlan.DataBind();
            ddlPlan.Items.Insert(0, new ListItem("Select Plans", "0"));


            DataSet ds = objHotalManagment.GetHotals(Convert.ToInt32(Session["UserId"]));
            ddlHotels.DataSource = ds;
            ddlHotels.DataValueField = "Id";
            ddlHotels.DataTextField = "HotelName";
            ddlHotels.DataBind();
            ddlHotels.Items.Insert(0, new ListItem("Select Hotels", "0"));



        }

        protected void ddlPlan_selectedIndexChanged(object sender, EventArgs e)
        {
            DL_HotalManagment objDL_HotalManagment = new DL_HotalManagment();
            if (Session["UserId"] != null && Convert.ToInt32(Session["UserId"]) > 0)
            {
                DataSet ds = objDL_HotalManagment.GetPlanDetail(Convert.ToInt32(ddlPlan.SelectedItem.Value));
                if (ds.Tables[0].Rows.Count>0)
                {
                    hdPrice.Value = ds.Tables[0].Rows[0]["Price"].ToString();
                    hdDuration.Value = ds.Tables[0].Rows[0]["Duration"].ToString();
                }
                pnlEdit.Attributes.Add("style", "display:block");
                pnlList.Attributes.Add("style", "display:none");
            }
        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            HotelPlanCls objHotelPlanCls = new HotelPlanCls();
            decimal price = Convert.ToDecimal(hdPrice.Value) ;
            int duration = Convert.ToInt32(hdDuration.Value);

            objHotelPlanCls.Id = Convert.ToInt32(hdnUpadteId.Value);
            objHotelPlanCls.PlanId = Convert.ToInt32(ddlPlan.SelectedValue);
            objHotelPlanCls.HotelId = Convert.ToInt32(ddlHotels.SelectedValue);
            objHotelPlanCls.Startdate = Convert.ToDateTime(txtStartAt.Text);
            objHotelPlanCls.EndDate = Convert.ToDateTime(txtStartAt.Text).AddDays(duration);
            objHotelPlanCls.Duration = duration;
            objHotelPlanCls.Price = price;
            int Response = 0;
            hdMessage.Value = "Hotal Plan |";
            DL_HotalManagment objDL_HotalManagment = new DL_HotalManagment();
            Response = objDL_HotalManagment.InsertUpdatePlan(objHotelPlanCls);
            if (Response > 0)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg();", true);
                hdMessage.Value += "Data saved successfully";
                ClearControl();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg();", true);
                hdMessage.Value += "Data not saved successfully please try again...";
            }


            btnsave.Text = "Add";
            BindGrid();
            ClearControl();
            hdnUpadteId.Value = "0";

        }

        protected void grdHouseKeeping_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pnlEdit.Attributes.Add("style", "display:block");
            pnlList.Attributes.Add("style", "display:none");

            int HotalId = Convert.ToInt32(((HiddenField)grdHotalPlan.Rows[e.NewEditIndex].FindControl("hdHotelId")).Value);
            int PlanId = Convert.ToInt32(((HiddenField)grdHotalPlan.Rows[e.NewEditIndex].FindControl("hdnPlanId")).Value);
            hdnUpadteId.Value = Convert.ToString(((HiddenField)grdHotalPlan.Rows[e.NewEditIndex].FindControl("hdnId")).Value);
            ddlPlan.SelectedValue = Convert.ToString(PlanId);
            ddlHotels.SelectedValue = Convert.ToString(HotalId);
            DateTime dt= Convert.ToDateTime(((Label)grdHotalPlan.Rows[e.NewEditIndex].FindControl("lblstartAt")).Text);
            txtStartAt.Text = dt.ToShortDateString();
            hdPrice.Value = ((Label)grdHotalPlan.Rows[e.NewEditIndex].FindControl("lblPrice")).Text;
            hdDuration.Value = ((Label)grdHotalPlan.Rows[e.NewEditIndex].FindControl("lblduration")).Text;

            btnsave.Text = "Update";
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            btnsave.Text = "Add";
            BindGrid();
            ClearControl();
            hdnUpadteId.Value = "0";
        }

    }
}