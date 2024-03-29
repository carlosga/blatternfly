namespace Blatternfly.Components;

/// <summary>LongArrowAltDownIcon icon.</summary>
public sealed class LongArrowAltDownIcon : BaseIcon
{
    private static readonly string _svgPath = "M168 345.941V44c0-6.627-5.373-12-12-12h-56c-6.627 0-12 5.373-12 12v301.941H41.941c-21.382 0-32.09 25.851-16.971 40.971l86.059 86.059c9.373 9.373 24.569 9.373 33.941 0l86.059-86.059c15.119-15.119 4.411-40.971-16.971-40.971H168z";
    internal static readonly IconDefinition IconDefinition = new(name: "LongArrowAltDownIcon", height: 512, width: 256, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
