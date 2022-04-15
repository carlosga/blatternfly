using Microsoft.JSInterop;

namespace Blatternfly.Components;

public interface ITooltipInteropModule : IAsyncDisposable
{
    ValueTask<IJSObjectReference> CreateAsync(DotNetObjectReference<Tooltip> dotNetObjRef, string reference);

    ValueTask<FloatingPlacement<T>> ComputePositionAsync<T>(
        string             referenceId,
        string             floatingId,
        FloatingOptions<T> options = null) where T: Enum;
}
