namespace Blatternfly.Layouts;

/// <summary>Flex order modifiers.</summary>
public sealed class FlexOrderModifiers : FormatBreakpointStyles<int?>
{
    protected override string BaseStyle { get => "pf-l-flex--item--Order"; }
}
