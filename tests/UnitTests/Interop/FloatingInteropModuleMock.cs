using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Blatternfly.UnitTests.Interop;

public sealed class FloatingInteropModuleMock : IFloatingInteropModule
{
    public ValueTask DisposeAsync()
    {
        return ValueTask.CompletedTask;
    }

    public ValueTask<TooltipPlacement> ComputePositionAsync(
        string          referenceId,
        string          floatingId,
        FloatingOptions options = null)
    {
        return ValueTask.FromResult<TooltipPlacement>(new TooltipPlacement { Position = TooltipPosition.Top, X = 0, Y = 0 });
    }
}
