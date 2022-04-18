using System.Security.Cryptography;

namespace Blatternfly;

internal sealed class ComponentIdGenerator : IComponentIdGenerator, IDisposable
{
    private readonly RandomNumberGenerator _generator;

    public ComponentIdGenerator()
    {
        _generator = RandomNumberGenerator.Create();
    }

    void IDisposable.Dispose()
    {
        _generator?.Dispose();
    }

    string IComponentIdGenerator.Generate(string prefix)
    {
        Span<byte> buffer = stackalloc byte[10];

        _generator.GetBytes(buffer);

        return prefix + "-" + Convert.ToHexString(buffer);
    }
}
