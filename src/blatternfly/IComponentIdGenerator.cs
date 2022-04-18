namespace Blatternfly;

public interface IComponentIdGenerator
{
    string Generate(string prefix = "pf");
}
