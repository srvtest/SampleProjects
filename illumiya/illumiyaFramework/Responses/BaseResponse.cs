using illumiyaFramework.Enums;
using illumiyaFramework.Interfaces.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaFramework.Responses
{
    public class BaseResponse : IResponse
    {
        public HeaderResponse Header { get; set; }

        public List<ErrorData> ErrorList { get; set; }
        public List<ValidationErrorData> ValidationErrors { get; set; }
        public bool NoErrors { get { return ErrorList?.Count == 0 || ValidationErrors?.Count == 0; } }


        public EGlobal.ResponseStatus Status { get; set; }
        public bool IsSuccess { get { return Status == EGlobal.ResponseStatus.Success; } }

        
        
    }
}
