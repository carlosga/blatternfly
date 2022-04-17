namespace Blatternfly.Utilities;

internal sealed class SequentialIdGenerator : ISequentialIdGenerator
{
    private static long _counter;

    string ISequentialIdGenerator.GenerateId(string prefix)
    {
        var uid = Interlocked.Increment(ref _counter);
        return $"{prefix}-{uid}";
    }
}
