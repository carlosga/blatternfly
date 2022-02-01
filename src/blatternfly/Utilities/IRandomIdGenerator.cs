namespace Blatternfly.Utilities;

public interface IRandomIdGenerator
{
    string GenerateId(string prefix = "pf");
}
