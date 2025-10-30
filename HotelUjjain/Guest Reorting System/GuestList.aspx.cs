using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Guest_Reporting_System
{
    public partial class GuestList : System.Web.UI.Page
    {
        public string GuestName
        {
            get
            {
                return Convert.ToString(Session["GuestName"]);
            }
            set
            {

                Session["GuestName"] = value;
            }
        }

        public string AadharNo
        {
            get
            {
                return Convert.ToString(Session["AadharNo"]);
            }
            set
            {

                Session["AadharNo"] = value;
            }
        }

        public string MobileNo
        {
            get
            {
                return Convert.ToString(Session["MobileNo"]);
            }
            set
            {

                Session["MobileNo"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GuestName = ""; AadharNo = ""; MobileNo = "";
                if (!string.IsNullOrEmpty(GuestName) || !string.IsNullOrEmpty(AadharNo) || !string.IsNullOrEmpty(MobileNo))
                {
                    //LoadGridData();
                    if (!string.IsNullOrEmpty(GuestName))
                        txtGuestName.Text = GuestName.Trim();
                    if (!string.IsNullOrEmpty(AadharNo))
                        txtAadharNo.Text = AadharNo.Trim();
                    if (!string.IsNullOrEmpty(MobileNo))
                        txtMobileNo.Text = MobileNo.Trim();
                    LoadGridData(txtGuestName.Text, txtAadharNo.Text, txtMobileNo.Text);
                }
            }
            string strFolderTemp;
            strFolderTemp = Server.MapPath("./GuestFiles/Temp/");
            foreach (var file in Directory.GetFiles(strFolderTemp.ToString()))
            {
                File.Delete(file);
            }
        }

        public void LoadGridData(string txtGuestName, string txtAadharNo, string txtMobileNo)
        {
            lblMessage1.Visible = false;
            GuestMasterDL objuserDL = new GuestMasterDL();
            GuestFilterDto guestFilterDto = new GuestFilterDto();
            guestFilterDto.idHotel = Convert.ToInt32(Session["snsHotelId"]);
            guestFilterDto.GuestName = txtGuestName;
            guestFilterDto.IdentificationNo = txtAadharNo;
            guestFilterDto.ContactNo = txtMobileNo;

            ResponseDto obj = objuserDL.GetGuestMasterFilter(guestFilterDto,false);
            if (obj != null)
            {
                if (obj.StatusCode == 0)
                {
                    List<GuestMasterDto> userDto = (List<GuestMasterDto>)obj.Result;
                    
                    if (userDto != null)
                    {
                        rptGuest.DataSource = userDto;
                        rptGuest.DataBind();
                        if (userDto.Count == 0)
                        {
                            lblMessage1.Visible = true;
                            lblMessage1.InnerHtml = obj.Message;
                            //Page.ClientScript.RegisterStartupScript(GetType(), "Popup", "SearchGuestData();", true);
                        }
                    }
                }
            }
            //ShowUserPanal(false);
        }

        protected void rptGuest_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                           e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hdnId = e.Item.FindControl("hdnIdGuest") as HiddenField;
                Label NewControl = e.Item.FindControl("lblAddGuest") as Label;
                if (NewControl != null)
                {
                    List<GuestMasterDto> userDto = (List<GuestMasterDto>)rptGuest.DataSource;
                    if (userDto != null && userDto.Where(x => x.idGuestMaster == Convert.ToInt32(hdnId.Value)).Count() > 0)
                    {
                        foreach (var item in userDto)
                        {
                            if (string.IsNullOrEmpty(NewControl.Text))
                            {
                                NewControl.Text = Convert.ToString(item.AddionalGuest);
                            }
                            else
                            {
                                NewControl.Text = Convert.ToString(item.AddionalGuest);
                            }
                        }

                        //List<GuestDetailDto> guestDetailDtos = userDto.Where(x => x.idGuestMaster == Convert.ToInt32(hdnId.Value)).FirstOrDefault().Details;
                        //if (guestDetailDtos != null)
                        //{
                        //    foreach (var item in guestDetailDtos)
                        //    {
                        //        if (string.IsNullOrEmpty(NewControl.Text))
                        //        {
                        //            NewControl.Text = item.sName + " (" + item.gender + ")";
                        //        }
                        //        else
                        //        {
                        //            NewControl.Text += "<br>" + item.sName + " (" + item.gender + ")";
                        //        }

                        //    }
                        //}
                    }
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGuestName.Text) && string.IsNullOrEmpty(txtAadharNo.Text) && string.IsNullOrEmpty(txtMobileNo.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "MyKey", "SaveGuestData();", true);
                //return;
            }
            else
            {
                GuestName = txtGuestName.Text;
                AadharNo=txtAadharNo.Text;
                MobileNo = txtMobileNo.Text;
                LoadGridData(txtGuestName.Text, txtAadharNo.Text, txtMobileNo.Text);
            }
            Clear();
        }

        private void Clear()
        {
            txtAadharNo.Text = "";
            txtGuestName.Text = "";
            txtMobileNo.Text = "";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtAadharNo.Text = "";
            txtGuestName.Text = "";
            txtMobileNo.Text = "";
            rptGuest.DataSource = null;
            rptGuest.DataBind();
        }

        protected void rptGuest_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Details")
            {
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hdnIdGuest");
                Response.Redirect("GuestDetails.aspx?idGuestMaster=" + UtilityFunction.Encrypt(Convert.ToString(hiddenField.Value)));
            }
        }

       
    }
}