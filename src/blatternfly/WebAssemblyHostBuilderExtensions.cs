using Blatternfly;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Components.WebAssembly.Hosting
{
    public static class WebAssemblyHostBuilderExtensions
    {
        public static WebAssemblyHostBuilder UseBlatternfly(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddSingleton<WindowObserver>();
            return builder;
        }
    }
}
