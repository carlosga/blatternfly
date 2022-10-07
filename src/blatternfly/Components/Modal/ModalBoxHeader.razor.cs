namespace Blatternfly.Components;

public partial class ModalBoxHeader : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Optional help section for the modal box header.</summary>
    [Parameter] public string Help { get; set; }

    private string CssClass => new CssBuilder("pf-c-modal-box__header")
        .AddClass("pf-m-help", Help is not null)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}