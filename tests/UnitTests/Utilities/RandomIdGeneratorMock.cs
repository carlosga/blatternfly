using Blatternfly.Utilities;

namespace Blatternfly.UnitTests.Utilities;

public sealed class RandomIdGeneratorMock : IRandomIdGenerator
{
    public string GenerateId(string prefix = "pf")
    {
        return $"{prefix}-1";
    }
}
