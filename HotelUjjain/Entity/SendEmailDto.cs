using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class SendEmailDto
    {
        public int IdSendEmail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string ToEmailId { get; set; }
        public bool isDeleted { get; set; }
        public SendEmailDto() { }

        public SendEmailDto(DataRow dr)
        {
            if (dr.Table.Columns.Contains("IdSendEmail") && !Convert.IsDBNull(dr["IdSendEmail"]))
            {
                this.IdSendEmail = Convert.ToInt32(dr["IdSendEmail"]);
            }
            if (dr.Table.Columns.Contains("Subject") && !Convert.IsDBNull(dr["Subject"]))
            {
                this.Subject = Convert.ToString(dr["Subject"]);
            }
            if (dr.Table.Columns.Contains("Message") && !Convert.IsDBNull(dr["Message"]))
            {
                this.Message = Convert.ToString(dr["Message"]);
            }
            if (dr.Table.Columns.Contains("ToEmailId") && !Convert.IsDBNull(dr["ToEmailId"]))
            {
                this.ToEmailId = Convert.ToString(dr["ToEmailId"]);
            }
            if (dr.Table.Columns.Contains("isDeleted") && !Convert.IsDBNull(dr["isDeleted"]))
                this.isDeleted = Convert.ToBoolean(dr["isDeleted"]);
        }
    }
}
