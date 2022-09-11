namespace Blatternfly.Components;

public partial class FormSection : ComponentBase
{
    [Inject]
    private IComponentIdGenerator ComponentIdGenerator { get; set; }

    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Content rendered inside the component.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Title for the section.
    /// </summary>
    [Parameter] public string Title { get; set; }

    /// <summary>
    /// Element to wrap the section title.
    /// </summary>
    [Parameter] public TitleElement TitleElement { get; set; }

    private string CssClass => new CssBuilder("pf-c-form__section")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string SectionId      { get; set; }
    private string AriaLabelledBy { get => SectionId; }
    private string Container      { get => TitleElement.ToString(); }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        SectionId = !string.IsNullOrEmpty(Title) ? ComponentIdGenerator.Generate("pf-form-section-title") : null;
    }
}
