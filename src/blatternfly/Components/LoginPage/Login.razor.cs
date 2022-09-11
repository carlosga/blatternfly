namespace Blatternfly.Components;

public partial class Login : ComponentBase
{
    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Footer component (e.g. <see cref="LoginFooter" /> )).
    /// </summary>
    [Parameter] public RenderFragment Footer { get; set; }

    /// <summary>
    /// Header component (e.g. <see cref="LoginHeader" />).
    /// </summary>
    [Parameter] public RenderFragment Header { get; set; }

    private string CssClass => new CssBuilder("pf-c-login")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}