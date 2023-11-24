using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemTrayMessage.Partials.Interop
{
    ///<summary>
    /// Supported icons for the tray's balloon messages.
    ///</summary>
    public enum BalloonIcon
    {
        /// <summary>
        /// The balloon message is displayed without an icon.
        /// </summary>
        None,

        /// <summary>
        /// An information is displayed.
        /// </summary>
        Info,

        /// <summary>
        /// A warning is displayed.
        /// </summary>
        Warning,

        /// <summary>
        /// An error is displayed.
        /// </summary>
        Error
    }
}
