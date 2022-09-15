namespace Blatternfly.Components;

public partial class Truncate : ComponentBase
{
    [Inject] private IComponentIdGenerator ComponentIdGenerator { get; set; }
    [Inject] private IDomUtils DomUtils { get; set; }

    /// <summary>Additional attributes that will be applied to the component.</summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>Text to truncate.</summary>
    [Parameter] public string Content { get; set; }

    /// <summary>The number of characters displayed in the second half of the truncation.</summary>
    [Parameter] public int TrailingNumChars { get; set; } = 7;

    /// <summary>Where the text will be truncated.</summary>
    [Parameter] public TruncatePosition Position { get; set; } = TruncatePosition.End;

    /// <summary>Tooltip position</summary>
    [Parameter] public TooltipPosition TooltipPosition { get; set; } = TooltipPosition.Top;

    private string CssClass => new CssBuilder("pf-c-truncate")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    private string PositionCssClass => new CssBuilder()
        .AddClass("pf-c-truncate__start" , Position is TruncatePosition.End)
        .AddClass("pf-c-truncate__end"   , Position is TruncatePosition.Start)
        .Build();

    const int MinWidthCharacters = 12;

    private static readonly MarkupString s_LeftToRightMark = new MarkupString("&lrm;");
    private static string SliceContentStart(string str, int slice) => str?[..^slice];
    private static string SliceContentEnd(string str, int slice) => str?[^slice..];

    private string Id { get; set; }
    private string TooltipId { get; set; }

    private bool NeedsTruncation
    {
        get
        {
            if (Content is null)
            {
                return false;
            }
            return Content[0..^TrailingNumChars].Length > MinWidthCharacters;
        }
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Id        = ComponentIdGenerator.Generate("pf-c-truncate");
        TooltipId = $"{Id}-tooltip";
    }
}