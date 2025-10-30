using FluentValidation.Results;
using illumiyaFramework.Enums;
using illumiyaFramework.Helpers;
using illumiyaFramework.Interfaces.Responses;
using illumiyaFramework.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace illumiyaFramework.Responses
{
    public static class Extensions
    {
        public static IResponse Warning(this IResponse response, string message, string data = "")
        {
            if (response == null) { response = new BaseResponse(); }
            if (response.ErrorList == null)
            {
                if (response.Header?.ErrorList == null)
                {
                    return response;
                }
                else { throw new Exception("Extensions => Seccess => Cannot return seccess , response.Header.ErrorList is not empty"); }
            }
            else { throw new Exception("Extensions => Seccess => Cannot return seccess response, response.ErrorList is not empty"); }
        }

        public static IResponse Continue(this IResponse response, string message, string data = "")
        {
            if (response == null) { response = new BaseResponse(); }
            if (response.ErrorList == null)
            {
                if (response.Header?.ErrorList == null)
                {
                    return response;
                }
                else { throw new Exception("Extensions => Seccess => Cannot return seccess , response.Header.ErrorList is not empty"); }
            }
            else { throw new Exception("Extensions => Seccess => Cannot return seccess response, response.ErrorList is not empty"); }
        }

        public static IResponse Marge(this IResponse response, IResponse responseForMarge)
        {
            if (responseForMarge == null) { throw new Exception("Extensions => Seccess => responseForMarge is not empty"); }
            if (response == null) { response = new BaseResponse(); }

            response.Status = responseForMarge.Status;
            if (responseForMarge.ErrorList != null)
            {
                response.ErrorList = response.ErrorList ?? new List<ErrorData>();
                response.ErrorList.AddRange(responseForMarge.ErrorList);
            }
            if (responseForMarge.ValidationErrors != null)
            {
                response.ValidationErrors = response.ValidationErrors ?? new List<ValidationErrorData>();
                responseForMarge.ValidationErrors = responseForMarge.ValidationErrors ?? new List<ValidationErrorData>();
            }
            return response;
        }

        public static IResponse Success(this IResponse response, string message, string data = "")
        {
            if (response == null) { response = new BaseResponse(); }
            if (response.ErrorList == null)
            {
                if (response.Header?.ErrorList == null)
                {
                    response.Status = EGlobal.ResponseStatus.Success;
                    return response;
                }
                else { throw new Exception("Extensions => Seccess => Cannot return seccess , response.Header.ErrorList is not empty"); }
            }
            else { throw new Exception("Extensions => Seccess => Cannot return seccess response, response.ErrorList is not empty"); }
        }

        public static bool Success(this IResponse response, IResponse responseForMarge, string message, string data = "")
        {
            if (responseForMarge == null) { throw new Exception("responseForMarge is null"); }
            if (responseForMarge.ErrorList != null)
            {
                response.ErrorList = response.ErrorList ?? new List<ErrorData>();
                response.ErrorList.AddRange(responseForMarge.ErrorList);
            }

            if (responseForMarge.ValidationErrors != null)
            {
                response.ValidationErrors = response.ValidationErrors ?? new List<ValidationErrorData>();
                response.ValidationErrors.AddRange(responseForMarge.ValidationErrors);
            }

            response.Success(message, data);
            return true;
        }

        public static bool Failed(this IResponse response, IResponse responseForMarge, string message, string data = "", string stackTrack = "", string errorCode = "", EGlobal.LogSeverity logSeverity = EGlobal.LogSeverity.Error)
        {
            if (responseForMarge == null) { throw new Exception("responseForMarge is null"); }
            if (responseForMarge.ErrorList != null)
            {
                response.ErrorList = response.ErrorList ?? new List<ErrorData>();
                response.ErrorList.AddRange(responseForMarge.ErrorList);
            }

            if (responseForMarge.ValidationErrors != null)
            {
                response.ValidationErrors = response.ValidationErrors ?? new List<ValidationErrorData>();
                response.ValidationErrors.AddRange(responseForMarge.ValidationErrors);
            }
            response.Failed(message, data, stackTrack, errorCode, logSeverity);
            return true;
        }

        public static bool Failed(this IResponse response, IList<ValidationFailure> ValidationFailureErrors)
        {
            if (ValidationFailureErrors == null) { throw new Exception("ValidationFailureErrors is null"); }
            response.ValidationErrors = ValidationFailureErrors.ToList().ConvertAll(error => new ValidationErrorData()
            {
                PropertyName = error.PropertyName,
                ErrorCode = error.ErrorCode,
                ErrorMessage = error.ErrorMessage,
            });
            response.Status = EGlobal.ResponseStatus.RequestValidationError;
            return true;
        }
        
        public static bool Failed(this IResponse response, string message, string data = "", string stackTrack = "", string errorCode = "", EGlobal.LogSeverity logSeverity = EGlobal.LogSeverity.Error)
        {
            response.ErrorList = response.ErrorList ?? new List<ErrorData>();
            response.Status = EGlobal.ResponseStatus.Fail;
            response.AddErrorData(message, data, stackTrack, errorCode, logSeverity);
            return true;
        }
        
        public static bool Failed(this IResponse response, Exception ex, EGlobal.LogSeverity logSeverity = EGlobal.LogSeverity.Info)
        {
            response.ErrorList = response.ErrorList ?? new List<ErrorData>();
            response.Status = EGlobal.ResponseStatus.Fail;
            response.AddErrorData(ex, logSeverity);
            return true;
        }

        public static bool ThrowExeption(this IResponse response, string message, string data = "", string stackTrack = "", string errorCode = "", EGlobal.LogSeverity logSeverity = EGlobal.LogSeverity.Error)
        {
            if (response.ErrorList == null)
            {
                throw new Exception(message);
            }
            else { throw new Exception("Extensions => Seccess => Cannot return seccess response, Error list is not empty"); }
        }

        public static bool AddErrorData(this IErrorResponse response, string message, string data = "", string stackTrack = "", string errorCode = "", EGlobal.LogSeverity logSeverity = EGlobal.LogSeverity.Info)
        {
            return ResponseHelper.AddErrorData(ref response, message, data, stackTrack, errorCode, logSeverity);
        }

        public static bool AddErrorData(this IErrorResponse response, Exception ex, EGlobal.LogSeverity logSeverity = EGlobal.LogSeverity.Info)
        {
            return ResponseHelper.AddErrorData(ref response, ex, logSeverity);
        }

        public static string ConvertToJson(this object value, bool isIdentedFormat = false, bool isTypeName = false)
        {
            return Serializer.ConvertToJson(value, isIdentedFormat, isTypeName);
        }
    }
}