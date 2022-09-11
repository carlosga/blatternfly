namespace Blatternfly.Components;

public partial class LoginMainBody : ComponentBase
{
    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    private string CssClass => new CssBuilder("pf-c-login__main-body")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}