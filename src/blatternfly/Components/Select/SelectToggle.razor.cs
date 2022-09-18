using System.Diagnostics.CodeAnalysis;
using Microsoft.JSInterop;

namespace Blatternfly.Components;

public partial class SelectToggle : ComponentBase
{
    public ElementReference Element { get; protected set; }

    [Inject] private ISelectToggleInteropModule SelectToggleInterop { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Content rendered inside the component.</summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>HTML ID of dropdown toggle.</summary>
    [Parameter] public string Id { get; set; }

    /// <summary>Flag to indicate if select is open.</summary>
    [Parameter] public bool IsOpen { get; set; }

    /// <summary>Callback called when toggle is clicked.</summary>
    [Parameter] public EventCallback<bool> OnToggle { get; set; }

    /// <summary>Callback for toggle open on keyboard entry.</summary>
    [Parameter] public EventCallback OnEnter { get; set; }

    /// <summary>Callback for toggle close.</summary>
    [Parameter] public EventCallback OnClose { get; set; }

    /// <summary>Forces active state.</summary>
    [Parameter] public bool IsActive { get; set; }

    /// <summary>Display the toggle with no border or background.</summary>
    [Parameter] public bool IsPlain { get; set; }

    /// <summary>Flag indicating if select is disabled.</summary>
    [Parameter] public bool IsDisabled { get; set; }

    /// <summary>Flag indicating if placeholder styles should be applied.</summary>
    [Parameter] public bool HasPlaceholderStyle { get; set; }

    /// <summary>Type of the toggle button, defaults to 'button'.</summary>
    [Parameter] public ButtonType? Type { get; set; } = ButtonType.Button;

    /// <summary>Id of label for the Select aria-labelledby.</summary>
    [Parameter] public string AriaLabelledBy { get; set; }

    /// <summary>Label for toggle of select variants.</summary>
    [Parameter] public string AriaLabel { get; set; }

    /// <summary>Flag for variant, determines toggle rules and interaction.</summary>
    [Parameter] public SelectVariant Variant { get; set; }

    /// <summary>Flag indicating if select toggle has an clear button.</summary>
    [Parameter] public bool HasClearButton { get; set; }

    /// <summary>Flag indicating if select menu has a footer.</summary>
    [Parameter] public bool HasFooter { get; set; }

    private string CssClass => new CssBuilder("pf-c-select__toggle")
        .AddClass("pf-m-disabled"   , IsDisabled)
        .AddClass("pf-m-plain"      , IsPlain)
        .AddClass("pf-m-active"     , IsActive)
        .AddClass("pf-m-placeholder", HasPlaceholderStyle)
        .Build();

    private string AriaExpanded { get => IsOpen ? "true" : "false"; }
    private string ButtonToggleType
    {
        get => Type switch
        {
            ButtonType.Button => "button",
            ButtonType.Submit => "submit",
            ButtonType.Reset  => "reset",
            _                 => "button"
        };
    }

    [DynamicDependency(nameof(KeydownState))]
    [DynamicDependency(nameof(KeydownOnToggle))]
    [DynamicDependency(nameof(KeyDownOnEnter))]
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            var dotNetObjRef = DotNetObjectReference.Create(this);
            await SelectToggleInterop.OnKeydown(dotNetObjRef, Element);
        }
    }

    [JSInvokable]
    public Task<ToggleState> KeydownState()
    {
        return Task.FromResult(new ToggleState(IsOpen, false));
    }

    [JSInvokable]
    public async Task KeydownOnToggle()
    {
        IsOpen = !IsOpen;
        await OnToggle.InvokeAsync(IsOpen);
        await OnClose.InvokeAsync();
        await Element.FocusAsync();
        StateHasChanged();
    }

    [JSInvokable]
    public async Task KeyDownOnEnter()
    {
        IsOpen = !IsOpen;
        await OnToggle.InvokeAsync(IsOpen);
        await OnEnter.InvokeAsync();
        StateHasChanged();
    }

    private async Task ToggleHandler(MouseEventArgs args)
    {
        IsOpen = !IsOpen;
        await OnToggle.InvokeAsync(IsOpen);
        if (IsOpen)
        {
            await OnClose.InvokeAsync();
        }
    }
}