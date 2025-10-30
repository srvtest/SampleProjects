using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ErrorLogDto
    {
        public int idErrorLog { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorType { get; set; }
        public int? idUser { get; set; }
        public int? idHotel { get; set; }
        public DateTime dtCreated { get; set; }
        public string Method { get; set; }
        public bool isDeleted { get; set; }
        public ErrorLogDto() { }

        public ErrorLogDto(DataRow dr)
        {
            if (dr.Table.Columns.Contains("idErrorLog") && !Convert.IsDBNull(dr["idErrorLog"]))
            {
                this.idErrorLog = Convert.ToInt32(dr["idErrorLog"]);
            }
            if (dr.Table.Columns.Contains("ErrorMessage") && !Convert.IsDBNull(dr["ErrorMessage"]))
            {
                this.ErrorMessage = Convert.ToString(dr["ErrorMessage"]);
            }
            if (dr.Table.Columns.Contains("ErrorType") && !Convert.IsDBNull(dr["ErrorType"]))
            {
                this.ErrorType = Convert.ToString(dr["ErrorType"]);
            }
            if (dr.Table.Columns.Contains("idUser") && !Convert.IsDBNull(dr["idUser"]))
            {
                this.idUser = Convert.ToInt32(dr["idUser"]);
            }
            if (dr.Table.Columns.Contains("isDeleted") && !Convert.IsDBNull(dr["isDeleted"]))
                this.isDeleted = Convert.ToBoolean(dr["isDeleted"]);
            if (dr.Table.Columns.Contains("Method") && !Convert.IsDBNull(dr["Method"]))
            {
                this.Method = Convert.ToString(dr["Method"]);
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
