using illumiyaFramework.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaFramework.Responses
{
    public class ErrorData
    {
        public string Message { get; set; }
        public string Data { get; set; }
        public string StackTrace { get; set; }
        public string ErrorCode { get; set; }
        public EGlobal.LogSeverity LogSeverity { get; set; }

        public ErrorData() { }

        public ErrorData(string message, EGlobal.LogSeverity logSeverity = EGlobal.LogSeverity.Info)
        {
            this.Message = message;
            this.LogSeverity = logSeverity;
        }
    }
}
