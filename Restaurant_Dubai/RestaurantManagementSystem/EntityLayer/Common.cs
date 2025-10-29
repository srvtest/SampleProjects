using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EntityLayer
{
    public static class Common
    {
        public static bool CheckAccess(int AccessId) {
            List<Access> lstMenus = new List<Access>();
            lstMenus = (List<Access>)HttpContext.Current.Session["lstMenus"];
            lstMenus = lstMenus.Where(x => x.AccessID == AccessId).ToList<Access>();
            
            return (lstMenus != null && lstMenus.Count > 0);
        }
    }
}
