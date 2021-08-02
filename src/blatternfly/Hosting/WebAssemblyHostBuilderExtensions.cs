using System.Threading.Tasks;
using Blatternfly.Observers;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Components.WebAssembly.Hosting
{
    public static class WebAssemblyHostBuilderExtensions
    {
        public static WebAssemblyHostBuilder AddBlatternfly(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddSingleton<IWindowObserver, WindowObserver>();
            
            return builder;
        }
    }
}
