using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Blatternfly.Components;

public sealed class CalendarMonthInteropModule : ICalendarMonthInteropModule
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public CalendarMonthInteropModule(IJSRuntime runtime)
    {
        _moduleTask = new Lazy<Task<IJSObjectReference>>(() => runtime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/Blatternfly/components/calendar-month.js").AsTask());
    }
    
    public async ValueTask DisposeAsync()
    {
        if (_moduleTask.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }

    public async ValueTask OnKeydown(DotNetObjectReference<CalendarMonth> dotNetObjRef, ElementReference reference)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("onKeyDown", dotNetObjRef, reference);
    }        
}
