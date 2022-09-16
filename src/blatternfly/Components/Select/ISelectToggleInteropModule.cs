using Microsoft.JSInterop;

namespace Blatternfly.Components;

internal interface ISelectToggleInteropModule : IAsyncDisposable
{
    ValueTask OnKeydown(DotNetObjectReference<SelectToggle> dotNetObjRef, ElementReference toggle);
}
