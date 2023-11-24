using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemTrayMessage.Partials.Interop
{
    /// <summary>
    /// Flags that define the icon that is shown on a Notification
    /// </summary>
    public enum EnmFlags
    {
        /// <summary>
        /// Icon not displayed.
        /// </summary>
        None = 0x00,

        /// <summary>
        /// Message icon is displayed.
        /// </summary>
        Info = 0x01,

        /// <summary>
        /// Warning is displayed.
        /// </summary>
        Warning = 0x02,

        /// <summary>
        /// Error is displayed.
        /// </summary>
        Error = 0x03,

        /// <summary>
        /// Custom as the title icon.
        /// </summary>
        User = 0x04,

        /// <summary>
        /// Do not play sound. Applies only to Message.
        /// </summary>
        NoSound = 0x10,

        /// <summary>
        /// 
        /// </summary>
        LargeIcon = 0x20,

        /// <summary>
        /// 
        /// </summary>
        RespectQuietTime = 0x80
    }
}
