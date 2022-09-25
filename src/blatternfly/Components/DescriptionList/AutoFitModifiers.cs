namespace Blatternfly.Components;

/// <summary>Auto-fit modifiers.</summary>
public sealed class AutoFitModifiers : FormatBreakpointStyles<string>
{
    protected override string BaseStyle { get => "pf-c-description-list--GridTemplateColumns--min"; }
}
