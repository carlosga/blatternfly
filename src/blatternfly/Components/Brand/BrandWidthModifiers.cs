namespace Blatternfly.Components;

/// <summary>Widths breakpoint modifiers for <see cref="Brand" /> components.</summary>
public sealed class BrandWidthModifiers : FormatBreakpointStyles<string>
{
    protected override string BaseStyle { get => "pf-c-brand--Width"; }
}
