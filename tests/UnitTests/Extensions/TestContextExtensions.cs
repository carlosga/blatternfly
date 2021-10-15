﻿using Blatternfly.Components;
using Blatternfly.Interop;
using Blatternfly.UnitTests.Interop;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop.Infrastructure;

namespace Bunit
{
    public static class TestContextExtensions
    {
        public static TestContext SetupJavascriptInterop(this TestContext ctx)
        {
            ctx.JSInterop.Mode = JSRuntimeMode.Strict;

            ctx.JSInterop.Setup<IJSVoidResult>("Blazor._internal.domWrapper.focus", _ => true);
            
            // Register services
            ctx.Services.AddSingleton<IDomUtils>(new DomUtilsMock());
            ctx.Services.AddSingleton<IDropdownToggleInteropModule>(new DropdownToggleInteropMockModule());
            ctx.Services.AddSingleton<ICalendarMonthInteropModule>(new CalendarMonthInteropMockModule());
            ctx.Services.AddSingleton<IWindowObserver>(new WindowObserverMock());
            ctx.Services.AddSingleton<IFocusTrapInteropModule>(new FocusTrapInteropMockModule());

            return ctx;
        }
    }
}
