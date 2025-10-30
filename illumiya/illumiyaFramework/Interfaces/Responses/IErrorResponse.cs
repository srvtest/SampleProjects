using illumiyaFramework.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaFramework.Interfaces.Responses
{
    public interface IErrorResponse
    {
        List<ErrorData> ErrorList { get; set; }
    }
}
