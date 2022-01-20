namespace Blatternfly.Interop;

public sealed class MouseEvent
{
    public long Detail { get; set; }
    public double ScreenX { get; set; }
    public double ScreenY { get; set; }
    public double ClientX { get; set; }
    public double ClientY { get; set; }
    public double OffsetX { get; set; }
    public double OffsetY { get; set; }
    public long Button { get; set; }
    public long Buttons { get; set; }
    public bool CtrlKey { get; set; }
    public bool ShiftKey { get; set; }
    public bool AltKey { get; set; }
    public bool MetaKey { get; set; }
    public string Type { get; set; }

    public string[] ComposedPath { get; set; }
}
