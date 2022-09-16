namespace Blatternfly.Components;

public partial class DrilldownMenu : ComponentBase
{
    [CascadingParameter] private Menu ParentMenu { get; set; }
    [CascadingParameter] private MenuItem ParentMenuItem { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Flag indicating whether the menu is drilled in.</summary>
    [Parameter] public bool IsMenuDrilledIn { get; set; }

    /// <summary>Optional callback to get the height of the sub menu.</summary>
    [Parameter] public EventCallback<string> GetHeight { get; set; }

    private string InternalId   { get => AdditionalAttributes?.GetPropertyValue(HtmlElement.Id); }
    private string ParentMenuId { get => ParentMenu?.InternalId; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        ParentMenuItem?.RegisterDrilldownMenuId(InternalId);
    }
}