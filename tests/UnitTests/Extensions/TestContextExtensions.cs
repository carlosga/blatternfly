using Blatternfly.UnitTests.Interop;

namespace Bunit;

public static class TestContextExtensions
{
    public static TestContext SetupJavascriptInterop(this TestContext ctx)
    {
        ctx.JSInterop.Mode = JSRuntimeMode.Strict;

        ctx.JSInterop.Setup<IJSVoidResult>("Blazor._internal.domWrapper.focus", _ => true);

        // Register services
        ctx.Services.AddSingleton<IDomUtils>(new DomUtilsMock());

        ctx.Services.AddSingleton<IFocusTrapInteropModule>(new FocusTrapInteropMockModule());
        ctx.Services.AddSingleton<IFloatingInteropModule>(new FloatingInteropModuleMock());
        ctx.Services.AddSingleton<IPortalConnector>(new PortalConnectorMock());


        ctx.Services.AddSingleton<IWindowObserver>(new WindowObserverMock());
        ctx.Services.AddSingleton<IResizeObserver>(new ResizeObserverMock());

        ctx.Services.AddSingleton<IDropdownToggleInteropModule>(new DropdownToggleInteropMockModule());
        ctx.Services.AddSingleton<ICalendarMonthInteropModule>(new CalendarMonthInteropMockModule());

        return ctx;
    }
}
