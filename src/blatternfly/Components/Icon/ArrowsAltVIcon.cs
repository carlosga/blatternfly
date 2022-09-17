namespace Blatternfly.Components;

/// <summary>ArrowsAltVIcon icon.</summary>
public sealed class ArrowsAltVIcon : BaseIcon
{
    private static readonly string _svgPath = "M214.059 377.941H168V134.059h46.059c21.382 0 32.09-25.851 16.971-40.971L144.971 7.029c-9.373-9.373-24.568-9.373-33.941 0L24.971 93.088c-15.119 15.119-4.411 40.971 16.971 40.971H88v243.882H41.941c-21.382 0-32.09 25.851-16.971 40.971l86.059 86.059c9.373 9.373 24.568 9.373 33.941 0l86.059-86.059c15.12-15.119 4.412-40.971-16.97-40.971z";
    internal static readonly IconDefinition IconDefinition = new(name: "ArrowsAltVIcon", height: 512, width: 256, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
