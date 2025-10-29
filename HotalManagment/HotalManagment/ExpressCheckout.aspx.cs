using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;
using System.Data;
using DataLayer;

namespace HotalManagment
{
    public partial class ExpressCheckout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BookingDetailsCls objbookingDetails = new BookingDetailsCls();
            DL_HotalManagment objHotalManagment = new DL_HotalManagment();
            DataSet SearchResult = objHotalManagment.GetExpressSearch(txtName.Text.Trim(),Convert.ToInt32(Session["UserId"]));
            if (SearchResult.Tables[0].Rows.Count>0)
            {
                RepeaterSearchResult.DataSource = SearchResult;
                RepeaterSearchResult.DataBind();
                pnlEdit.Attributes.Add("style", "display:block");
                pnlList.Attributes.Add("style", "display:none");
            }
            else
            {
                hdMessage.Value += "Express checkin | No data found.";
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "Errormsg()", true);
            }
            
        }
        protected void btnName_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            //Server.Transfer("addUpdateBooking.aspx?prm=" + CommanClasses.Encrypt(Convert.ToString("BookingId=" + btn.CommandArgument + "&BookingType=New")));
            Response.Redirect("addUpdateBooking.aspx?prm=" + CommanClasses.Encrypt(Convert.ToString("BookingId=" + btn.CommandArgument + "&BookingType=New")));
        }
    }
}