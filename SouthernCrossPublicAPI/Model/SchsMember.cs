using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SouthernCrossPublicAPI
{
    /// <summary>
    /// Class for Manger the Southern Cross Health Society Members
    /// </summary>
    public class SchsMember
    {
        /// <summary>
        /// Get or Set Member Id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Get or Set First Name
        /// </summary>
        public string firstName { get; set; }

        /// <summary>
        /// Get or Set Last Name
        /// </summary>
        public string lastName { get; set; }

        /// <summary>
        /// Get or Set Card Number
        /// </summary>
        public string memberCardNumber { get; set; }

        /// <summary>
        /// Get or Set Policy Number
        /// </summary>
        public string policyNumber { get; set; }

        /// <summary>
        /// Get or Set Date Of Birth
        /// </summary>
        public string dataOfBirth { get; set; }
    }
}
