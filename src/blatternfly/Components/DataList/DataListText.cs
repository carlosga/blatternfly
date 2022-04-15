namespace Blatternfly.Components;

public class DataListText : ComponentBase
{
    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// Content rendered inside the component.
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// Determines which element to render as a data list text. Usually div or span.
    [Parameter] public string Component { get; set; } = "span";

    /// Determines which wrapping modifier to apply to the data list text.
    [Parameter] public DataListWrapModifier? WrapModifier { get; set; }

    /// Text to display on the tooltip.
    [Parameter] public string Tooltip { get; set; }

    /// Callback used to create the tooltip if text is truncated.
    [Parameter] public EventCallback<MouseEventArgs> OnMouseEnter { get; set; }

    private string CssClass => new CssBuilder("pf-c-data-list__text")
        .AddClass("pf-m-nowrap"     , WrapModifier is DataListWrapModifier.Nowrap)
        .AddClass("pf-m-truncate"   , WrapModifier is DataListWrapModifier.Truncate)
        .AddClass("pf-m-break-word" , WrapModifier is DataListWrapModifier.BreakWord)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, Component);
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);
        builder.AddAttribute(3, "onmouseenter", EventCallback.Factory.Create(this, OnMouseEnter));
        builder.AddContent(4, ChildContent);
        builder.CloseElement();
    }
}
