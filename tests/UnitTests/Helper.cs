using Blatternfly.UnitTests.Interop;
using Blatternfly.UnitTests.Utilities;

namespace Blatternfly.UnitTests;

public static class Helper
{
    public static TestContext CreateTestContext()
    {
        using var ctx = new TestContext();

        ctx.JSInterop.Mode = JSRuntimeMode.Strict;

        ctx.JSInterop.Setup<IJSVoidResult>("Blazor._internal.domWrapper.focus", _ => true);

        // Register services
        ctx.Services.AddSingleton<IComponentIdGenerator>(new ComponentIdGeneratorMock());

        ctx.Services.AddSingleton<IDomUtils>(new DomUtilsMock());

        ctx.Services.AddSingleton<IFocusTrapInteropModule>(new FocusTrapInteropMockModule());
        ctx.Services.AddSingleton<IFloatingInteropModule>(new FloatingInteropModuleMock());
        ctx.Services.AddSingleton<IPortalConnector>(new PortalConnectorMock());

        ctx.Services.AddSingleton<IWindowObserver>(new WindowObserverMock());
        ctx.Services.AddSingleton<IResizeObserver>(new ResizeObserverMock());

        ctx.Services.AddSingleton<IDropdownToggleInteropModule>(new DropdownToggleInteropMockModule());
        ctx.Services.AddSingleton<ICalendarMonthInteropModule>(new CalendarMonthInteropMockModule());
        ctx.Services.AddSingleton<ISelectToggleInteropModule>(new SelectToggleInteropMockModule());
        ctx.Services.AddSingleton<IJumpLinksInteropModule>(new JumpLinksInteropMockModule());
        ctx.Services.AddSingleton<IPopoverInteropModule>(new PopoverInteropMockModule());
        ctx.Services.AddSingleton<ITooltipInteropModule>(new TooltipInteropMockModule());

        return ctx;
    }
}
