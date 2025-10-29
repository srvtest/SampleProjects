//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using System.IO.Pipes;
using System.Net.Http.Formatting;

namespace Entity
{
    public class Common
    {
        private static string sLogFormat;
        public Common()
        {
           
        }

        /// <summary>
        /// Method to create log 
        /// </summary>
        /// <param name="sErrMsg"></param>
        /// <param name="logPilePath"></param>
        public static void ErrorLog(string sErrMsg, string logPilePath)
        {
            sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";
            StreamWriter sw = new StreamWriter(logPilePath, true);
            sw.WriteLine(sLogFormat + sErrMsg);
            sw.Flush();
            sw.Close();
        }
    }
}
