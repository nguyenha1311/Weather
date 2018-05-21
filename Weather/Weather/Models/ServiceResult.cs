using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Models
{

    /// <summary>
    /// Object being used to store results from one of the service calls 
    /// </summary>
    public class ServiceResult {
        /// <summary>
        /// The message of why the service request process was unsuccessful.
        /// </summary>
        public string Errors {
            get; set;
        }

        /// <summary>
        /// The result deserialized from the server's json response 
        /// </summary>
        public dynamic Results {
            get; set;
        }

        public ServiceResult() {
        }
        
    }
}
