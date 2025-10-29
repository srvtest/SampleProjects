using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Enums
    {

        public enum TranType
        {
            DEBIT,
            CREDIT
        }

        public enum ResponseType
        {
            Success,
            Error,
            Failure
        }

        /// <summary>
        /// Error code to response 
        /// </summary>
        public enum ResponseCode
        {
            ApplicationSuccess = 200,
            ApplicationError=500,
            BadRequestError = 400,
            PageNotFoundError=404
        }

        public enum RecordStatus
        {
            InProgress,
            Rejected,
            Processed,
            Failed
        }

    }
}
