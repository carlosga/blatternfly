namespace Blatternfly.Components;

public partial class ExpandableSectionToggle : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Flag indicating if the expandable section is expanded.</summary>
    [Parameter] public bool IsExpanded { get; set; }

    /// <summary>Callback function to toggle the expandable content.</summary>
    [Parameter] public EventCallback<bool> OnToggle { get; set; }

    /// <summary>ID of the toggle's respective expandable section content.</summary>
    [Parameter] public string ContentId { get; set; }

    /// <summary>Direction the toggle arrow should point when the expandable section is expanded.</summary>
    [Parameter] public ExpandableSectionToggleDirection? Direction { get; set; } = ExpandableSectionToggleDirection.Down;

    private string CssClass => new CssBuilder("pf-c-expandable-section")
        .AddClass("pf-m-detached")
        .AddClass("pf-m-expanded", IsExpanded)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string IconCssClass => new CssBuilder("pf-c-expandable-section__toggle-icon")
        .AddClass("pf-m-expand-top", Direction is ExpandableSectionToggleDirection.Up)
        .Build();

    private async Task OnHandleToggle(MouseEventArgs args)
    {
        IsExpanded = !IsExpanded;
        await OnToggle.InvokeAsync(IsExpanded);
    }
}
