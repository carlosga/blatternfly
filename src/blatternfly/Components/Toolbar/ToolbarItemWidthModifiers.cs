namespace Blatternfly.Components;

/// <summary>Toolbar item width modifiers.</summary>
public sealed class ToolbarItemWidthModifiers : FormatBreakpointStyles<string>
{
    protected override string BaseStyle { get => "pf-c-toolbar__item--Width"; }
}
