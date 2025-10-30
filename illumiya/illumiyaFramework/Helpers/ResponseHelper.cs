using illumiyaFramework.Enums;
using illumiyaFramework.Interfaces.Responses;
using illumiyaFramework.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaFramework.Helpers
{
    public static class ResponseHelper
    {
        public static bool AddErrorData(ref IErrorResponse response, Exception ex, EGlobal.LogSeverity logSeverity = EGlobal.LogSeverity.Error)
        {
            return AddErrorData(ref response, ex.Message, ex.Data.ToString(), ex.StackTrace, string.Empty, logSeverity);
        }

        public static bool AddErrorData(ref IErrorResponse response, string message, string data = "", string stackTrace = "", string errorCode = "", EGlobal.LogSeverity logSeverity = EGlobal.LogSeverity.Error)
        {
            if (response != null)
            {
                if (response.ErrorList == null)
                {
                    response.ErrorList = new List<ErrorData>();
                }

                response.ErrorList.Add(new ErrorData
                {
                    Data = data,
                    Message = message,
                    StackTrace = stackTrace,
                    ErrorCode = errorCode,
                    LogSeverity = logSeverity
                });
            }
            else
            {
                throw new Exception("Response header is null");
            }
            return false;
        }

        public static T GetResponse<T>(/*JWTHelper jwtHelper = null*/)
            where T : class, IResponse, new()
        {
            return new T()
            {
                Header = GetHeader(/*jwtHelper: jwtHelper*/)
            };
        }

        public static HeaderResponse GetHeader(/*EGlobal.ResponseStatus status,*/string errorMsg = null/*, JWTHelper jwtHelper = null*/)
        {
            return new HeaderResponse()
            {
                TimeStamp = DateTime.UtcNow,
                ErrorList = string.IsNullOrEmpty(errorMsg) ? null : new List<ErrorData>() { new ErrorData() { Message = errorMsg } }
            };
        }
    }
}
