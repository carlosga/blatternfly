namespace Blatternfly.Components;

public partial class Spinner : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Size variant of progress.</summary>
    [Parameter] public SpinnerSize Size { get; set; } = SpinnerSize.ExtraLarge;

    /// <summary>Text describing that current loading status or progress.</summary>
    [Parameter] public string AriaValueText { get; set; } = "Loading...";

    /// <summary>Whether to use an SVG (new) rather than a span (old).</summary>
    [Parameter] public bool IsSvg { get; set; }

    /// <summary>Diameter of spinner set as CSS variable.</summary>
    [Parameter] public string Diameter { get; set; }

    /// <summary>Accessible label to describe what is loading.</summary>
    [Parameter] public string AriaLabel { get; set; }

    /// <summary>Id of element which describes what is being loaded.</summary>
    [Parameter] public string AriaLabelledBy { get; set; }

    private string CssClass => new CssBuilder("pf-c-spinner")
        .AddClass("pf-m-sm", Size is SpinnerSize.Small)
        .AddClass("pf-m-md", Size is SpinnerSize.Medium)
        .AddClass("pf-m-lg", Size is SpinnerSize.Large)
        .AddClass("pf-m-xl", Size is SpinnerSize.ExtraLarge)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string CssStyle => new StyleBuilder()
        .AddStyle("--pf-c-spinner--diameter", Diameter, !string.IsNullOrEmpty(Diameter))
        .Build();

    private string Component { get => IsSvg ? "svg" : "span"; }
    private string ViewBox   { get => IsSvg ? "0 0 100 100" : null; }
    private string AriaLabelValue
    {
        get
        {
            if (!string.IsNullOrEmpty(AriaLabel))
            {
                return AriaLabel;
            }

            return string.IsNullOrEmpty(AriaLabel) && string.IsNullOrEmpty(AriaLabelledBy)
                ? "Contents"
                    : null;
        }
    }
}
