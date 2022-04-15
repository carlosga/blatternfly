namespace Blatternfly.Components;

public class Spinner : ComponentBase
{
    /// Additional attributes that will be applied to the component.
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// Size variant of progress.
    [Parameter] public SpinnerSize Size { get; set; } = SpinnerSize.ExtraLarge;

    /// Text describing that current loading status or progress.
    [Parameter] public string AriaValueText { get; set; } = "Loading...";

    /// Whether to use an SVG (new) rather than a span (old).
    [Parameter] public bool IsSvg { get; set; }

    /// Diameter of spinner set as CSS variable.
    [Parameter] public string Diameter { get; set; }

    /// Accessible label to describe what is loading.
    [Parameter] public string AriaLabel { get; set; }

    /// Id of element which describes what is being loaded.
    [Parameter] public string AriaLabelledBy { get; set; }

    private string CssClass => new CssBuilder("pf-c-spinner")
        .AddClass("pf-m-sm", Size is SpinnerSize.Small)
        .AddClass("pf-m-md", Size is SpinnerSize.Medium)
        .AddClass("pf-m-lg", Size is SpinnerSize.Large)
        .AddClass("pf-m-xl", Size is SpinnerSize.ExtraLarge)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var component = IsSvg ? "svg" : "span";

        builder.OpenElement(0, component);
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddAttribute(2, "aria-valuetext", AriaValueText);
        builder.AddAttribute(3, "class", CssClass);
        builder.AddAttribute(4, "role", "progressbar");

        if (IsSvg)
        {
            builder.AddAttribute(5, "viewBox", "0 0 100 100");
        }
        if (!string.IsNullOrEmpty(Diameter))
        {
            builder.AddAttribute(6, "style", $"--pf-c-spinner--diameter:{Diameter}");
        }

        if (!string.IsNullOrEmpty(AriaLabel))
        {
            builder.AddAttribute(7, "aria-label", AriaLabel);
        }
        if (!string.IsNullOrEmpty(AriaLabelledBy))
        {
            builder.AddAttribute(8, "aria-labelledBy", AriaLabelledBy);
        }

        if (string.IsNullOrEmpty(AriaLabel) && string.IsNullOrEmpty(AriaLabelledBy))
        {
            builder.AddAttribute(9, "aria-label", "Contents");
        }

        if (IsSvg)
        {
            builder.OpenElement(10, "circle");
            builder.AddAttribute(11, "class", "pf-c-spinner__path");
            builder.AddAttribute(12, "cx", "50");
            builder.AddAttribute(13, "cy", "50");
            builder.AddAttribute(14, "r", "45");
            builder.AddAttribute(15, "fill", "none");
            builder.CloseElement();
        }
        else
        {
            builder.OpenElement(16, "span");
            builder.AddAttribute(17, "class", "pf-c-spinner__clipper");
            builder.CloseElement();

            builder.OpenElement(18, "span");
            builder.AddAttribute(19, "class", "pf-c-spinner__lead-ball");
            builder.CloseElement();

            builder.OpenElement(20, "span");
            builder.AddAttribute(21, "class", "pf-c-spinner__tail-ball");
            builder.CloseElement();
        }

        builder.CloseElement();
    }
}
