using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemTrayMessage.Partials.Interop
{
    public enum PopupShow
    {
        /// <summary>
        /// The item is displayed if the user clicks the
        /// tray icon with the left mouse button.
        /// </summary>
        LeftClick,

        /// <summary>
        /// The item is displayed if the user clicks the
        /// tray icon with the right mouse button.
        /// </summary>
        RightClick,

        /// <summary>
        /// The item is displayed if the user double-clicks the
        /// tray icon.
        /// </summary>
        DoubleClick,

        /// <summary>
        /// The item is displayed if the user clicks the
        /// tray icon with the left or the right mouse button.
        /// </summary>
        LeftOrRightClick,

        /// <summary>
        /// The item is displayed if the user clicks the
        /// tray icon with the left mouse button or if a
        /// double-click is being performed.
        /// </summary>
        LeftOrDoubleClick,

        /// <summary>
        /// The item is displayed if the user clicks the
        /// tray icon with the middle mouse button.
        /// </summary>
        MiddleClick,

        /// <summary>
        /// The item is displayed whenever a click occurs.
        /// </summary>
        All,

        /// <summary>
        /// The item is displayed manually from code.
        /// </summary>
        None
    }
}
