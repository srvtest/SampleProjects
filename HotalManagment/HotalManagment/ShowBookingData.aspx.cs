using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataLayer;
using EntityLayer;
using System.Web.Services;

namespace HotalManagment
{
    public partial class ShowBookingData : System.Web.UI.Page
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
               
                BindBookingGrid();
                
            }
        }
        private void BindBookingGrid()
        {
            //if (Session["UserId"] != null && Convert.ToInt32(Session["UserId"]) > 0)
            //{              
            //    DataSet ds = objHotalManagment.BookedUserDetail(Convert.ToInt32(Session["UserId"]));
            //    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            //    {
            //        grdBooking.DataSource = ds.Tables[0];
            //        grdBooking.DataBind();
            //    }
            //}
        }

        protected void grdBooking_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void grdBooking_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //hdnBookingId.Value = Convert.ToString(((HiddenField)grdBooking.Rows[e.NewEditIndex].FindControl("hdnId")).Value);
            //string roomNo = Convert.ToString(((Label)grdBooking.Rows[e.NewEditIndex].FindControl("lblRoomNo")).Text);
            //Response.Redirect("addUpdateBooking.aspx?bookingId=" + CommanClasses.Encrypt(hdnBookingId.Value) + "&RoomNo=" + CommanClasses.Encrypt(roomNo));
        }

        protected void btnAddNew_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("addUpdateBooking.aspx");
        }

        [WebMethod]
        public static List<Events> GetEvents(int userId)
        {
            DL_HotalManagment objHotalDL = new DL_HotalManagment();
            return objHotalDL.GetAllEvents(userId);
        }
    }
}