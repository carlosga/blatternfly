namespace Blatternfly.Components;

/// <summary>FileIcon icon.</summary>
public sealed class FileIcon : BaseIcon
{
    private static readonly string _svgPath = "M224 136V0H24C10.7 0 0 10.7 0 24v464c0 13.3 10.7 24 24 24h336c13.3 0 24-10.7 24-24V160H248c-13.2 0-24-10.8-24-24zm160-14.1v6.1H256V0h6.1c6.4 0 12.5 2.5 17 7l97.9 98c4.5 4.5 7 10.6 7 16.9z";
    internal static readonly IconDefinition IconDefinition = new(name: "FileIcon", height: 512, width: 384, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
