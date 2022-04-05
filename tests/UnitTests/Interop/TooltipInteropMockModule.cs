namespace Blatternfly.UnitTests.Interop;

public sealed class TooltipInteropMockModule : ITooltipInteropModule
{
    public ValueTask DisposeAsync()
    {
        return ValueTask.CompletedTask;
    }

    public ValueTask<IJSObjectReference> CreateAsync(DotNetObjectReference<Tooltip> dotNetObjRef, string reference)
    {
        return ValueTask.FromResult<IJSObjectReference>(null);
    }

    public ValueTask<FloatingPlacement<T>> ComputePositionAsync<T>(
        string             referenceId,
        string             floatingId,
        FloatingOptions<T> options) where T: Enum
    {
        return ValueTask.FromResult<FloatingPlacement<T>>(new() { Placement = default, X = 0, Y = 0 });
    }
}
