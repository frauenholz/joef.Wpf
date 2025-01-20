using System.Windows;

namespace joef.Wpf
{

    /// <summary>
    /// Wpf window extension methods
    /// </summary>
    /// <remarks>
    /// Expects the Wpf exe project Settings to have a WindowRestoreBounds and a WindowState property
    /// </remarks>
    public static class WindowPersistExtensions
    {
        /// <summary>
        /// loads a main window from its location in the most recent execution
        /// </summary>
        /// <param name="w"></param>
        /// <param name="windowRestoreBounds"></param>
        /// <param name="windowState"></param>
        public static void LoadEditorUiState( this Window w,
                                              Rect windowRestoreBounds,
                                              WindowState windowState )
        {
        // load user environment
            // load window position
            w.Left   = windowRestoreBounds.X;
            w.Top    = windowRestoreBounds.Y;
            w.Width  = windowRestoreBounds.Width;
            w.Height = windowRestoreBounds.Height;

            //TODO: ensure window starts up on a visible monitor


            // load window state
            w.WindowState = windowState;
            // do not window start out minimized
            if ( w.WindowState == WindowState.Minimized )
                w.WindowState = WindowState.Normal;
        }
        /// <summary>
        /// saves a Window size and location to the apps project Settings
        /// </summary>
        /// <param name="w"></param>
        /// <returns></returns>
        public static Tuple<Rect,WindowState> SaveEditorUiState( this Window w )
        {
        // save user environment

            Rect windowRestoreBounds = Rect.Empty;
            WindowState windowState;

            // save window position
            Rect r = new Rect( w.Left,  
                               w.Top,  
                               w.Width,  
                               w.Height );
            windowRestoreBounds = r;

            // save window state
            windowState = w.WindowState;

            return new Tuple<Rect, WindowState>( windowRestoreBounds,
                                                 windowState );
        }
    }
}
