namespace Blatternfly.Components;

/// <summary>OutlinedStarHalfIcon icon.</summary>
public sealed class OutlinedStarHalfIcon : BaseIcon
{
    private static readonly string _svgPath = "M288 385.3l-124.3 65.4 23.7-138.4-100.6-98 139-20.2 62.2-126V0c-11.4 0-22.8 5.9-28.7 17.8L194 150.2 47.9 171.4c-26.2 3.8-36.7 36.1-17.7 54.6l105.7 103-25 145.5c-4.5 26.1 23 46 46.4 33.7L288 439.6v-54.3z";
    internal static readonly IconDefinition IconDefinition = new(name: "OutlinedStarHalfIcon", height: 512, width: 576, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
