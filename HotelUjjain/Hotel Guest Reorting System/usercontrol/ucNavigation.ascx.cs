using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel_Guest_Reporting_System.usercontrol
{
    public partial class ucNavigation : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                NavigationDL navigationDL = new NavigationDL();
                
                ResponseDto responseDto= navigationDL.GetNavigationByUserId(Convert.ToInt32(Session["UserId"]));
                if (responseDto!=null)
                {
                    if (responseDto.StatusCode==0)
                    {
                        List<NavigationDto> lstNavigation = (List<NavigationDto>)responseDto.Result;
                        if (lstNavigation!=null && lstNavigation.Count>0)
                        {
                            rptNavigation.DataSource = lstNavigation;
                            rptNavigation.DataBind();
                        }
                    }
                }
            }

        }
    }
}