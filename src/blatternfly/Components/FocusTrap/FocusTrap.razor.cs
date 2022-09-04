using Microsoft.JSInterop;

namespace Blatternfly.Components;

public partial class FocusTrap : ComponentBase, IAsyncDisposable
{
    [Inject] private IFocusTrapInteropModule FocusTrapInterop { get; set; }

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

    /// <summary>
    ///
    /// </summary>
    [Parameter]
    public bool Active { get; set; } = true;

    /// <summary>
    ///
    /// </summary>
    [Parameter]
    public bool Paused { get; set; }

    /// <summary>
    ///
    /// </summary>
    [Parameter]
    public bool PreventScrollOnDeactivate { get; set; }

    /// <summary>
    ///
    /// </summary>
    [Parameter]
    public FocusTrapOptions FocusTrapOptions { get; set; }

    private ElementReference   Element           { get; set; }
    private IJSObjectReference FocusTrapInstance { get; set; }

    public async ValueTask DisposeAsync()
    {
        if (FocusTrapInstance is not null)
        {
            await FocusTrapInterop.DeactivateAsync(FocusTrapInstance);
            await FocusTrapInstance.DisposeAsync();
        }
    }

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        var active = Active;
        var paused = Paused;

        await base.SetParametersAsync(parameters);

        if (FocusTrapInstance is not null)
        {
            if (active && !Active)
            {
                await FocusTrapInterop.DeactivateAsync(FocusTrapInstance);
            }
            else if (!active && Active)
            {
                await FocusTrapInterop.ActivateAsync(FocusTrapInstance);
            }
            if (paused && !Paused)
            {
                await FocusTrapInterop.UnpauseAsync(FocusTrapInstance);
            }
            else if (!paused && Paused)
            {
                await FocusTrapInterop.PauseAsync(FocusTrapInstance);
            }
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            FocusTrapInstance = await FocusTrapInterop.CreateAsync(Element, FocusTrapOptions);
            if (Active)
            {
                await FocusTrapInterop.ActivateAsync(FocusTrapInstance);
            }
            if (Paused)
            {
                await FocusTrapInterop.PauseAsync(FocusTrapInstance);
            }
            }
    }
}