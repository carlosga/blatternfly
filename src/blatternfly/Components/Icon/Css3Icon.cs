namespace Blatternfly.Components;

/// <summary>Css3Icon icon.</summary>
public sealed class Css3Icon : BaseIcon
{
    private static readonly string _svgPath = "M480 32l-64 368-223.3 80L0 400l19.6-94.8h82l-8 40.6L210 390.2l134.1-44.4 18.8-97.1H29.5l16-82h333.7l10.5-52.7H56.3l16.3-82H480z";
    internal static readonly IconDefinition IconDefinition = new(name: "Css3Icon", height: 512, width: 512, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
