using illumiyaFramework.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaFramework.Requests
{
    public class HeaderRequest
    {
        public string OwnerToken { get; set; }
        public DateTime TimeStamp { get; set; }
        public string ClientIP { get; set; }
        public string DeviceIP { get; set; }
        public EGlobal.Device Device { get; set; }
        public string AuthToken { get; set; }

        public HeaderRequest()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
