using System.Diagnostics.CodeAnalysis;

namespace Blatternfly.Components;

public partial class OptionsToggle : ComponentBase
{
    [Inject] private IComponentIdGenerator ComponentIdGenerator { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }


    /// <summary>The first index of the items being paginated.</summary>
    [Parameter] public int FirstIndex { get; set; }

    /// <summary>Flag indicating if the options menu is disabled.</summary>
    [Parameter] public bool IsDisabled { get; set; }

    /// <summary>Flag indicating if the options menu dropdown is open or not.</summary>
    [Parameter] public bool IsOpen { get; set; }

    /// <summary>The total number of items being paginated.</summary>
    [Parameter] public int? ItemCount { get; set; }

    /// <summary>The title of the pagination options menu.</summary>
    [Parameter] public string ItemsPerPageTitle { get; set; } = "Items per page";

    /// <summary>The type or title of the items being paginated.</summary>
    [Parameter] public string ItemsTitle { get; set; } = "items";

    /// <summary>The last index of the items being paginated.</summary>
    [Parameter] public int LastIndex { get; set; }

    /// <summary>Label for the English word "of".</summary>
    [Parameter] public string OfWord { get; set; } = "of";

    /// <summary>Callback for toggle open on keyboard entry.</summary>
    [Parameter] public EventCallback OnEnter { get; set; }

    /// <summary>Event function that fires when user clicks the options menu toggle.</summary>
    [Parameter] public EventCallback<bool> OnToggle { get; set; }

    /// <summary>Id added to the options toggle.</summary>
    [Parameter] public string OptionsToggleId { get; set; }

    /// <summary>The text to be displayed on the options toggle.</summary>
    [Parameter] public string OptionsToggleText { get; set; }

    /// <summary>
    /// Component to be used for wrapping the toggle contents.
    /// Use 'button' when you want all of the toggle text to be clickable.
    /// </summary>
    [Parameter] public PerPageComponents PerPageComponent { get; set; } = PerPageComponents.div;

    /// <summary>showToggle.</summary>
    [Parameter] public bool ShowToggle { get; set; } = true;

    /// <summary></summary>
    [Parameter] public string ToggleIndicatorClass { get; set; }

    /// <summary>This will be shown in pagination toggle span. You can use firstIndex, lastIndex, itemCount, itemsTitle props.</summary>
    [Parameter] public RenderFragment<ToggleTemplateProps> ToggleTemplate { get; set; }

    /// <summary></summary>
    [Parameter] public string ToggleTextClass { get; set; }

    /// <summary>Id added to the title of the pagination options menu.</summary>
    [Parameter] public string WidgetId { get; set; }

    private ToggleTemplateProps CustomToggleTemplateProps => new(FirstIndex, LastIndex, ItemCount, ItemsTitle, OfWord);

    private string CssClass => new CssBuilder()
        .AddClass("pf-c-options-menu__toggle")
        .AddClass("pf-m-disabled", IsDisabled)
        .AddClass("pf-m-plain")
        .AddClass("pf-m-text")
        .Build();

    private string DropdownToggleCssClass { get => IsDiv ? "pf-c-options-menu__toggle-button" : CssClass; }

    private bool IsDiv { get => PerPageComponent is PerPageComponents.div; }
    private string ComponentId { get; set; }
    private string DropdownToggleId
    {
        get => !string.IsNullOrEmpty(OptionsToggleId) ? OptionsToggleId : ComponentId;
    }

    private string DropdownAriaLabel { get => IsDiv ? OptionsToggleText ?? "Items per page" : OptionsToggleText; }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        ComponentId = ComponentIdGenerator.Generate($"{WidgetId}-toggle");
    }
}