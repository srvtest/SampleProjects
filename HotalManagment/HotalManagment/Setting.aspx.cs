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
    public partial class setting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetApplicationSetting();
            }
        }

        private void GetApplicationSetting()
        {
            DL_HotalManagment objHotelManagment = new DL_HotalManagment();
            DataSet ds = objHotelManagment.GetAppSettingById(1);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtPlanExpireNotification.Text = Convert.ToString(ds.Tables[0].Rows[0]["AppValue"]);
                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DL_HotalManagment objHotelManagment = new DL_HotalManagment();
            int HotelId = Convert.ToInt32(Session["UserId"]);
            AppSetting objHotelCls = new AppSetting();
            objHotelCls.Id = HotelId;
            objHotelCls.AppValue = txtPlanExpireNotification.Text;
            if (string.IsNullOrEmpty(txtPlanExpireNotification.Text))
            {
                txtPlanExpireNotification.Text = "0";
            }


            int count = objHotelManagment.AppSetting(1, txtPlanExpireNotification.Text);
            hdMessage.Value = "Setting |";

            hdMessage.Value += " Plan Expire Notification saved successfully";
            Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Successmsg()", true);
        }


    }
}