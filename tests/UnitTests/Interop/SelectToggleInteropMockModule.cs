using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Blatternfly.UnitTests.Interop;

public sealed class SelectToggleInteropMockModule : ISelectToggleInteropModule
{
    public ValueTask DisposeAsync()
    {
        return ValueTask.CompletedTask;
    }

    public ValueTask OnKeydown(DotNetObjectReference<SelectToggle> dotNetObjRef, ElementReference toggle)
    {
        return ValueTask.CompletedTask;
    }
}
