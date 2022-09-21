namespace Blatternfly.Components;

public sealed class BadgeCountObject
{
    /// Adds styling to the badge to indicate it has been read.
    public bool IsRead { get; set; }

    /// Adds count number right of button.
    public int? Count { get; set; }

    /// Additional classes added to the badge count
    public string ClassName { get; set; }
}