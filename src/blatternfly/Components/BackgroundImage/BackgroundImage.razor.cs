namespace Blatternfly.Components;

public partial class BackgroundImage : ComponentBase
{
    [Inject]
    private IComponentIdGenerator ComponentIdGenerator { get; set; }

    /// <summary>
    /// Additional attributes that will be applied to the component.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Override image styles using BackgroundImageSrcMap.
    /// </summary>
    [Parameter] public BackgroundImageSrcMap Source { get; set; }

    /// <summary>
    /// Override svg filter to use.
    /// </summary>
    [Parameter] public RenderFragment Filter { get; set; }

    /// <summary>
    /// Override SVG filter ID
    /// </summary>
    [Parameter] public string FilterId { get; set; }

    private readonly Dictionary<string, Dictionary<string, string>> _styles = new()
    {
        { "xs"    , BackgroundImageSrcMap.c_background_image_BackgroundImage },
        { "xs2x"  , BackgroundImageSrcMap.C_background_image_BackgroundImage_2x },
        { "sm"    , BackgroundImageSrcMap.c_background_image_BackgroundImage_sm },
        { "sm2x"  , BackgroundImageSrcMap.c_background_image_BackgroundImage_sm_2x },
        { "lg"    , BackgroundImageSrcMap.c_background_image_BackgroundImage_lg },
        { "filter", BackgroundImageSrcMap.c_background_image_Filter }
    };

    private string BackgroundImageStyle { get; set; }
    private string UniqueFilterId       { get; set; }
    private string InternalFilterId     { get => FilterId ?? UniqueFilterId; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        UniqueFilterId = ComponentIdGenerator.Generate("patternfly-background-image-filter-overlay");
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (Source is not null && Source.IsNotEmpty)
        {
            if (!string.IsNullOrEmpty(Source.xs))
            {
                _styles["xs"]["value"] = $"url({Source.xs})";
            }
            if (!string.IsNullOrEmpty(Source.xs2x))
            {
                _styles["xs2x"]["value"] = $"url({Source.xs2x})";
            }
            if (!string.IsNullOrEmpty(Source.sm))
            {
                _styles["sm"]["value"] = $"url({Source.sm})";
            }
            if (!string.IsNullOrEmpty(Source.sm2x))
            {
                _styles["sm2x"]["value"] = $"url({Source.sm2x})";
            }
            if (!string.IsNullOrEmpty(Source.lg))
            {
                _styles["lg"]["value"] = $"url({Source.lg})";
            }

            var builder = new System.Text.StringBuilder();

            foreach (var kvp in _styles)
            {
                var name  = kvp.Value["name"];
                var value = kvp.Key == "filter" ? $"url(#{InternalFilterId})" : kvp.Value["value"];
                if (!string.IsNullOrEmpty(value))
                {
                    builder.Append($"{name}: {value};");
                }
            }

            BackgroundImageStyle = builder.ToString();
        }
        else
        {
            BackgroundImageStyle = $"{_styles["filter"]["name"]}:url(#{InternalFilterId});";
        }
    }
}