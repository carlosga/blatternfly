namespace Blatternfly.Components;

public sealed class PageResizeEventArgs : EventArgs
{
    public bool MobileView { get; }
    public Size<int> WindowSize { get; }

    internal PageResizeEventArgs(bool mobileView, Size<int> windowSize)
    {
        MobileView = mobileView;
        WindowSize = windowSize;
    }
}
