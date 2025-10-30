using NLog.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaFramework.Log
{
    public static class Logger
    {
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(AppDomain.CurrentDomain.BaseDirectory + "nlog.config").GetCurrentClassLogger();

        public static void Info(string infoText)
        {
            logger.Info(infoText);
        }

        public static void Error(string errorMessage = null, Exception exception = null)
        {
            if (exception == null)
            {
                logger.Error(errorMessage);

            }
            else { logger.Error(exception, errorMessage); }
        }
    }
}
