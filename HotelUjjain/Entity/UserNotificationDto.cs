using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class UserNotificationDto
    {
        public int idUserNotification { get; set; }
        public int idsurveillance { get; set; }
        public string smessage { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool isRead { get; set; }
        public int idHotel { get; set; }
        public int status { get; set; }
        public int idGuestMaster { get; set; }


        public UserNotificationDto(DataRow dr)
        {
            

             
                if (dr.Table.Columns.Contains("idUserNotification") && !Convert.IsDBNull(dr["idUserNotification"]))
                this.idUserNotification = Convert.ToInt32(dr["idUserNotification"]);

            
                if (dr.Table.Columns.Contains("idsurveillance") && !Convert.IsDBNull(dr["idsurveillance"]))
                this.idsurveillance = Convert.ToInt32(dr["idsurveillance"]);
            
                if (dr.Table.Columns.Contains("smessage") && !Convert.IsDBNull(dr["smessage"]))
                this.smessage = Convert.ToString(dr["smessage"]);
            
                if (dr.Table.Columns.Contains("NotificationDate") && !Convert.IsDBNull(dr["NotificationDate"]))
                this.NotificationDate = Convert.ToDateTime(dr["NotificationDate"]);
            
                if (dr.Table.Columns.Contains("isRead") && !Convert.IsDBNull(dr["isRead"]))
                this.isRead = Convert.ToBoolean(dr["isRead"]);
            
                if (dr.Table.Columns.Contains("idHotel") && !Convert.IsDBNull(dr["idHotel"]))
                this.idHotel = Convert.ToInt32(dr["idHotel"]);
            
                if (dr.Table.Columns.Contains("status") && !Convert.IsDBNull(dr["status"]))
                this.status = Convert.ToInt32(dr["status"]);
            
                if (dr.Table.Columns.Contains("idGuestMaster") && !Convert.IsDBNull(dr["idGuestMaster"]))
                this.idGuestMaster = Convert.ToInt32(dr["idGuestMaster"]);


        }
        }
    }
