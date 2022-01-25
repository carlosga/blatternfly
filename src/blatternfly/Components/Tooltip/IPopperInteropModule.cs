using System;
using System.Threading.Tasks;

namespace Blatternfly.Components;

public interface IPopperInteropModule : IAsyncDisposable
{
    Task ComputePositionAsync(
        string        referenceId,
        string        floatingId,
        PopperOptions options = null);
}
