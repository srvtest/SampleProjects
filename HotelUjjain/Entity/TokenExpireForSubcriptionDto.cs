using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class TokenExpireForSubcriptionDto
    {
        public DateTime ValidExpire { get; set; }
        public TokenExpireForSubcriptionDto() { }

        public TokenExpireForSubcriptionDto(DataRow dr)
        {
            if (dr.Table.Columns.Contains("ValidExpire") && !Convert.IsDBNull(dr["ValidExpire"]))
            {
                this.ValidExpire = Convert.ToDateTime(dr["ValidExpire"]);
            }
        }
    }
}
