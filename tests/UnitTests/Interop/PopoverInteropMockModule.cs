namespace Blatternfly.UnitTests.Interop;

public sealed class PopoverInteropMockModule : IPopoverInteropModule
{
    public ValueTask DisposeAsync()
    {
        return ValueTask.CompletedTask;
    }

    public ValueTask<FloatingPlacement<T>> ComputePositionAsync<T>(
        string             referenceId,
        string             floatingId,
        FloatingOptions<T> options) where T: Enum
    {
        return ValueTask.FromResult<FloatingPlacement<T>>(new() { Placement = default, X = 0, Y = 0 });
    }

    public ValueTask<IJSObjectReference> CreateAsync(DotNetObjectReference<Popover> dotNetObjRef, string reference)
    {
        return ValueTask.FromResult<IJSObjectReference>(null);
    }
}
