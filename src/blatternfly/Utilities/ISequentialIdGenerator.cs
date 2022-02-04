namespace Blatternfly.Utilities;

public interface ISequentialIdGenerator
{
    string GenerateId(string prefix = "pf");
}
