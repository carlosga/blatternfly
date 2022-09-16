using Microsoft.JSInterop;

namespace Blatternfly.Components;

internal interface IDropdownToggleInteropModule : IAsyncDisposable
{
    ValueTask OnKeydown(DotNetObjectReference<Toggle> dotNetObjRef, ElementReference toggle);
}
