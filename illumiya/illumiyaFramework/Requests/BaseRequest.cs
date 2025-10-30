using illumiyaFramework.Interfaces.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaFramework.Requests
{
    public class BaseRequest : IRequest
    {
        public HeaderRequest Header { get; set; }
    }
}
