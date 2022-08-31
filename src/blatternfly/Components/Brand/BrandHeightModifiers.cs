namespace Blatternfly.Components;

/// <summary>
/// Heights breakpoint modifiers for <see cref="Brand" /> components.
/// </summary>
public sealed class BrandHeightModifiers : FormatBreakpointStyles<string>
{
    protected override string BaseStyle { get => "pf-c-brand--Height"; }
}
