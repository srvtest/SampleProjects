using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaFramework.Responses
{
    public class ValidationErrorData
    {
        public string PropertyName { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
