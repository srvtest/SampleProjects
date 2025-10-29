using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    /// <summary>
    /// Creating for Session
    /// </summary>
    public class RSession
    {
        public int RestaurentId { get; set; }
        public string RestaurentName { get; set; }
        public string Logo { get; set; }
        public int RoleId { get; set; }
        public int UserID { get; set; }
        /*****************************/
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public string MenuAccess { get; set; }
        public string MenuAccessID { get; set; }

        public string Map { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
    }
}
