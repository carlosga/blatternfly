namespace Blatternfly.Components;

public partial class WizardHeader : ComponentBase
{
    /// <summary>Callback function called when the X (Close) button is clicked.</summary>
    [Parameter] public EventCallback<MouseEventArgs> OnClose { get; set; }

    /// <summary>Title of the wizard.</summary>
    [Parameter] public string Title { get; set; }

    /// <summary>Description of the wizard.</summary>
    [Parameter] public RenderFragment Description { get; set; }

    /// <summary>Component type of the description.</summary>
    [Parameter] public WizardDescriptionComponent DescriptionComponent { get; set; } = WizardDescriptionComponent.p;

    /// <summary>Flag indicating whether the close button should be in the header.</summary>
    [Parameter] public bool HideClose { get; set; }

    /// <summary>Aria-label applied to the X (Close) button.</summary>
    [Parameter] public string CloseButtonAriaLabel { get; set; }

    /// <summary>id for the title.</summary>
    [Parameter] public string TitleId { get; set; }

    /// <summary>id for the description.</summary>
    [Parameter] public string DescriptionId { get; set; }
}