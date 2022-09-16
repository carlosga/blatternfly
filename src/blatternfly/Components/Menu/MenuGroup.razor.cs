namespace Blatternfly.Components;

public partial class MenuGroup : ComponentBase
{
    public ElementReference Element { get; protected set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Group label.</summary>
    [Parameter] public string Label { get; set; }

    /// <summary>ID for title label.</summary>
    [Parameter] public string TitleId { get; set; }

    /// <summary>Group label heading level. Default is h1.</summary>
    [Parameter] public HeadingLevel LabelHeadingLevel { get; set; } = HeadingLevel.h1;

    private string CssClass => new CssBuilder("pf-c-menu__group")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}