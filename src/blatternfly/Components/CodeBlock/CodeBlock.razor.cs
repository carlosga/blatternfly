namespace Blatternfly.Components;

public partial class CodeBlock : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Actions in the code block header. Should be wrapped with CodeBlockAction.</summary>
    [Parameter] public RenderFragment Actions { get; set; }

    private string CssClass => new CssBuilder("pf-c-code-block")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}
