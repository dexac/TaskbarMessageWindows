using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemTrayMessage.Models
{
    public class SenderModel
    {
        /// <summary>
        /// Sender UID
        /// </summary>
        public int id {  get; set; }

        /// <summary>
        /// Sender full name.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Input Message from sender
        /// </summary>
        public string message { get; set; }


    }
}
