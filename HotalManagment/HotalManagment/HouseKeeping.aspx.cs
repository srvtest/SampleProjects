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
    public partial class HouseKeeping : System.Web.UI.Page
    {
        DL_HotalManagment objHotalManagment = new DL_HotalManagment();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Type"] != null && Convert.ToInt32(Session["Type"]) == 1)
            {
                Response.Redirect("MainDashBoard.aspx");
            }
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
                DataSet ds = objDL_HotalManagment.GetHouseKeepingRooms(Convert.ToInt32(Session["UserId"]));
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    grdHouseKeeping.DataSource = ds;
                    grdHouseKeeping.DataBind();
                }
                else
                {
                    grdHouseKeeping.DataSource = null;
                    grdHouseKeeping.DataBind();
                }
            }
            pnlEdit.Attributes.Add("style", "display:none");
            pnlList.Attributes.Add("style", "display:block");
        }
        public void BindRoomNo(int roomNo = 0, int roomId = 0)
        {
                DL_HotalManagment objDL_HotalManagment = new DL_HotalManagment();
                if (Session["UserId"] != null && Convert.ToInt32(Session["UserId"]) > 0)
                {
                    DataSet ds = objDL_HotalManagment.GetRoomNoNotBookedByCategory(Convert.ToInt32(Session["UserId"]), Convert.ToInt32(ddlCategory.SelectedValue));
                    ddlRoomNo.DataSource = ds;
                    ddlRoomNo.DataValueField = "Id";
                    ddlRoomNo.DataTextField = "RoomNo";
                    ddlRoomNo.DataBind();
                    ddlRoomNo.Items.Insert(0, new ListItem("Select RoomNo", "0"));
                    if (roomId > 0)
                    {
                        ddlRoomNo.Items.Insert(1, new ListItem(Convert.ToString(roomNo), Convert.ToString(roomId)));
                    }
                    if (ds.Tables[0].Rows.Count>0)
                    {
                        pnlEdit.Attributes.Add("style", "display:block");
                        pnlList.Attributes.Add("style", "display:none");    
                    }
                }
        }
        public void ClearControl()
        {
            chkStatus.Checked = true;
            ddlRoomNo.ClearSelection();
            ddlCategory.ClearSelection();
            ddlCategory_selectedIndexChanged(null, null);
            ddlRoomNo.Enabled = true;
            ddlCategory.Enabled = true;
        }

        public void getControlData()
        {
            DataSet dsCategory = objHotalManagment.GetAllCategory(Convert.ToInt32(Session["UserId"]));
            ddlCategory.DataValueField = "Id";
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataSource = dsCategory.Tables[0];
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("Select Category", "0"));
            ddlRoomNo.Items.Insert(0, new ListItem() { Text = "Select RoomNo", Value = "0" });
        }

        protected void ddlCategory_selectedIndexChanged(object sender, EventArgs e)
        {
            ddlRoomNo.DataSource = null;
            ddlRoomNo.DataBind();
            BindRoomNo();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            RoomCls objRoomCls = new RoomCls();
            objRoomCls.IsUnderHK = Convert.ToInt16(chkStatus.Checked);
            objRoomCls.Id = Convert.ToInt32(ddlRoomNo.SelectedValue);
            objRoomCls.CategoryId = Convert.ToInt32(ddlCategory.SelectedIndex);
            int Response = 0;
            hdMessage.Value = "House Keeping |";
            DL_HotalManagment objDL_HotalManagment = new DL_HotalManagment();
            if (objRoomCls.Id > 0)
            {
                Response = objDL_HotalManagment.UpdateHouseKeepingsRoom(objRoomCls);
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
        }

        protected void grdHouseKeeping_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pnlEdit.Attributes.Add("style", "display:block");
            pnlList.Attributes.Add("style", "display:none");
            status.Attributes.Add("style", "display:block");
            int RoomId = Convert.ToInt32(((HiddenField)grdHouseKeeping.Rows[e.NewEditIndex].FindControl("hdnId")).Value);
            int roomNo = Convert.ToInt32(((Label)grdHouseKeeping.Rows[e.NewEditIndex].FindControl("lblRoomNo")).Text);
            int CategoryId = Convert.ToInt32(((HiddenField)grdHouseKeeping.Rows[e.NewEditIndex].FindControl("hdnCategoryId")).Value);

            ddlCategory.SelectedValue = Convert.ToString(CategoryId);
            BindRoomNo(roomNo, RoomId);
            ddlRoomNo.SelectedValue = Convert.ToString(RoomId);
            chkStatus.Checked = Convert.ToString(((HiddenField)grdHouseKeeping.Rows[e.NewEditIndex].FindControl("hdnStatusId")).Value) == "True";

            btnsave.Text = "Update";
        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            btnsave.Text = "Add";
            BindGrid();
            ClearControl();
            hdnUpadteId.Value = "0";
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            ClearControl();
            hdnUpadteId.Value = null;
        }
    }
}