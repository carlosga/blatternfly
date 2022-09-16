namespace Blatternfly;

internal interface IComponentIdGenerator
{
    string Generate(string prefix = "pf");
}
