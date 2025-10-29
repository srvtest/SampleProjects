using System;
using System.Web.UI.WebControls;
using DataLayer;
using System.Data;
using EntityLayer;
using System.Configuration;

namespace HotalManagment
{
    public partial class RoomMaster : System.Web.UI.Page
    {
        DL_HotalManagment objDL_HotalManagment = new DL_HotalManagment();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Type"] != null && Convert.ToInt32(Session["Type"]) == 1)
            {
                Response.Redirect("MainDashBoard.aspx");
            }
            if (hdSKey.Value == "1")
            {
                pnlList.Visible = true;
                pnlSKey.Visible = false;
            }
            else
            {
                pnlList.Visible = false;
                pnlSKey.Visible = true;
            }
            if (!IsPostBack)
            {
                BindCategory();
                // BindGSTSlab();
                BindGridRooms();
                btnsave.Text = "Add";
            }
        }

        public void ClearControls()
        {
            ddlCategory.SelectedValue = "0";
            //ddlGstSlab.SelectedValue = "0";
            txtRoomFrom.Text = "";
            txtRoomTo.Text = "";
            txtPrice.Text = "";
            txtGroupName.Text = "";
            chkStatus.Checked = true;
        }

        private void BindGridRooms()
        {
            if (Session["UserId"] != null && Convert.ToInt32(Session["UserId"]) > 0)
            {
                DataSet ds = objDL_HotalManagment.GetRoomDetails(Convert.ToInt32(Session["UserId"]));
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    grdRooms.DataSource = ds;
                    grdRooms.DataBind();
                }
            }
            pnlEdit.Attributes.Add("style", "display:none");
            pnlList.Attributes.Add("style", "display:block");
        }

        //private void BindGSTSlab()
        //{
        //    if (Session["UserId"] != null && Convert.ToInt32(Session["UserId"]) > 0)
        //    {
        //        DataSet ds = objDL_HotalManagment.GetGSTSlab(Convert.ToInt32(Session["UserId"]));
        //        if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
        //        {
        //            ddlGstSlab.DataSource = ds;
        //            ddlGstSlab.DataTextField = "GSTSlab";
        //            ddlGstSlab.DataValueField = "Id";
        //            ddlGstSlab.DataBind();
        //        }
        //        ddlGstSlab.Items.Insert(0, new ListItem("Select GST Slab", "0"));
        //    }
        //}

        private void BindCategory()
        {
            if (Session["UserId"] != null && Convert.ToInt32(Session["UserId"]) > 0)
            {
                DataSet ds = objDL_HotalManagment.GetAllCategory(Convert.ToInt32(Session["UserId"]));
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    ddlCategory.DataSource = ds;
                    ddlCategory.DataTextField = "CategoryName";
                    ddlCategory.DataValueField = "Id";
                    ddlCategory.DataBind();
                }
                ddlCategory.Items.Insert(0, new ListItem("Select Category", "0"));
            }
        }

        protected void grdRooms_RowEditing(object sender, GridViewEditEventArgs e)
        {
            pnlEdit.Attributes.Add("style", "display:block");
            pnlList.Attributes.Add("style", "display:none");
            status.Attributes.Add("style", "display:block");
            hdnGroupId.Value = Convert.ToString(((HiddenField)grdRooms.Rows[e.NewEditIndex].FindControl("hdnId")).Value);
            txtGroupName.Text = ((Label)grdRooms.Rows[e.NewEditIndex].FindControl("lblGroupName")).Text;
            txtRoomFrom.Text = ((Label)grdRooms.Rows[e.NewEditIndex].FindControl("lblRoomFrom")).Text;
            txtRoomTo.Text = ((Label)grdRooms.Rows[e.NewEditIndex].FindControl("lblRoomTo")).Text;
            ddlCategory.SelectedValue = ((HiddenField)grdRooms.Rows[e.NewEditIndex].FindControl("hdnCategoryId")).Value;
            // ddlGstSlab.SelectedValue = ((HiddenField)grdRooms.Rows[e.NewEditIndex].FindControl("hdnGSTSlabId")).Value;
            txtPrice.Text = ((Label)grdRooms.Rows[e.NewEditIndex].FindControl("lblPrice")).Text;
            chkStatus.Checked = Convert.ToString(((HiddenField)grdRooms.Rows[e.NewEditIndex].FindControl("hdnStatusId")).Value) == "True";

            txtMon.Text = ((HiddenField)grdRooms.Rows[e.NewEditIndex].FindControl("lblMon")).Value;
            txtTues.Text = ((HiddenField)grdRooms.Rows[e.NewEditIndex].FindControl("lblTues")).Value;
            txtWed.Text = ((HiddenField)grdRooms.Rows[e.NewEditIndex].FindControl("lblWeb")).Value;
            txtThu.Text = ((HiddenField)grdRooms.Rows[e.NewEditIndex].FindControl("lblThu")).Value;
            txtFri.Text = ((HiddenField)grdRooms.Rows[e.NewEditIndex].FindControl("lblFri")).Value;
            txtSat.Text = ((HiddenField)grdRooms.Rows[e.NewEditIndex].FindControl("lblSat")).Value;
            txtSun.Text = ((HiddenField)grdRooms.Rows[e.NewEditIndex].FindControl("lblSun")).Value;

            txtExBadEP.Text = ((HiddenField)grdRooms.Rows[e.NewEditIndex].FindControl("lblEBCEP")).Value;
            txtExBadCP.Text = ((HiddenField)grdRooms.Rows[e.NewEditIndex].FindControl("lblEBCCP")).Value;
            txtExBadMAP.Text = ((HiddenField)grdRooms.Rows[e.NewEditIndex].FindControl("lblEBCMAP")).Value;


            txtPersons.Text = ((Label)grdRooms.Rows[e.NewEditIndex].FindControl("lblPerson")).Text;
            txtEP.Text = ((HiddenField)grdRooms.Rows[e.NewEditIndex].FindControl("lblEP")).Value;
            txtCP.Text = ((HiddenField)grdRooms.Rows[e.NewEditIndex].FindControl("lblCP")).Value;
            txtMAP.Text = ((HiddenField)grdRooms.Rows[e.NewEditIndex].FindControl("lblMAP")).Value;

            btnsave.Text = "Update";
            ClientScript.RegisterStartupScript(GetType(), "Rooms", "ShowEditForm()", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            RoomCls objRoomDetails = new RoomCls();
            objRoomDetails.Id = !string.IsNullOrEmpty(hdnGroupId.Value) ? Convert.ToInt32(hdnGroupId.Value) : 0;
            objRoomDetails.CategoryId = Convert.ToInt32(ddlCategory.SelectedValue);
            objRoomDetails.RoomFrom = txtRoomFrom.Text.Trim();
            objRoomDetails.RoomTo = txtRoomTo.Text.Trim();
            objRoomDetails.Price = !string.IsNullOrEmpty(txtPrice.Text) ? Convert.ToDecimal(txtPrice.Text.Trim()) : 0;
            //objRoomDetails.GSTSlab = Convert.ToInt32(ddlGstSlab.SelectedValue);
            objRoomDetails.IsUnderHK = 0;
            objRoomDetails.Monday = !string.IsNullOrEmpty(txtMon.Text.Trim()) ? Convert.ToDecimal(txtMon.Text.Trim()) : 0;
            objRoomDetails.Tuesday = !string.IsNullOrEmpty(txtTues.Text.Trim()) ? Convert.ToDecimal(txtTues.Text.Trim()) : 0;
            objRoomDetails.Wednesday = !string.IsNullOrEmpty(txtWed.Text.Trim()) ? Convert.ToDecimal(txtWed.Text.Trim()) : 0;
            objRoomDetails.Thursday = !string.IsNullOrEmpty(txtThu.Text.Trim()) ? Convert.ToDecimal(txtThu.Text.Trim()) : 0;
            objRoomDetails.Friday = !string.IsNullOrEmpty(txtFri.Text.Trim()) ? Convert.ToDecimal(txtFri.Text.Trim()) : 0;
            objRoomDetails.Saturday = !string.IsNullOrEmpty(txtSat.Text.Trim()) ? Convert.ToDecimal(txtSat.Text.Trim()) : 0;
            objRoomDetails.Sunday = !string.IsNullOrEmpty(txtSun.Text.Trim()) ? Convert.ToDecimal(txtSun.Text.Trim()) : 0;


            objRoomDetails.Persons = !string.IsNullOrEmpty(txtPersons.Text.Trim()) ? Convert.ToInt32(txtPersons.Text.Trim()) : 0;
            objRoomDetails.EP = !string.IsNullOrEmpty(txtEP.Text.Trim()) ? Convert.ToDecimal(txtEP.Text.Trim()) : 0;
            objRoomDetails.CP = !string.IsNullOrEmpty(txtCP.Text.Trim()) ? Convert.ToDecimal(txtCP.Text.Trim()) : 0;
            objRoomDetails.MAP = !string.IsNullOrEmpty(txtMAP.Text.Trim()) ? Convert.ToDecimal(txtMAP.Text.Trim()) : 0;

            objRoomDetails.ExBadChargesEP = !string.IsNullOrEmpty(txtExBadEP.Text.Trim()) ? Convert.ToDecimal(txtExBadEP.Text.Trim()) : 0;
            objRoomDetails.ExBadChargesCP = !string.IsNullOrEmpty(txtExBadCP.Text.Trim()) ? Convert.ToDecimal(txtExBadCP.Text.Trim()) : 0;
            objRoomDetails.ExBadChargesMAP = !string.IsNullOrEmpty(txtExBadMAP.Text.Trim()) ? Convert.ToDecimal(txtExBadMAP.Text.Trim()) : 0;

         

            if (objRoomDetails.Id == 0)
            {
                hdMessage.Value = "Room Insert |";
            }
            else
            {
                hdMessage.Value = "Room Update |";
            }
            if (Session["UserId"] != null && Convert.ToInt32(Session["UserId"]) > 0)
            {
                objRoomDetails.CreatedBy = Convert.ToInt32(Session["UserId"]);
                objRoomDetails.ModifyBy = Convert.ToInt32(Session["UserId"]);
            }
            objRoomDetails.IsActive = chkStatus.Checked ? Convert.ToInt16(1) : Convert.ToInt16(0);
            objRoomDetails.GroupName = txtGroupName.Text.Trim();

            int Response = objDL_HotalManagment.InsertUpdateRoomDetails(objRoomDetails);
            if (Response == -1)
            {

                hdMessage.Value += " enter another room number. room already exists, please try again...";
                ClientScript.RegisterStartupScript(GetType(), "Rooms", "Errormsg();", true);
            }
            else if (Response > 1)
            {

                hdMessage.Value += "Data saved successfully";
                ClientScript.RegisterStartupScript(GetType(), "Rooms", "Successmsg();", true);
                //ClearControls();
            }
            else if (Response > 2)
            {

                hdMessage.Value += "Data updated successfully";
                ClientScript.RegisterStartupScript(GetType(), "Rooms", "Successmsg();", true);
                // ClearControls();
            }
            else
            {

                hdMessage.Value += "Data not saved successfully please try again...";
                ClientScript.RegisterStartupScript(GetType(), "Rooms", "Errormsg();", true);
            }
            btnsave.Text = "Add";
            BindGridRooms();

            CommonUtilitys objCommonUtilitys = new CommonUtilitys();
            string fromDate = DateTime.Now.ToShortDateString();
            string toDate = DateTime.Now.AddDays(30).ToShortDateString();

            decimal basePrice, exBasePrice;
            basePrice = 0;
            exBasePrice = 0;
            DataSet ds1 = objDL_HotalManagment.GetHotelDetailForCP(Convert.ToInt32(Session["UserId"]), 0);
            if (ds1 != null && ds1.Tables.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[2].Rows.Count; i++)
                {

                    switch (Convert.ToString(ds1.Tables[2].Rows[i]["id"]))
                    {
                        case "1":
                            basePrice = !string.IsNullOrEmpty(txtEP.Text.Trim()) ? Convert.ToDecimal(txtEP.Text.Trim()) : 0;
                            exBasePrice = !string.IsNullOrEmpty(txtExBadEP.Text.Trim()) ? Convert.ToDecimal(txtExBadEP.Text.Trim()) : 0;
                            break;
                        case "2":
                            basePrice = !string.IsNullOrEmpty(txtCP.Text.Trim()) ? Convert.ToDecimal(txtCP.Text.Trim()) : 0;
                            exBasePrice = !string.IsNullOrEmpty(txtExBadCP.Text.Trim()) ? Convert.ToDecimal(txtExBadCP.Text.Trim()) : 0;
                            break;
                        case "3":
                            basePrice = !string.IsNullOrEmpty(txtMAP.Text.Trim()) ? Convert.ToDecimal(txtMAP.Text.Trim()) : 0;
                            exBasePrice = !string.IsNullOrEmpty(txtExBadMAP.Text.Trim()) ? Convert.ToDecimal(txtExBadMAP.Text.Trim()) : 0;
                            break;
                        default:
                            break;
                    }
                    basePrice = Convert.ToDecimal((!string.IsNullOrEmpty(txtPrice.Text) ? Convert.ToDecimal(txtPrice.Text.Trim()) : 0) + basePrice);

                    DataTable tblFiltered = ds1.Tables[1].AsEnumerable()
               .Where(row => row.Field<Int32>("Id") == Convert.ToInt32(ddlCategory.SelectedValue))
              .CopyToDataTable();

                  //  objCommonUtilitys.UpdateRoomRates(Convert.ToInt32(Session["UserId"]), fromDate, toDate, Convert.ToString(tblFiltered.Rows[0]["CpCategoryId"]), Convert.ToString(ds1.Tables[2].Rows[i]["RTid"]), basePrice, exBasePrice);
                }
            }

            ClearControls();
            hdnGroupId.Value = "0";
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            btnsave.Text = "Add";
            BindGridRooms();
            ClearControls();
            hdnGroupId.Value = "0";
        }

        protected void grdRooms_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            ClearControls();
            ClientScript.RegisterStartupScript(GetType(), "Rooms", "$('#AddRooms').modal('show');", true);
            hdnGroupId.Value = "0";
        }

        protected void btnsKey_Click(object sender, EventArgs e)
        {
            string SKey = ConfigurationManager.AppSettings["SKey"].ToString();
            if (txtSKey.Text == SKey)
            {
                hdSKey.Value = "1";
                pnlList.Visible = true;
                pnlSKey.Visible = false;
            }
            else
            {
                hdMessage.Value = "Authentication | Please enter valid key";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
        }

        //public void UpdateRoomRates()
        //{

        //    DataSet ds1 = objDL_HotalManagment.GetHotelDetailForCP(Convert.ToInt32(Session["UserId"]), 0);
        //    if (ds1 != null && ds1.Tables.Count > 0)
        //    {
        //        for (int i = 0; i < ds1.Tables[2].Rows.Count; i++)
        //        {
        //            decimal exPrice = 0;
        //            decimal exBPrice = 0;
        //            RES_Request objRES_Request = new RES_Request();
        //            objRES_Request.Authentication.HotelCode = Convert.ToString(ds1.Tables[0].Rows[0]["CpHotelId"]);
        //            objRES_Request.Authentication.AuthCode = Convert.ToString(ds1.Tables[0].Rows[0]["AuthCode"]);



        //            objRES_Request.RateType.RoomTypeID = Convert.ToString(tblFiltered.Rows[0]["CpCategoryId"]);
        //            objRES_Request.RateType.RateTypeID = Convert.ToString(ds1.Tables[2].Rows[i]["RTid"]).Trim();
        //            objRES_Request.RateType.FromDate = DateTime.Now.ToString("yyyy-MM-dd");
        //            objRES_Request.RateType.ToDate = "2019-04-20";//Convert.ToDateTime(txtTodate.Text).ToString("yyyy-MM-dd");
        //            objRES_Request.Request_Type = "UpdateRoomRates";

        //            switch (Convert.ToString(ds1.Tables[2].Rows[i]["id"]))
        //            {
        //                case "1":
        //                    exPrice = !string.IsNullOrEmpty(txtEP.Text.Trim()) ? Convert.ToDecimal(txtEP.Text.Trim()) : 0;
        //                    exBPrice = !string.IsNullOrEmpty(txtExBadEP.Text.Trim()) ? Convert.ToDecimal(txtExBadEP.Text.Trim()) : 0;
        //                    break;
        //                case "2":
        //                    exPrice = !string.IsNullOrEmpty(txtCP.Text.Trim()) ? Convert.ToDecimal(txtCP.Text.Trim()) : 0;
        //                    exBPrice = !string.IsNullOrEmpty(txtExBadCP.Text.Trim()) ? Convert.ToDecimal(txtExBadCP.Text.Trim()) : 0;
        //                    break;
        //                case "3":
        //                    exPrice = !string.IsNullOrEmpty(txtMAP.Text.Trim()) ? Convert.ToDecimal(txtMAP.Text.Trim()) : 0;
        //                    exBPrice = !string.IsNullOrEmpty(txtExBadMAP.Text.Trim()) ? Convert.ToDecimal(txtExBadMAP.Text.Trim()) : 0;
        //                    break;
        //                default:
        //                    break;
        //            }
        //            objRES_Request.RateType.RoomRate = new RoomRate();
        //            objRES_Request.RateType.RoomRate.Base = Convert.ToString((!string.IsNullOrEmpty(txtPrice.Text) ? Convert.ToDecimal(txtPrice.Text.Trim()) : 0) + exPrice);
        //            objRES_Request.RateType.RoomRate.ExtraAdult = Convert.ToString(exBPrice);
        //            objRES_Request.RateType.RoomRate.ExtraChild = Convert.ToString(exBPrice);
        //            string xml = objRES_Request.ToXML();

        //            CommonUtilitys objCommonUtilityCls = new CommonUtilitys();
        //            objCommonUtilityCls.CPApi(xml);


        //        }
        //    }
        //}
    }
}