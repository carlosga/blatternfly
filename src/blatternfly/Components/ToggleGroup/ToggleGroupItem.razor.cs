namespace Blatternfly.Components;

public partial class ToggleGroupItem : ComponentBase
{
    [CascadingParameter] private ToggleGroup Parent { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Text rendered inside the toggle group item.</summary>
    [Parameter] public RenderFragment Text { get; set; }

    /// <summary>Icon rendered inside the toggle group item.</summary>
    [Parameter] public RenderFragment Icon { get; set; }

    /// <summary>Flag indicating if the toggle group item is disabled.</summary>
    [Parameter] public bool IsDisabled { get; set; }

    /// <summary>Flag indicating if the toggle group item is selected.</summary>
    [Parameter] public bool IsSelected { get; set; }

    /// <summary>required when icon is used with no supporting text.</summary>
    [Parameter] public string AriaLabel { get; set; }

    /// <summary>Optional id for the button within the toggle group item.</summary>
    [Parameter] public string ButtonId { get; set; }

    /// <summary>A callback for when the toggle group item selection changes.</summary>
    [Parameter] public EventCallback<bool> IsSelectedChanged { get; set; }

    private string CssClass => new CssBuilder("pf-c-toggle-group__item")
      .AddClassFromAttributes(AdditionalAttributes)
      .Build();

    private string ButtonCssClass => new CssBuilder("pf-c-toggle-group__button")
      .AddClass("pf-m-selected", IsSelected)
      .Build();

    private bool?  IsDisabledValue      { get => AreAllGroupsDisabled ? true : IsDisabled; }
    private bool   AreAllGroupsDisabled { get => Parent?.AreAllGroupsDisabled ?? false; }
    private string AriaPressed          { get => IsSelected ? "true": "false"; }

    private async Task HandleChange(MouseEventArgs _)
    {
        await IsSelectedChanged.InvokeAsync(!IsSelected);
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (string.IsNullOrEmpty(AriaLabel) && Icon is not null && Text is null)
        {
            throw new Exception("An accessible aria-label is required when using the toggle group item icon variant.");
        }
    }
}