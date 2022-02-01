using System.Threading;

namespace Blatternfly.Utilities;

public sealed class SequentialIdGenerator : ISequentialIdGenerator
{
    private static long _counter;

    public string GenerateId(string prefix = "pf")
    {
        var uid = Interlocked.Increment(ref _counter);
        return $"{prefix}-{uid}";
    }
}
