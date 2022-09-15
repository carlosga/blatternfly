namespace Blatternfly.Components;

/// <summary>Date validator contract.</summary>
public interface IDateValidator
{
    /// <summary>Gets a value indicating whether the given date is valid.</summary>
    bool Validate(DateOnly date);
}
