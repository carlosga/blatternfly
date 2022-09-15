namespace Blatternfly.Components;

public partial class PopoverHeader : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Indicates the header contains an icon.</summary>
    [Parameter] public RenderFragment Icon { get; set; }

    /// <summary>Heading level of the header title</summary>
    [Parameter] public HeadingLevel? TitleHeadingLevel { get; set; } = HeadingLevel.h6;

    /// <summary>Severity variants for an alert popover. This modifies the color of the header to match the severity.</summary>
    [Parameter] public AlertVariant? AlertSeverityVariant { get; set; }

    /// <summary>Text announced by screen reader when alert severity variant is set to indicate severity level</summary>
    [Parameter] public string AlertSeverityScreenReaderText { get; set; }

    private string HeaderCssClass => new CssBuilder("pf-c-popover__header")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string HeaderTitleCssClass => new CssBuilder("pf-c-popover__title")
        .AddClass("pf-m-icon", Icon is not null)
        .Build();

    private string TitleCssClass => new CssBuilder()
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private HeadingLevel TitleHeadingLevelValue { get => TitleHeadingLevel ?? HeadingLevel.h6; }
}