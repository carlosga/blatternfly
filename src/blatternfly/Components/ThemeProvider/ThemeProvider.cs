using Microsoft.JSInterop;

namespace Blatternfly.Components;

public class ThemeProvider : ComponentBase
{
    [Inject] public IJSRuntime JSRuntime { get; set; }

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
