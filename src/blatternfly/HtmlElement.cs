namespace Blatternfly;

public sealed class HtmlElement : ComponentBase
{
    internal static string Id = "id";

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    /// <summary>HTML element to render ( div, span, ul, li, ... )</summary>
    [Parameter]
    public string Component { get; set; }

    private string CssClass => new CssBuilder()
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string CssStyle => new StyleBuilder()
        .AddStyleFromAttributes(AdditionalAttributes)
        .Build();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, Component);
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "class", CssClass);
        builder.AddAttribute(3, "style", CssStyle);
        builder.AddContent(4, ChildContent);
        builder.CloseElement();
    }
}
