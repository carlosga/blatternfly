namespace Blatternfly.UnitTests.Utilities;

public sealed class ComponentIdGeneratorMock : IComponentIdGenerator
{
    public string Generate(string prefix = "pf")
    {
        return $"{prefix}-1";
    }
}
