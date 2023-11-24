using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SystemTrayMessage.Partials.Interop
{
    /// <summary>
    /// A structure submitted to configure the taskbar icon, 
    /// offering several members that can be partially configured based on the requirements.
    /// values <see cref="IconDataMembers"/> that were defined.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct NotifyIconData
    {
        /// <summary>
        /// Size of this structure, in bytes.
        /// </summary>
        public uint cbSize;

        /// <summary>
        /// The window handle designated to receive notification messages linked with an icon 
        /// present in the taskbar status area. When Shell_NotifyIcon is called, 
        /// the Shell utilizes hWnd and uID to identify the specific icon for operations.
        /// </summary>
        public IntPtr WindowHandle;

        /// <summary>
        /// The App-defined identifier for the taskbar icon. When Shell_NotifyIcon is called, 
        /// the Shell utilizes hWnd and uID to pinpoint the specific icon for operations. 
        /// Assigning distinct uIDs allows multiple icons to be linked to a single hWnd. 
        /// Presently, this feature remains unused.
        /// </summary>
        public uint TaskbarIconId;

        /// <summary>
        /// These flags indicate which additional members hold valid data. 
        /// This particular member can be a blend of the NIF_XXX constants.
        /// </summary>
        public IconDataMembers ValidMembers;

        /// <summary>
        /// App-defined message identifier. 
        /// is used by the system to dispatch notifications to the window specified by hWnd.
        /// </summary>
        public uint CallbackMessageId;

        /// <summary>
        /// A reference to the icon intended for display.
        /// Just <c>Icon.Handle</c>.
        /// </summary>
        public IntPtr IconHandle;

        /// <summary>
        /// Text string used for a standard ToolTip, limited to a maximum of 64 characters (including the terminating NULL) 
        /// for versions prior to 5.0. For Version 5.0 and beyond, szTip can extend to a 
        /// maximum of 128 characters (including the terminating NULL).
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string ToolTipText;


        /// <summary>
        /// State of the icon. Remember to also set the <see cref="StateMask"/>.
        /// </summary>
        public IconState IconState;

        /// <summary>
        /// A value that specifies which bits of the state member are retrieved or modified.
        /// For example, setting this member to <see cref="TaskbarNotification.Interop.IconState.Hidden"/>
        /// causes only the item's hidden
        /// state to be retrieved.
        /// </summary>
        public IconState StateMask;

        /// <summary>
        /// String with the text for a balloon ToolTip. It can have a maximum of 255 characters.
        /// To remove the ToolTip, set the NIF_INFO flag in uFlags and set szInfo to an empty string.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string BalloonText;

        /// <summary>
        /// Mainly used to set the version when <see cref="WinDLL.Shell_NotifyIcon"/> is invoked
        /// with <see cref="NotifyCommand.SetVersion"/>. However, for legacy operations,
        /// the same member is also used to set timeouts for balloon ToolTips.
        /// </summary>
        public uint VersionOrTimeout;

        /// <summary>
        /// String containing a title for a balloon ToolTip. This title appears in boldface
        /// above the text. It can have a maximum of 63 characters.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string BalloonTitle;

        /// <summary>
        /// Adds an icon to a balloon ToolTip, which is placed to the left of the title. If the
        /// <see cref="BalloonTitle"/> member is zero-length, the icon is not shown.
        /// </summary>
        public EnmFlags BalloonFlags;

        /// <summary>
        /// Windows XP (Shell32.dll version 6.0) and later.<br/>
        /// - Windows 7 and later: A registered GUID that identifies the icon.
        ///   This value overrides uID and is the recommended method of identifying the icon.<br/>
        /// - Windows XP through Windows Vista: Reserved.
        /// </summary>
        public Guid TaskbarIconGuid;

        /// <summary>
        /// Windows Vista (Shell32.dll version 6.0.6) and later. The handle of a customized
        /// balloon icon provided by the application that should be used independently
        /// of the tray icon. If this member is non-NULL and the <see cref="TaskbarNotification.Interop.BalloonFlags.User"/>
        /// flag is set, this icon is used as the balloon icon.<br/>
        /// If this member is NULL, the legacy behavior is carried out.
        /// </summary>
        public IntPtr CustomBalloonIconHandle;


        /// <summary>
        /// Creates a default data structure that provides
        /// a hidden taskbar icon without the icon being set.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns>NotifyIconData</returns>
        public static NotifyIconData CreateDefault(IntPtr handle)
        {
            var data = new NotifyIconData();

            if (Environment.OSVersion.Version.Major >= 6)
            {
                //use the current size
                data.cbSize = (uint)Marshal.SizeOf(data);
            }
            else
            {
                //we need to set another size on xp/2003- otherwise certain
                //features (e.g. balloon tooltips) don't work.
                data.cbSize = 952; // NOTIFYICONDATAW_V3_SIZE

                //set to fixed timeout
                data.VersionOrTimeout = 10;
            }

            data.WindowHandle = handle;
            data.TaskbarIconId = 0x0;
            data.CallbackMessageId = WinSink.CallbackMessageId;
            data.VersionOrTimeout = (uint)NotifyIconVersion.Win95;

            data.IconHandle = IntPtr.Zero;

            //hide initially
            data.IconState = IconState.Hidden;
            data.StateMask = IconState.Hidden;

            //set flags
            data.ValidMembers = IconDataMembers.Message
                                | IconDataMembers.Icon
                                | IconDataMembers.Tip;

            //reset strings
            data.ToolTipText = data.BalloonText = data.BalloonTitle = string.Empty;

            return data;
        }
    }

    /// <summary>
    /// The state of the icon - can be set to
    /// hide the icon.
    /// </summary>
    public enum IconState
    {
        /// <summary>
        /// The icon is visible.
        /// </summary>
        Visible = 0x00,

        /// <summary>
        /// Hide the icon.
        /// </summary>
        Hidden = 0x01,

        // The icon is shared - currently not supported, thus commented out.
        //Shared = 0x02
    }
}
