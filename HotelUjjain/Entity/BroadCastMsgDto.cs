using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class BroadCastMsgDto
    {
        public int BroadCastMsgId { get; set; }
        public string Msg { get; set; }
        public DateTime DisplayFrom { get; set; }
        public DateTime DisplayTo { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool bActive { get; set; }
        public bool isDeleted { get; set; }
        public BroadCastMsgDto() { }
        public BroadCastMsgDto(DataRow dr)
        {
            if (dr.Table.Columns.Contains("BroadCastMsgId") && !Convert.IsDBNull(dr["BroadCastMsgId"]))
            {
                this.BroadCastMsgId = Convert.ToInt32(dr["BroadCastMsgId"]);
            }
            if (dr.Table.Columns.Contains("Msg") && !Convert.IsDBNull(dr["Msg"]))
            {
                this.Msg = Convert.ToString(dr["Msg"]);
            }
            if (dr.Table.Columns.Contains("DisplayFrom") && !Convert.IsDBNull(dr["DisplayFrom"]))
            {
                this.DisplayFrom = Convert.ToDateTime(dr["DisplayFrom"]);
            }
            if (dr.Table.Columns.Contains("DisplayTo") && !Convert.IsDBNull(dr["DisplayTo"]))
            {
                this.DisplayTo = Convert.ToDateTime(dr["DisplayTo"]);
            }
            if (dr.Table.Columns.Contains("isDeleted") && !Convert.IsDBNull(dr["isDeleted"]))
                this.isDeleted = Convert.ToBoolean(dr["isDeleted"]);
            if (dr.Table.Columns.Contains("bActive") && !Convert.IsDBNull(dr["bActive"]))
                this.bActive = Convert.ToBoolean(dr["bActive"]);
            if (dr.Table.Columns.Contains("CreatedOn") && !Convert.IsDBNull(dr["CreatedOn"]))
            {
                this.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            }
        }
    }
}
