using System.Threading.Tasks;
using Blatternfly.Interop;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Components.WebAssembly.Hosting
{
    public static class WebAssemblyHostExtensions
    {
        public static async Task UseBlatternfly(this WebAssemblyHost host)
        {
            await host.Services.GetRequiredService<IWindowObserver>().BindAsync();
        }
    }
}
