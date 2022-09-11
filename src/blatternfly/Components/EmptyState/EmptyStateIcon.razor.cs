namespace Blatternfly.Components;

public partial class EmptyStateIcon : ComponentBase
{
    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Adds empty state icon variant styles.
    /// </summary>
    [Parameter] public EmptyStateIconVariant Variant { get; set; } = EmptyStateIconVariant.Icon;

    private string CssClass => new CssBuilder("pf-c-empty-state__icon")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string InternalId { get => AdditionalAttributes.GetPropertyValue(HtmlAttributes.Id); }
}