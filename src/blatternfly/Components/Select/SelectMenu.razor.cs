namespace Blatternfly.Components;

public partial class SelectMenu : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Flag indicating that the children is custom content to render inside the SelectMenu.
    /// If true, variant prop is ignored.
    /// </summary>
    [Parameter] public bool IsCustomContent { get; set; }

    /// <summary>Flag indicating the Select is expanded.</summary>
    [Parameter] public bool IsExpanded { get; set; }

    /// <summary>Flag indicating the Select options are grouped.</summary>
    [Parameter] public bool IsGrouped { get; set; }

    /// <summary>Currently selected option (for single, typeahead variants).</summary>
    [Parameter] public string Selected {  get; set; }

    /// <summary>@hide Internal flag for specifying how the menu was opened.</summary>
    [Parameter] public bool OpenedOnEnter { get; set; }

    /// <summary>Flag to specify the  maximum height of the menu, as a string percentage or number of pixels.</summary>
    [Parameter] public string MaxHeight { get; set; }

    /// <summary>Indicates where menu will be alligned horizontally.</summary>
    [Parameter] public SelectPosition Position { get; set; } = SelectPosition.Left;

    /// <summary>Content rendered in the footer of the select menu.</summary>
    [Parameter] public RenderFragment Footer { get; set; }

    /// <summary>@hide Internal callback for keyboard navigation.</summary>
    [Parameter] public Action<int, int, string> KeyHandler { get; set; }

    private string CssClass => new CssBuilder()
        .AddClass("pf-c-select__menu"     , Footer is null)
        .AddClass("pf-c-select__menu-list", Footer is not null)
        .AddClass("pf-m-align-right"      , Position is SelectPosition.Right)
        .Build();

    private string Style { get => "overflow: 'auto';" + (!string.IsNullOrEmpty(MaxHeight) ? $"max-height: {MaxHeight}" : ""); }
}