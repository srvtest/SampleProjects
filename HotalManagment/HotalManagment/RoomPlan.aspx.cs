using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using EntityLayer;
using System.Data;


namespace HotalManagment
{
    public partial class RoomPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Type"] != null && Convert.ToInt32(Session["Type"]) == 1)
            //{
            //    Response.Redirect("MainDashBoard.aspx");
            //}
            if (!IsPostBack)
            {
                btnsave.Text = "Add";
                getRoomPlan();
                ClearControl();
                hdCategoryId.Value = "0";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            RoomPlanCls roomPlan = new RoomPlanCls();
            if (Convert.ToInt32(hdCategoryId.Value) > 0)
            {
                hdMessage.Value = "Room Plan Update |";
                roomPlan.Id = Convert.ToInt32(hdCategoryId.Value);
                roomPlan.ModifyBy = Convert.ToInt32(Session["UserId"]);
                roomPlan.CreatedBy = Convert.ToInt32(Session["UserId"]);
            }
            else
            {
                hdMessage.Value = "Room Plan Insert |";
                roomPlan.Id = 0;
                roomPlan.CreatedBy = Convert.ToInt32(Session["UserId"]);
            }
            roomPlan.RoomPlanName = txtRoomPlan.Text.Trim();
            roomPlan.IsActive = chkStatus.Checked;
            int Response = objHotalManagment.SetRoomPlan(roomPlan);
            if (Response > 0)
            {
                ClearControl();
                hdMessage.Value += "Data saved successfully";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
            }
            else if (Response == 0)
            {
                hdMessage.Value += "Data not saved. Because category already exists.";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
            else
            {
                hdMessage.Value += "Data not saved successfully please try again...";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
            btnsave.Text = "Add";
            getRoomPlan();
            ClearControl();
            hdCategoryId.Value = "0";
        }

        public void getRoomPlan()
        {
            grdCategory.AutoGenerateColumns = false;
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            DataSet ds = objHotalManagment.GetAllRoomPlan(Convert.ToInt32(Session["UserId"]));
            grdCategory.DataSource = ds.Tables[0];
            grdCategory.DataBind();
            pnlEdit.Attributes.Add("style", "display:none");
            pnlList.Attributes.Add("style", "display:block");
        }

        protected void grdCategory_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pnlEdit.Attributes.Add("style", "display:block");
            pnlList.Attributes.Add("style", "display:none");
            status.Attributes.Add("style", "display:block");
            hdCategoryId.Value = Convert.ToString(((HiddenField)grdCategory.Rows[e.NewEditIndex].FindControl("hdnId")).Value);
            txtRoomPlan.Text = ((Label)grdCategory.Rows[e.NewEditIndex].FindControl("lblCategoryName")).Text;
            chkStatus.Checked = Convert.ToString(((HiddenField)grdCategory.Rows[e.NewEditIndex].FindControl("hdnStatusId")).Value) == "True";
            btnsave.Text = "Update";
        }

        public string GetStatusClass(bool status)
        {
            string className = string.Empty;
            if (status)
            {
                className = "label label-success";
            }
            else
            {
                className = "label label-warning";
            }
            return className;
        }

        public void ClearControl()
        {
            hdCategoryId.Value = "0";
            txtRoomPlan.Text = "";
            chkStatus.Checked = true;
            hdMessage.Value = "";
            status.Attributes.Add("style", "display:none");
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            btnsave.Text = "Add";
            getRoomPlan();
            ClearControl();
            hdCategoryId.Value = "0";
        }
    }
}