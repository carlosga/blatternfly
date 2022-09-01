namespace Blatternfly.Components;

/// <summary>
/// Horizontal term width modifiers
/// </summary>
public sealed class HorizontalTermWidthModifiers : FormatBreakpointStyles<string>
{
    protected override string BaseStyle { get => "pf-c-description-list--m-horizontal__term--width"; }
}
