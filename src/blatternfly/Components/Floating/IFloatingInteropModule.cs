using System;
using System.Threading.Tasks;

namespace Blatternfly.Components;

public interface IFloatingInteropModule : IAsyncDisposable
{
    ValueTask<FloatingPlacement> ComputePositionAsync(
        string          referenceId,
        string          floatingId,
        FloatingOptions options = null);
}
