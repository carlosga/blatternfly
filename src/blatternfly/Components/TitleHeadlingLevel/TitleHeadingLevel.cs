namespace Blatternfly.Components;

public class TitleHeadingLevel : ComponentBase
{
    public ElementReference Element { get; protected set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Heading level (h1/2/3/4/5/6).</summary>
    [Parameter] public HeadingLevel HeadingLevel { get; set; } = HeadingLevel.h4;

    private string Component
    {
        get => HeadingLevel switch
        {
            HeadingLevel.h1 => "h1",
            HeadingLevel.h2 => "h2",
            HeadingLevel.h3 => "h3",
            HeadingLevel.h4 => "h4",
            HeadingLevel.h5 => "h5",
            HeadingLevel.h6 => "h6",
            _               => null
        };
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, Component);
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        builder.AddContent(2, ChildContent);
        builder.AddElementReferenceCapture(3, __reference => Element = __reference);
        builder.CloseElement();
    }
}
