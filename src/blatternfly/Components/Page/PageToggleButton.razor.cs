namespace Blatternfly.Components;

public partial class PageToggleButton : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>True if the side nav is shown.</summary>
    [Parameter] public bool IsNavOpen { get; set; } = true;

    /// <summary>Adds accessible text to the button.</summary>
    [Parameter] public string AriaLabel { get; set; }

    /// <summary>
    /// Callback function to handle the side nav toggle button,
    /// managed by the Page component if the Page isManagedSidebar prop is set to true.
    /// </summary>
    [Parameter] public EventCallback<bool> OnNavToggle { get; set; }

    private string InternalId     { get => AdditionalAttributes?.GetPropertyValue(HtmlElement.Id); }
    private string ToggleButtonId { get => !string.IsNullOrEmpty(InternalId) ? InternalId : "nav-toggle"; }
    private string AriaExpanded   { get => IsNavOpen ? "true" : "false"; }
    private string AriaLabelValue { get => string.IsNullOrEmpty(AriaLabel) ? "Side navigation toggle" : AriaLabel; }

    private async Task ToggleHandler(MouseEventArgs _)
    {
        IsNavOpen = !IsNavOpen;
        await OnNavToggle.InvokeAsync(IsNavOpen);
    }
}