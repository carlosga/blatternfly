using Microsoft.JSInterop;

namespace Blatternfly.Components;

public interface ISelectToggleInteropModule : IAsyncDisposable
{
    ValueTask OnKeydown(DotNetObjectReference<SelectToggle> dotNetObjRef, ElementReference toggle);
}
