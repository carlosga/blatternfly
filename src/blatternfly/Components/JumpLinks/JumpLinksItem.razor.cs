namespace Blatternfly.Components;

public partial class JumpLinksItem : ComponentBase
{
    public ElementReference AnchorElement { get; protected set; }

    [Inject] private IDomUtils DomUtils { get; set; }

    [CascadingParameter] private JumpLinks Parent { get; set; }

    /// <summary>Parent JumpLinksItem component.</summary>
    [CascadingParameter] public JumpLinksItem ParentItem { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Whether this item is active. Parent JumpLinks component sets this when passed a `scrollableSelector`.</summary>
    [Parameter] public bool IsActive { get; set; }

    /// <summary>Href for this link.</summary>
    [Parameter] public string Href { get; set; }

    /// <summary>Click handler for anchor tag. Parent JumpLinks components tap into this.</summary>
    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

    /// <summary></summary>
    [Parameter] public RenderFragment SubLists { get; set; }

    private string CssClass => new CssBuilder("pf-c-jump-links__item")
        .AddClass("pf-m-current", IsActive)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string AriaCurrent { get => IsActive ? "location" : null; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Parent.RegisterItem(this);
    }

    internal void Activate()
    {
        IsActive = true;
        StateHasChanged();
    }

    internal void Deactivate()
    {
        IsActive = false;
        StateHasChanged();
    }

    private async Task ClickHandler(MouseEventArgs args)
    {
        if (!string.IsNullOrEmpty(Href))
        {
            try
            {
                await Parent.LockScrollAsync();
                await DomUtils.ScrollIntoViewAsync(Href[1..]);
                await OnClick.InvokeAsync(args);
                Parent.ActivateItem(this);
            }
            catch
            {
                throw;
            }
            finally
            {
                await Parent.UnlockScrollAsync();
            }
        }
    }
}