namespace Blatternfly.Components;

public sealed class BadgeCountObject
{
    /// <summary>Adds styling to the badge to indicate it has been read.</summary>
    public bool IsRead { get; set; }

    /// <summary>Adds count number right of button.</summary>
    public int? Count { get; set; }

    /// <summary>Additional classes added to the badge count</summary>
    public string ClassName { get; set; }
}