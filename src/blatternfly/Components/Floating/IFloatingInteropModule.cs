using System;
using System.Threading.Tasks;

namespace Blatternfly.Components;

public interface IFloatingInteropModule : IAsyncDisposable
{
    ValueTask<TooltipPosition> ComputePositionAsync(
        string          referenceId,
        string          floatingId,
        FloatingOptions options = null);
}
