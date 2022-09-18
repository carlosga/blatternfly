namespace Blatternfly.Layouts;

/// <summary>Grid order modifiers.</summary>
public sealed class GridOrderModifiers : FormatBreakpointStyles<string>
{
    protected override string BaseStyle { get => "pf-l-grid--item--Order"; }
}
