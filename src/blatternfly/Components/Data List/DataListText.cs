namespace Blatternfly.Components;

public class DataListText : BaseComponent
{
    /// Determines which element to render as a data list text. Usually div or span.
    [Parameter] public string Component { get; set; } = "span";

    /// Determines which wrapping modifier to apply to the data list text.
    [Parameter] public DataListWrapModifier? WrapModifier { get; set; }

    /// Text to display on the tooltip.
    [Parameter] public string Tooltip { get; set; }

    /// Callback used to create the tooltip if text is truncated.
    [Parameter] public EventCallback<MouseEventArgs> OnMouseEnter { get; set; }

    private string CssClass => new CssBuilder("pf-c-data-list__text")
        .AddClass("pf-m-nowrap"     , WrapModifier == DataListWrapModifier.Nowrap)
        .AddClass("pf-m-truncate"   , WrapModifier == DataListWrapModifier.Truncate)
        .AddClass("pf-m-break-word" , WrapModifier == DataListWrapModifier.BreakWord)
        .Build();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(1, Component);
        builder.AddAttribute(2, "class", CssClass);
        builder.AddAttribute(3, "onmouseenter", EventCallback.Factory.Create(this, OnMouseEnter));
        builder.AddContent(4, ChildContent);
        builder.CloseElement();
    }
}
