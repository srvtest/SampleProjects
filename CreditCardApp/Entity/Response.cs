using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    /// <summary>
    /// it is the generic response for all the APIs 
    /// </summary>
    public class Response
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
