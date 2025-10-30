using System;
using System.Collections.Generic;
using System.Text;

namespace illumiyaFramework.Responses
{
    public class ServiceResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ServiceResponse"/> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success { get; set; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets the response XML.
        /// </summary>
        /// <value>
        /// The response XML.
        /// </value>
        public string ResponseXml { get; set; }
    }
}
