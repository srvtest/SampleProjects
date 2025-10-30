using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace AutoPendingReportSubmit
{
    public partial class AutoSubmit : ServiceBase
    {
        Timer timer = new Timer();
        #region Property Declaration        
        AutoUpdateDL objHotelUpdate;
        string strTime = Convert.ToString(ConfigurationManager.AppSettings["StartTime"]);
        string strEnd = Convert.ToString(ConfigurationManager.AppSettings["EndTime"]);
        #endregion
        public AutoSubmit()
        {
            InitializeComponent();
            objHotelUpdate = new AutoUpdateDL();
        }

        protected override void OnStart(string[] args)
        {
            // Debugger.Launch();
            WriteToFile("Service is started at " + DateTime.Now);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Interval = 10000; //number in milisecinds
            timer.Enabled = true;
        }

        protected override void OnStop()
        {
            WriteToFile("Service is stopped at " + DateTime.Now);
        }
        public void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }

        #region Timer related event
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            WriteToFile("Service is recall at " + DateTime.Now);
            try
            {
                if (Convert.ToDateTime(DateTime.UtcNow.ToShortTimeString()) > Convert.ToDateTime(strTime)
                    && Convert.ToDateTime(DateTime.UtcNow.ToShortTimeString()) < Convert.ToDateTime(strEnd))
                {
                    timer.Stop();
                    objHotelUpdate.UpdateData(Convert.ToString(ConfigurationManager.ConnectionStrings["CnnString_Hotel"]));
                    timer.Start();
                }
                //if (strEnd==DateTime.Now)
                //{
                //    timer.Stop();
                //    objHotelUpdate.UpdateData(Convert.ToString(ConfigurationManager.ConnectionStrings["CnnString_Hotel"]));
                //   // timer.Start();
                //}
                //timer.Stop();
                //objHotelUpdate.UpdateData(Convert.ToString(ConfigurationManager.ConnectionStrings["CnnString_Hotel"]));
                //timer.Start();
            }
            catch (Exception exp)
            {
                timer.Start();
            }
        }
        #endregion
    }
}
