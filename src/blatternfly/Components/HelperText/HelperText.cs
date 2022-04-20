namespace Blatternfly.Components;

public class HelperText : ComponentBase
{
    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// Content rendered inside the component.
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// Component type of the helper text container.
    [Parameter] public HelperTextComponent Component { get; set; } = HelperTextComponent.div;

    /// ID for the helper text container. The value of this prop can be passed into a form component's
    /// aria-describedby prop when you intend for all helper text items to be announced to
    /// assistive technologies.
    [Parameter] public string id { get; set; }

    /// Flag for indicating whether the helper text container is a live region. Use this prop when you
    /// expect or intend for any helper text items within the container to be dynamically updated.
    [Parameter] public bool IsLiveRegion { get; set; }

    private string CssClass => new CssBuilder("pf-c-helper-text")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, Component.ToString());
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "id", id);
        builder.AddAttribute(3, "class", CssClass);
        builder.AddAttribute(4, "aria-live", IsLiveRegion ? "polite" : null);
        builder.AddContent(5, ChildContent);
        builder.CloseElement();
    }
}
