using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class DeviceDetail
    {
        public string DeviceToken { get; set; }
        public string ModelName { get; set; }
        public string OSVersion { get; set; }
        public string PlatformName { get; set; }
        public string AppVersion { get; set; }
        public DeviceDetail()
        {
        }
    }
}
