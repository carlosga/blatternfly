using System.Diagnostics.CodeAnalysis;
using Microsoft.JSInterop;

namespace Blatternfly.Components;

public partial class Toggle : ComponentBase, IDisposable
{
    public ElementReference Element { get; protected set; }

    [Inject] private IDropdownToggleInteropModule DropdownToggleToggleInterop { get; set; }
    [Inject] private IWindowObserver WindowObserver { get; set; }
    [Inject] private IComponentIdGenerator ComponentIdGenerator { get; set; }

    [CascadingParameter] private Dropdown Parent { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>Type to put on the button.</summary>
    [Parameter] public ButtonType? Type { get; set; }

    /// <summary>Flag to indicate if menu is opened.</summary>
    [Parameter] public bool IsOpen { get; set; }

    /// <summary>Callback called when toggle is clicked.</summary>
    [Parameter] public EventCallback<bool> OnToggle { get; set; }

    /// <summary>Callback called when the Enter key is pressed.</summary>
    [Parameter] public EventCallback OnEnter { get; set; }

    /// <summary>Forces active state.</summary>
    [Parameter] public bool IsActive { get; set; }

    /// <summary>Disables the dropdown toggle.</summary>
    [Parameter] public bool IsDisabled { get; set; }

    /// <summary>Display the toggle with no border or background.</summary>
    [Parameter] public bool? IsPlain { get; set; }

    /// <summary>Display the toggle in text only mode.</summary>
    [Parameter] public bool? IsText { get; set; }

    /// <summary>Alternate styles for the dropdown toggle button.</summary>
    [Parameter] public ToggleVariant ToggleVariant { get; set; } = ToggleVariant.Default;

    /// <summary>Style the toggle as a child of a split button.</summary>
    [Parameter] public bool IsSplitButton { get; set; }

    /// <summary>Flag for aria popup.</summary>
    [Parameter] public AriaPopupVariant? AriaHasPopup { get; set; }

    /// <summary>Allows selecting toggle to select parent.</summary>
    [Parameter] public bool BubbleEvent { get; set; }

    /// <summary>
    /// </summary>
    [Parameter] public string ToggleClass { get; set; }

    private string CssClass => new CssBuilder()
        .AddClass("pf-c-dropdown__toggle-button", IsSplitButton)
        .AddClass(ToggleClass                   , !IsSplitButton && !string.IsNullOrEmpty(ToggleClass))
        .AddClass("pf-c-dropdown__toggle"       , !IsSplitButton && string.IsNullOrEmpty(ToggleClass))
        .AddClass("pf-m-active"                 , string.IsNullOrEmpty(ToggleClass) && IsActive)
        .AddClass("pf-m-disabled"               , string.IsNullOrEmpty(ToggleClass) && IsDisabled)
        .AddClass("pf-m-plain"                  , string.IsNullOrEmpty(ToggleClass) && ((IsPlain.HasValue && IsPlain.Value) || (Parent is not null && Parent.IsPlain)))
        .AddClass("pf-m-text"                   , string.IsNullOrEmpty(ToggleClass) && IsText.HasValue && IsText.Value)
        .AddClass("pf-m-primary"                , string.IsNullOrEmpty(ToggleClass) && ToggleVariant is ToggleVariant.Primary)
        .AddClass("pf-m-secondary"              , string.IsNullOrEmpty(ToggleClass) && ToggleVariant is ToggleVariant.Secondary)
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    internal string ToggleId { get => !string.IsNullOrEmpty(InternalId) ? InternalId : Id; }

    private string Id           { get; set; }
    private string InternalId   { get => AdditionalAttributes.GetPropertyValue(HtmlElement.Id); }
    private string AriaExpanded { get => IsOpen ? "true" : "false"; }
    private string AriaPopup
    {
        get => AriaHasPopup switch
        {
            AriaPopupVariant.Menu    => "menu",
            AriaPopupVariant.Listbox => "listbox",
            AriaPopupVariant.Tree    => "tree",
            AriaPopupVariant.Grid    => "grid",
            AriaPopupVariant.Dialog  => "dialog",
            _                        => Parent?.AriaHasPopup ?? null
        };
    }
    private string ToggleButtonType
    {
        get => Type switch
        {
            ButtonType.Button => "button",
            ButtonType.Submit => "submit",
            ButtonType.Reset  => "reset",
            _                 => "button"
        };
    }

    private IDisposable _windowClickSubscription;
    public void Dispose()
    {
        _windowClickSubscription?.Dispose();
    }

    [DynamicDependency(nameof(KeydownOnToggle))]
    [DynamicDependency(nameof(KeyDownOnEnter))]
    [DynamicDependency(nameof(KeydownState))]
    protected override void OnInitialized()
    {
        base.OnInitialized();

        Parent?.RegisterToggle(this);

        Id                       = ComponentIdGenerator.Generate("pf-toggle-id");
        _windowClickSubscription = WindowObserver.OnClick.Subscribe(async e => await OnWindowClick(e));
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            var dotNetObjRef = DotNetObjectReference.Create(this);
            await DropdownToggleToggleInterop.OnKeydown(dotNetObjRef, Element);
        }
    }

    [JSInvokable]
    public async Task KeydownOnToggle()
    {
        await ToggleHandler();
        StateHasChanged();
    }

    [JSInvokable]
    public async Task KeyDownOnEnter()
    {
        IsOpen = !IsOpen;
        await OnEnter.InvokeAsync();
        StateHasChanged();
    }

    [JSInvokable]
    public Task<ToggleState> KeydownState()
    {
        return Task.FromResult(new ToggleState(IsOpen, BubbleEvent));
    }

    internal async Task CloseAsync()
    {
        IsOpen = false;
        await OnToggle.InvokeAsync(IsOpen);
    }

    internal async Task FocusAsync()
    {
        await Element.FocusAsync();
    }

    private async Task OnWindowClick(MouseEvent e)
    {
        var clickedOnToggle   = e.ComposedPath?.Any(x => x == ToggleId);
        var clickedWithinMenu = e.ComposedPath?.Any(x => x == Parent?.DropdownMenu?.MenuId);
        if (IsOpen && !(clickedOnToggle.GetValueOrDefault() || clickedWithinMenu.GetValueOrDefault()))
        {
            await CloseAsync();
            StateHasChanged();
        }
    }

    private async Task ToggleHandler()
    {
        IsOpen = !IsOpen;
        await OnToggle.InvokeAsync(IsOpen);
    }
}
