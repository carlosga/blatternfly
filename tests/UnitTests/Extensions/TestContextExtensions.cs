using Blatternfly.Components;
using Blatternfly.Interop;
using Bunit.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Bunit
{
    public static class TestContextExtensions
    {
        public static TestContext SetupJavascriptInterop(this TestContext ctx)
        {
            ctx.JSInterop.Mode = JSRuntimeMode.Strict;
            
            // Register services
            ctx.Services.AddSingleton<IDomUtils>(new DomUtilsMock());
            ctx.Services.AddSingleton<IDropdownInteropService>(new DropdownInteropMockService());
            ctx.Services.AddSingleton<IWindowObserver>(new WindowObserverMock());

            return ctx;
        }
    }
}
