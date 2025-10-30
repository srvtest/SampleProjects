using illumiyaFramework.Enums;
using illumiyaFramework.Interfaces.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaFramework.Responses
{
    public class HeaderResponse : IErrorResponse
    {
        public string AuthToken { get; set; }
        public DateTime TimeStamp { get; set; }
        public List<ErrorData> ErrorList { get; set; }
        public EGlobal.ResponseStatus Status { get; set; }
        public string StatusMessage { get; set; }
    }
}
