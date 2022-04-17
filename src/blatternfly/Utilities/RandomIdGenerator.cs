using System.Security.Cryptography;

namespace Blatternfly.Utilities;

internal sealed class RandomIdGenerator : IRandomIdGenerator, IDisposable
{
    private readonly RandomNumberGenerator _generator;

    public RandomIdGenerator()
    {
        _generator = RandomNumberGenerator.Create();
    }

    void IDisposable.Dispose()
    {
        _generator?.Dispose();
    }

    string IRandomIdGenerator.GenerateId(string prefix)
    {
        Span<byte> buffer = stackalloc byte[10];

        _generator.GetBytes(buffer);

        var uid = Convert.ToHexString(buffer);

        return $"{prefix}-{uid}";
    }
}
