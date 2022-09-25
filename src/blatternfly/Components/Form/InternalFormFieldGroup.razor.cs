namespace Blatternfly.Components;

public partial class InternalFormFieldGroup : ComponentBase
{
    [Inject] private IComponentIdGenerator ComponentIdGenerator { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Form field group header.</summary>
    [Parameter] public RenderFragment Header { get; set; }

    /// <summary>Flag indicating if the field group is expandable.</summary>
    [Parameter] public bool IsExpandable { get; set; }

    /// <summary>Flag indicate if the form field group is expanded. Modifies the card to be expandable.</summary>
    [Parameter] public bool IsExpanded { get; set; }

    /// <summary>Function callback called when user clicks toggle button.</summary>
    [Parameter] public EventCallback<MouseEventArgs> OnToggle { get; set; }

    /// <summary>Aria-label to use on the form field group toggle button.</summary>
    [Parameter] public string ToggleAriaLabel { get; set; }

    private string CssClass => new CssBuilder("pf-c-form__field-group")
        .AddClass("pf-m-expanded", IsExpanded && IsExpandable)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private FormFieldGroupHeader GroupHeader { get; set; }

    private string ToggleId { get; set; }
    private string AriaLabelledBy
    {
        get => !string.IsNullOrEmpty(GroupHeader?.TitleTextId) ? $"{GroupHeader.TitleTextId}" : null;
    }
    private string ToggleAriaLabelledBy
    {
        get => !string.IsNullOrEmpty(GroupHeader?.TitleTextId) ? $"{GroupHeader.TitleTextId} {ToggleId}" : null;
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        ToggleId = ComponentIdGenerator.Generate("form-field-group-toggle");
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (IsExpandable && string.IsNullOrEmpty(ToggleAriaLabel) && string.IsNullOrEmpty(GroupHeader?.TitleTextId))
        {
            throw new InvalidOperationException("FormFieldGroupExpandable: ToggleAriaLabel or the TitleTextId prop of FormFieldGroupHeader is required to make the toggle button accessible");
        }
    }

    internal void SetHeader(FormFieldGroupHeader header)
    {
        GroupHeader = header;
        StateHasChanged();
    }
}