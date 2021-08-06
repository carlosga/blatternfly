using System;

namespace Blatternfly.Components
{
    public sealed class PageResizeEventArgs : EventArgs
    {
        public bool MobileView { get; }
        public Size WindowSize { get; }
        
        internal PageResizeEventArgs(bool mobileView, Size windowSize)
        {
            MobileView = mobileView;
            WindowSize = windowSize;
        }
    }
}
