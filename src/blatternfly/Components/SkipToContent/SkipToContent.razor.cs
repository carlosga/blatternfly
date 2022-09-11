namespace Blatternfly.Components;

public partial class SkipToContent : ComponentBase
{
    [Inject] private IDomUtils DomUtils { get; set;  }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    public ElementReference Element { get; protected set; }

    /// <summary>The skip to content link.</summary>
    [Parameter] public string Href { get; set; }

    /// <summary>Forces the skip to component to display. This is primarily for demonstration purposes and would not normally be used.</summary>
    [Parameter] public bool Show { get; set; }

    private string CssClass => new CssBuilder("pf-c-skip-to-content")
        .AddClass("pf-c-button")
        .AddClass("pf-m-primary")
        .Build();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender && Show)
        {
            await Element.FocusAsync();
        }
    }

    private async Task ClickHandler(MouseEventArgs args)
    {
        if (!string.IsNullOrEmpty(Href))
        {
            await DomUtils.ScrollIntoViewAsync(Href[1..]);
        }
    }
}