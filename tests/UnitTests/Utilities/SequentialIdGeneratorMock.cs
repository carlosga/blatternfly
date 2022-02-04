using Blatternfly.Utilities;

namespace Blatternfly.UnitTests.Utilities;

public sealed class SequentialIdGeneratorMock : ISequentialIdGenerator
{
    public string GenerateId(string prefix = "pf")
    {
        return $"{prefix}-1";
    }
}
