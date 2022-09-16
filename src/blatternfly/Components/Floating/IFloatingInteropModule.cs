namespace Blatternfly.Components;

internal interface IFloatingInteropModule : IAsyncDisposable
{
    ValueTask<FloatingPlacement<T>> ComputePositionAsync<T>(
        string             referenceId,
        string             floatingId,
        FloatingOptions<T> options = null) where T: Enum;
}
