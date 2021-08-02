using System.Threading.Tasks;
using Blatternfly.Observers;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Components.WebAssembly.Hosting
{
    public static class WebAssemblyHostExtensions
    {
        public static async Task UseBlatternfly(this WebAssemblyHost host)
        {
            await host.Services.GetRequiredService<IWindowObserver>().OnbserveAsync();
        }
    }
}
