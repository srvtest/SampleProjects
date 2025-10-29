using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using DataLayer;
using EntityLayer;


namespace HotalManagment
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [WebMethod]
        public static List<Events> GetEvents(int userId)
        {
            DL_HotalManagment objHotalDL = new DL_HotalManagment();
            return objHotalDL.GetAllEvents(userId);
        }
    }
}