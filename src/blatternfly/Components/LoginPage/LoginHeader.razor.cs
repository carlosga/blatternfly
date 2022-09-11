namespace Blatternfly.Components;

public partial class LoginHeader : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Header brand component (e.g. <see cref="LoginHeader" />).</summary>
    [Parameter] public RenderFragment HeaderBrand { get; set; }

    private string CssClass => new CssBuilder("pf-c-login__header")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}