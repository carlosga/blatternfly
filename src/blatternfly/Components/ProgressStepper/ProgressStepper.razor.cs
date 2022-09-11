namespace Blatternfly.Components;

public partial class ProgressStepper : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Flag indicating the progress stepper should be centered.</summary>
    [Parameter] public bool IsCenterAligned { get; set; }

    /// <summary>Flag indicating the progress stepper has a vertical layout.</summary>
    [Parameter] public bool IsVertical { get; set; }

    /// <summary>Flag indicating the progress stepper should be rendered compactly.</summary>
    [Parameter] public bool IsCompact { get; set; }

    private string CssClass => new CssBuilder("pf-c-progress-stepper")
        .AddClass("pf-m-center"   , IsCenterAligned)
        .AddClass("pf-m-vertical" , IsVertical)
        .AddClass("pf-m-compact"  , IsCompact)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}