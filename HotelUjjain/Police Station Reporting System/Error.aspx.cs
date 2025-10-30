using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Police_Station_Reporting_System
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLogDto errorLogDto = new ErrorLogDto()
            {
                ErrorType = "Page Error",
                ErrorMessage = null,
                idUser = Convert.ToInt32(Session["UserId"]),
                dtCreated = DateTime.Now
            };
            CommonDL.InsertErrorLog(errorLogDto);
        }
    }
}