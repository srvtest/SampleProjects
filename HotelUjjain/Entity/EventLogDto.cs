using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class EventLogDto
    {
        public int idEventLog { get; set; }
        public string MethodName { get; set; }
        public string Parameter { get; set; }
        public string ProcName { get; set; }
        public int? idHotel { get; set; }
        public int? idUser { get; set; }
        public DateTime dtCreated { get; set; }
        public bool isDeleted { get; set; }
        public EventLogDto() { }

        public EventLogDto(DataRow dr)
        {
            if (dr.Table.Columns.Contains("idEventLog") && !Convert.IsDBNull(dr["idEventLog"]))
            {
                this.idEventLog = Convert.ToInt32(dr["idEventLog"]);
            }
            if (dr.Table.Columns.Contains("Parameter") && !Convert.IsDBNull(dr["Parameter"]))
            {
                this.Parameter = Convert.ToString(dr["Parameter"]);
            }
            if (dr.Table.Columns.Contains("ProcName") && !Convert.IsDBNull(dr["ProcName"]))
            {
                this.ProcName = Convert.ToString(dr["ProcName"]);
            }
            if (dr.Table.Columns.Contains("idUser") && !Convert.IsDBNull(dr["idUser"]))
            {
                this.idUser = Convert.ToInt32(dr["idUser"]);
            }
            if (dr.Table.Columns.Contains("isDeleted") && !Convert.IsDBNull(dr["isDeleted"]))
                this.isDeleted = Convert.ToBoolean(dr["isDeleted"]);
            if (dr.Table.Columns.Contains("MethodName") && !Convert.IsDBNull(dr["MethodName"]))
            {
                this.MethodName = Convert.ToString(dr["MethodName"]);
            }
            if (dr.Table.Columns.Contains("idHotel") && !Convert.IsDBNull(dr["idHotel"]))
            {
                this.idHotel = Convert.ToInt32(dr["idHotel"]);
            }
            if (dr.Table.Columns.Contains("dtCreated") && !Convert.IsDBNull(dr["dtCreated"]))
            {
                this.dtCreated = Convert.ToDateTime(dr["dtCreated"]);
            }
        }
    }
}
