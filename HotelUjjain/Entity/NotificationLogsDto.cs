using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class NotificationLogsDto
    {
        public bool isDeleted { get; set; }
        public int NotificationLogsID { get; set; }
        public string NotificationType { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string TemplateID { get; set; }
        public string UserType { get; set; }
        public int UserTypeID { get; set; }
        public int ActionID { get; set; }
        public int isSent { get; set; }
        public string SentID { get; set; }
        public string SentStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime SentDatetime { get; set; }

        public NotificationLogsDto() { }

        public NotificationLogsDto(DataRow dr)
        {
            if (dr.Table.Columns.Contains("NotificationLogsID") && !Convert.IsDBNull(dr["NotificationLogsID"]))
            {
                this.NotificationLogsID = Convert.ToInt32(dr["NotificationLogsID"]);
            }
            if (dr.Table.Columns.Contains("NotificationType") && !Convert.IsDBNull(dr["NotificationType"]))
            {
                this.NotificationType = Convert.ToString(dr["NotificationType"]);
            }
            if (dr.Table.Columns.Contains("MobileNumber") && !Convert.IsDBNull(dr["MobileNumber"]))
            {
                this.MobileNumber = Convert.ToString(dr["MobileNumber"]);
            }
            if (dr.Table.Columns.Contains("Email") && !Convert.IsDBNull(dr["Email"]))
            {
                this.Email = Convert.ToString(dr["Email"]);
            }
            if (dr.Table.Columns.Contains("isDeleted") && !Convert.IsDBNull(dr["isDeleted"]))
                this.isDeleted = Convert.ToBoolean(dr["isDeleted"]);
            if (dr.Table.Columns.Contains("Message") && !Convert.IsDBNull(dr["Message"]))
            {
                this.Message = Convert.ToString(dr["Message"]);
            }
            if (dr.Table.Columns.Contains("TemplateID") && !Convert.IsDBNull(dr["TemplateID"]))
            {
                this.TemplateID = Convert.ToString(dr["TemplateID"]);
            }
            if (dr.Table.Columns.Contains("UserType") && !Convert.IsDBNull(dr["UserType"]))
            {
                this.UserType = Convert.ToString(dr["UserType"]);
            }
            if (dr.Table.Columns.Contains("UserTypeID") && !Convert.IsDBNull(dr["UserTypeID"]))
            {
                this.UserTypeID = Convert.ToInt32(dr["UserTypeID"]);
            }
            if (dr.Table.Columns.Contains("ActionID") && !Convert.IsDBNull(dr["ActionID"]))
            {
                this.ActionID = Convert.ToInt32(dr["ActionID"]);
            }
            if (dr.Table.Columns.Contains("isSent") && !Convert.IsDBNull(dr["isSent"]))
            {
                this.isSent = Convert.ToInt32(dr["isSent"]);
            }
            if (dr.Table.Columns.Contains("SentID") && !Convert.IsDBNull(dr["SentID"]))
            {
                this.SentID = Convert.ToString(dr["SentID"]);
            }
            if (dr.Table.Columns.Contains("SentStatus") && !Convert.IsDBNull(dr["SentStatus"]))
            {
                this.SentStatus = Convert.ToString(dr["SentStatus"]);
            }
            if (dr.Table.Columns.Contains("CreatedAt") && !Convert.IsDBNull(dr["CreatedAt"]))
            {
                this.CreatedAt = Convert.ToDateTime(dr["CreatedAt"]);
            }
            if (dr.Table.Columns.Contains("SentDatetime") && !Convert.IsDBNull(dr["SentDatetime"]))
            {
                this.SentDatetime = Convert.ToDateTime(dr["SentDatetime"]);
            }
        }
    }
}
