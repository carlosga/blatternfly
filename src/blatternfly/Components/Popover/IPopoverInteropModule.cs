using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Blatternfly.Components;

public interface IPopoverInteropModule : IAsyncDisposable
{
    ValueTask<IJSObjectReference> CreateAsync(DotNetObjectReference<Popover> dotNetObjRef, string reference);

    ValueTask<FloatingPlacement<T>> ComputePositionAsync<T>(
        string             referenceId,
        string             floatingId,
        FloatingOptions<T> options = null) where T: Enum;
}
