using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaFramework.Enums
{
    public class EGlobal
    {
        public enum CacheDuration
        {
            /// <summary>
            /// 4 minutes cache
            /// </summary>
            Small,

            /// <summary>
            /// 30 minutes cache
            /// </summary>
            Medium,

            /// <summary>
            /// 2 hours cache
            /// </summary>
            Large,

            /// <summary>
            /// 4 hours cache
            /// </summary>
            ExtraLarge,

            /// <summary>
            /// 12 hours cache
            /// </summary>
            Huge
        }

        public enum ResponseStatus
        {
            Unknown,
            Success,
            Fail,
            RequestValidationError,
            OnProgress
        }

        public enum Device
        {
            Unknown,
            Mobile,
            Desktop,
            Tablet
        }

        public enum LogSeverity
        {
            None,
            Info,
            Warning,
            Error,
            Diagnostic
        }

        public enum Roles { 
            SuperAdmin = 1,
            Admin = 2
        }
    }
}
