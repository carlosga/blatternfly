namespace Blatternfly.Components;

public partial class ModalBox : ComponentBase
{
    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Variant of the modal.</summary>
    [Parameter] public ModalVariant Variant { get; set; } = ModalVariant.Default;

    /// <summary>Alternate position of the modal.</summary>
    [Parameter] public ModalPosition? Position { get; set; }

    /// <summary>Offset from alternate position. Can be any valid CSS length/percentage.</summary>
    [Parameter] public string PositionOffset { get; set; }

    /// <summary>Id to use for Modal Box label.</summary>
    [Parameter] public string AriaLabelledBy { get; set; }

    /// <summary>Accessible descriptor of modal.</summary>
    [Parameter] public string AriaLabel { get; set; }

    /// <summary>Id to use for Modal Box description.</summary>
    [Parameter] public string AriaDescribedBy { get; set; }

    private string CssStyle => new StyleBuilder()
        .AddStyle("--pf-c-modal-box--m-align-top--spacer", PositionOffset)
        .AddStyleFromAttributes(AdditionalAttributes)
        .Build();

    private string CssClass => new CssBuilder("pf-c-modal-box")
        .AddClass("pf-m-align-top" , Position is ModalPosition.Top)
        .AddClass("pf-m-sm"        , Variant  is ModalVariant.Small)
        .AddClass("pf-m-md"        , Variant  is ModalVariant.Medium)
        .AddClass("pf-m-lg"        , Variant  is ModalVariant.Large)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();
}