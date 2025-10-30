using illumiyaFramework.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaFramework.Interfaces.Requests
{
    public interface IRequest
    {
        HeaderRequest Header { get; set; }
    }
}
