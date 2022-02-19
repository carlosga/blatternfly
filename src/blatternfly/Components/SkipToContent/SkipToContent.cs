using System.Threading.Tasks;

namespace Blatternfly.Components;

public class SkipToContent : BaseComponent
{
    public ElementReference Element { get; protected set; }

    /// The skip to content link.
    [Parameter] public string Href { get; set; }

    /// Forces the skip to component to display. This is primarily for demonstration purposes and would not normally be used. */
    [Parameter] public bool Show { get; set; }

    private string CssClass => new CssBuilder("pf-c-skip-to-content")
        .AddClass("pf-c-button")
        .AddClass("pf-m-primary")
        .Build();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(1, "a");
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        builder.AddAttribute(3, "class", CssClass);
        builder.AddAttribute(4, "href", Href);
        builder.AddElementReferenceCapture(5, __inputReference => Element = __inputReference);
        builder.AddContent(6, ChildContent);
        builder.CloseElement();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            if (Show)
            {
                await Task.Yield();
                await Element.FocusAsync();
            }
        }
    }
}
