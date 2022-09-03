namespace Blatternfly.Components;

public partial class EmptyState : ComponentBase
{
    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Modifies EmptyState max-width.
    /// </summary>
    [Parameter]
    public EmptyStateVariant Variant { get; set; } = EmptyStateVariant.Full;

    /// <summary>
    /// Cause component to consume the available height of its container.
    /// </summary>
    [Parameter]
    public bool IsFullHeight { get; set; }

    private string CssClass => new CssBuilder("pf-c-empty-state")
        .AddClass("pf-m-xs"         , Variant is EmptyStateVariant.ExtraSmall)
        .AddClass("pf-m-sm"         , Variant is EmptyStateVariant.Small)
        .AddClass("pf-m-lg"         , Variant is EmptyStateVariant.Large)
        .AddClass("pf-m-xl"         , Variant is EmptyStateVariant.ExtraLarge)
        .AddClass("pf-m-full-height", IsFullHeight)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}