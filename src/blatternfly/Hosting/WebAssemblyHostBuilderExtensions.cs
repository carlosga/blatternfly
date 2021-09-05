using System.Threading.Tasks;
using Blatternfly.Components;
using Blatternfly.Interop;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Components.WebAssembly.Hosting
{
    public static class WebAssemblyHostBuilderExtensions
    {
        public static WebAssemblyHostBuilder AddBlatternfly(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddSingleton<IDomUtils, DomUtils>();
            builder.Services.AddSingleton<IWindowObserver, WindowObserver>();
            builder.Services.AddSingleton<IDropdownInteropService, DropdownInteropService>();
            builder.Services.AddSingleton<ICalendarMonthInteropService, CalendarMonthInteropService>();
            
            return builder;
        }
    }
}
