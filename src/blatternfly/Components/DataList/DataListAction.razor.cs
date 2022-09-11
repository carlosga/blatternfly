namespace Blatternfly.Components;

public partial class DataListAction : ComponentBase
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
    /// What breakpoints to hide/show the data list action.
    /// </summary>
    [Parameter] public VisibilityModifiers Visibility { get; set; }

    /// <summary>
    /// Flag to indicate that the action is a plain button (e.g. kebab dropdown toggle)
    /// so that styling is applied to align the button.
    /// </summary>
    [Parameter] public bool IsPlainButtonAction { get; set; }

    private string CssClass => new CssBuilder("pf-c-data-list__item-action")
        .AddClass(Visibility?.CssClass())
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}
