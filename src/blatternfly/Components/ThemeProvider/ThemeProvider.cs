using Microsoft.JSInterop;

namespace Blatternfly.Components;

/// <summary>Theme provider</summary>
public sealed class ThemeProvider : ComponentBase
{
    [Inject] private IJSRuntime JSRuntime { get; set; }

    /// <summary>Gets or sets a value indicating whether the dark theme should be enabled.</summary>
    [Parameter] public bool IsDarkThemeEnabled { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        if (IsDarkThemeEnabled)
        {
            await JSRuntime.InvokeVoidAsync("document.documentElement.classList.add", "pf-theme-dark");
        }
        else
        {
            await JSRuntime.InvokeVoidAsync("document.documentElement.classList.remove", "pf-theme-dark");
        }
    }
}
