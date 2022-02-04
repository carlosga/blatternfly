using Blatternfly.Components;
using Blatternfly.Interop;
using Blatternfly.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Components.WebAssembly.Hosting;

public static class WebAssemblyHostBuilderExtensions
{
    public static WebAssemblyHostBuilder AddBlatternfly(this WebAssemblyHostBuilder builder)
    {
        // Singleton services
        builder.Services.AddSingleton<ISequentialIdGenerator, SequentialIdGenerator>();
        builder.Services.AddSingleton<IRandomIdGenerator, RandomIdGenerator>();
        builder.Services.AddSingleton<IDomUtils, DomUtils>();
        builder.Services.AddSingleton<IWindowObserver, WindowObserver>();
        builder.Services.AddSingleton<IPortalConnector, PortalConnector>();
        builder.Services.AddSingleton<IFloatingInteropModule, FloatingInteropModule>();
        builder.Services.AddSingleton<IFocusTrapInteropModule, FocusTrapInteropModule>();
        builder.Services.AddSingleton<ICalendarMonthInteropModule, CalendarMonthInteropModule>();
        builder.Services.AddSingleton<IDropdownToggleInteropModule, DropdownToggleInteropModule>();
        builder.Services.AddSingleton<ISelectToggleInteropModule, SelectToggleInteropModule>();

        // Transient services
        builder.Services.AddTransient<IResizeObserver, ResizeObserver>();

        return builder;
    }
}
