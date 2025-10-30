using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GuestReportMain
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ConfigurationManager.AppSettings["test"].ToString() == "1")
                {
                    spnLink1.InnerHtml = "<a href=\"" +ConfigurationManager.AppSettings["ServerHotelReg"].ToString()+ "\"><b style=\"border-radius: 10px; background: #1AA7FF; font-size: 15px;\" class=\"btn btn-primary btn-block btn-flat\">New Hotel Registration</b></a>";
                    spnLink2.InnerHtml = "<a href=\"" + ConfigurationManager.AppSettings["ServerHotel"].ToString() + "\"><b style=\"border-radius: 10px; background: #1AA7FF; font-size: 15px;\" class=\"btn btn-primary btn-block btn-flat\" > Hotel Login</b></a>";
                    spnLink3.InnerHtml = "<a href=\"" + ConfigurationManager.AppSettings["ServerPolice"].ToString() + "\"><b style=\"border-radius: 10px; background: #1AA7FF; font-size: 15px;\" class=\"btn btn-primary btn-block btn-flat\">Police Login</b></a>";
                }
                else
                {
                    spnLink1.InnerHtml = "<a href=\"" + ConfigurationManager.AppSettings["LocalHotelReg"].ToString() + "\"><b style=\"border-radius: 10px; background: #1AA7FF; font-size: 15px;\" class=\"btn btn-primary btn-block btn-flat\">New Hotel Registration</b></a>";
                    spnLink2.InnerHtml = "<a href=\"" + ConfigurationManager.AppSettings["LocalHotel"].ToString() + "\"><b style=\"border-radius: 10px; background: #1AA7FF; font-size: 15px;\" class=\"btn btn-primary btn-block btn-flat\">Hotel Login</b></a>";
                    spnLink3.InnerHtml = "<a href=\"" + ConfigurationManager.AppSettings["LocalPolice"].ToString() + "\"><b style=\"border-radius: 10px; background: #1AA7FF; font-size: 15px;\" class=\"btn btn-primary btn-block btn-flat\">Police Login</b></a>";
                }               
            }
        }
    }
}