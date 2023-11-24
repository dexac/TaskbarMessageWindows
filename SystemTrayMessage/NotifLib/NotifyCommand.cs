using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemTrayMessage.Partials.Interop
{
    /// <summary>
    /// The primary operations conducted on
    /// <see cref="WinDLL.Shell_NotifyIcon"/> function.
    /// </summary>
    public enum NotifyCommand
    {
        /// <summary>
        /// Icon is being created.
        /// </summary>
        Add = 0x00,

        /// <summary>
        /// Icon are being updated.
        /// </summary>
        Modify = 0x01,

        /// <summary>
        /// Icon is deleted.
        /// </summary>
        Delete = 0x02,

        /// <summary>
        /// Returned to bar icon. Currently not in use.
        /// </summary>
        SetFocus = 0x03,

        /// <summary>
        /// 
        /// </summary>
        SetVersion = 0x04
    }
}
