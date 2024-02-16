using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SystemTrayMessage.Partials.Interop
{
    public class WinSink : IDisposable
    {
#pragma warning disable
        #region members
#pragma warning disable

        /// <summary>
        /// The ID of messages that are received from the the
        /// taskbar icon.
        /// </summary>
        public const int CallbackMessageId = 0x400;

        /// <summary>
        /// A delegate that processes messages of the hidden
        /// native window that receives window messages. Storing
        /// this reference makes sure we don't loose our reference
        /// to the message window.
        /// </summary>
        private WindowProcedureHandler messageHandler;

        /// <summary>
        /// Fired in case the user clicked or moved within
        /// the taskbar icon area.
        /// </summary>
        public event Action<MouseEvent> MouseEventReceived;

        /// <summary>
        /// Window class ID.
        /// </summary>
        internal string WindowId { get; private set; }

        /// <summary>
        /// Handle for the message window.
        /// </summary>
        internal IntPtr MessageWindowHandle { get; private set; }

        /// <summary>
        /// The version of the underlying icon. Defines how
        /// incoming messages are interpreted.
        /// </summary>
        public NotifyIconVersion Version { get; set; }

        #endregion

        #region events

        /// <summary>
        /// The custom tooltip should be closed or hidden.
        /// </summary>
        public event Action<bool> ChangeToolTipStateRequest;

        /// <summary>
        /// Fired in case the user uses the WM_CONTEXTMENU-key
        /// on the taskbar icon.
        /// </summary>
        public event Action<Point> ContextMenuReceived;

        /// <summary>
        /// Fired if a balloon ToolTip was either displayed
        /// or closed (indicated by the boolean flag).
        /// </summary>
        public event Action<bool>BalloonToolTipChanged;

        /// <summary>
        /// Fired if the taskbar was created or restarted. Requires the taskbar
        /// icon to be reset.
        /// </summary>
        public event Action TaskbarCreated;

        #endregion

        #region construction

        /// <summary>
        /// Creates a new message sink that receives message from
        /// a given taskbar icon.
        /// </summary>
        /// <param name="version"></param>
        public WinSink(NotifyIconVersion version)
        {
            Version = version;
        }


        private WinSink()
        {
        }

        /// <summary>
        /// Creates a dummy instance that provides an empty
        /// pointer rather than a real window handler.<br/>
        /// Used at design time.
        /// </summary>
        /// <returns>WindowMessageSink</returns>
        internal static WinSink CreateEmpty()
        {
            return new WinSink
            {
                MessageWindowHandle = IntPtr.Zero,
                Version = NotifyIconVersion.Vista
            };
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Set to true as soon as <c>Dispose</c> has been invoked.
        /// </summary>
        public bool IsDisposed { get; private set; }


        /// <summary>
        /// Disposes the object.
        /// </summary>
        /// <remarks>This method is not virtual by design. Derived classes
        /// should override <see cref="Dispose(bool)"/>.
        /// </remarks>
        public void Dispose()
        {
            Dispose(true);

            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SuppressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// This destructor will run only if the <see cref="Dispose()"/>
        /// method does not get called. This gives this base class the
        /// opportunity to finalize.
        /// <para>
        /// Important: Do not provide destructor in types derived from
        /// this class.
        /// </para>
        /// </summary>
        ~WinSink()
        {
            Dispose(false);
        }

        /// <summary>
        /// Removes the windows hook that receives window
        /// messages and closes the underlying helper window.
        /// </summary>
        private void Dispose(bool disposing)
        {
            //don't do anything if the component is already disposed
            if (IsDisposed) return;
            IsDisposed = true;

            //always destroy the unmanaged handle (even if called from the GC)
            WinDLL.DestroyWindow(MessageWindowHandle);
            messageHandler = null;
        }

        #endregion
    }
}
