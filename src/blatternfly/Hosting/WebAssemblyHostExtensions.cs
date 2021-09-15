using System.Threading.Tasks;
using Blatternfly.Components;
using Blatternfly.Interop;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Components.WebAssembly.Hosting
{
    public static class WebAssemblyHostExtensions
    {
        public static async Task UseBlatternfly(this WebAssemblyHost host)
        {
            await host.Services.GetRequiredService<IDomUtils>().ImportAsync();
            await host.Services.GetRequiredService<IWindowObserver>().ImportAsync();
            await host.Services.GetRequiredService<ICalendarMonthInteropModule>().ImportAsync();
            await host.Services.GetRequiredService<IDropdownToggleInteropModule>().ImportAsync();
            await host.Services.GetRequiredService<ISelectToggleInteropModule>().ImportAsync();
        }
    }
}
