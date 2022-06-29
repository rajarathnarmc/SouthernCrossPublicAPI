using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SouthernCrossPublicAPI.Model
{
    /// <summary>
    /// Added class for manage the exception details
    /// </summary>
    public class ErrorDetails
    {
        /// <summary>
        /// Get or Set Exception code
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// Get or Set Exception Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Override the To String method
        /// </summary>
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
