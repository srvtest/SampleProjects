using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Hotel_Guest_Reporting_System
{
    public partial class frmUserHotel : System.Web.UI.Page
    {
        UserHotelDL objUserHotelDL = new UserHotelDL();
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl1.Text = "User Hotel Details";
            lbl2.Text = "User Hotel";
            lbl3.Text = lbl2.Text;
            if (!Page.IsPostBack)
            {
                LoadGridData();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            UserHotelDto userDto = new UserHotelDto();
            userDto.idUser = Convert.ToInt32(ddlUserId.SelectedValue);
            userDto.idHotel = Convert.ToInt32(ddlHotelId.SelectedValue);
            userDto.bActive = chkbActive.Checked;
            if (!string.IsNullOrEmpty(hdUserHotelId.Value))
            {
                userDto.idUserHotel = Convert.ToInt32(hdUserHotelId.Value);
            }

            ResponseDto response = objUserHotelDL.InsertUpdateDeleteUserHotel(userDto);
            if (response != null)
            {
                if (response.StatusCode == 0)
                {
                    LoadGridData();
                    hdMessage.Value = response.Message;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "ShowPopup('" + hdMessage.Value + "');", true);
                }
                else
                {
                    hdMessage.Value = response.Message;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "ShowPopup('" + hdMessage.Value + "');", true);
                }
            }
        }

        public void LoadGridData()
        {
            ResponseDto obj = objUserHotelDL.GetUserHotel();
            if (obj != null)
            {
                if (obj.StatusCode == 0)
                {
                    List<UserHotelDto> userDto = (List<UserHotelDto>)obj.Result;
                    if (userDto != null)
                    {
                        RptUser.DataSource = userDto;
                        RptUser.DataBind();
                    }
                }

            }
            ShowUserPanal(false);
        }

        protected void RptUser_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                lbl4.Text = "Edit User Hotel";
                BindAllDropdown();
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdHotelId");
                ResponseDto response = objUserHotelDL.GetUserHotelById(Convert.ToInt32(hiddenField.Value));
                if (response != null)
                {
                    UserHotelDto userDto = (UserHotelDto)response.Result;
                    if (userDto != null)
                    {
                        ShowUserPanal(true);
                        ddlUserId.SelectedValue = Convert.ToString(userDto.idUser);
                        ddlHotelId.SelectedValue = Convert.ToString(userDto.idHotel);
                        chkbActive.Checked = userDto.bActive;
                        hdUserHotelId.Value = Convert.ToString(userDto.idUserHotel);
                    }
                }
            }
            else if (e.CommandName == "Delete")
            {
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdHotelId");
                UserHotelDto userDto = new UserHotelDto();
                userDto.isDeleted = true;
                if (!string.IsNullOrEmpty(hiddenField.Value))
                {
                    userDto.idUser = Convert.ToInt32(hiddenField.Value);
                }

                ResponseDto response = objUserHotelDL.InsertUpdateDeleteUserHotel(userDto);
                if (response != null)
                {
                    if (response.StatusCode == 0)
                    {
                        LoadGridData();
                        hdMessage.Value = response.Message;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "ShowPopup('" + hdMessage.Value + "');", true);
                    }
                    else
                    {
                        hdMessage.Value = response.Message;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "ShowPopup('" + hdMessage.Value + "');", true);
                    }
                }
            }
        }

        private void ShowUserPanal(bool v)
        {
            pnlUser.Visible = v;
            pnluserList.Visible = !v;
            ddlUserId.SelectedIndex = -1;
            ddlHotelId.SelectedIndex = -1;
            chkbActive.Checked = false;
            hdUserHotelId.Value = "";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ShowUserPanal(false);
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            ShowUserPanal(true);
            BindAllDropdown();
            lbl4.Text = "Add User Hotel";
        }
        private void BindAllDropdown()
        {
            DataSet dsHotel = objUserHotelDL.GetAllHotel();
            ddlHotelId.DataSource = dsHotel.Tables[0];
            ddlHotelId.DataTextField = "sName";
            ddlHotelId.DataValueField = "Id";
            ddlHotelId.DataBind();
            ddlHotelId.Items.Insert(0, new ListItem() { Text = "Select Hotel", Value = "0" });

            DataSet dsUser = objUserHotelDL.GetAllUser();
            ddlUserId.DataSource = dsUser.Tables[0];
            ddlUserId.DataTextField = "sName";
            ddlUserId.DataValueField = "Id";
            ddlUserId.DataBind();
            ddlUserId.Items.Insert(0, new ListItem() { Text = "Select User", Value = "0" });
        }
    }
}