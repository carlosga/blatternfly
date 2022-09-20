namespace Blatternfly.Components;

public partial class WizardBody : ComponentBase
{
    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Set to true to remove the default body padding.</summary>
    [Parameter] public bool HasNoBodyPadding { get; set; }

    /// <summary>An aria-label to use for the main element.</summary>
    [Parameter] public string AriaLabel { get; set; }

    /// <summary>Sets the aria-labelledby attribute for the main element.</summary>
    [Parameter] public string AriaLabelledBy { get; set; }

    /// <summary>Component used as the primary content container.</summary>
    [Parameter] public string MainComponent { get; set; } = "div";

    /// <summary>The currently active WizardStep.</summary>
    [Parameter] public WizardStep ActiveStep { get; set; }

    /// <summary>Flag indicating whether the wizard body has a drawer.</summary>
    [Parameter] public bool HasDrawer { get; set; }

    /// <summary>Flag indicating the wizard drawer is expanded.</summary>
    [Parameter] public bool IsDrawerExpanded { get; set; }

    private string CssClass => new CssBuilder("pf-c-wizard__main")
        .Build();

    private string MainBodyCssClass => new CssBuilder("pf-c-wizard__main-body")
        .AddClass("pf-m-no-padding", HasNoBodyPadding)
        .Build();

    private bool WrapperWithDrawer
    {
        get => HasDrawer && ActiveStep is not null && ActiveStep.DrawerPanelContent is not null;
    }
}
