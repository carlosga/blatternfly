namespace Blatternfly.Components;

/// <summary>AddCircleOIcon icon.</summary>
public sealed class AddCircleOIcon : BaseIcon
{
    private static readonly string _svgPath = "M576,303 C576,294.715729 569.284271,288 561,288 L463,288 C454.715729,288 448,294.715729 448,303 L448,448 L303,448 C294.715729,448 288,454.715729 288,463 L288,561 C288,569.284271 294.715729,576 303,576 L448,576 L448,720.9 C447.983373,729.207373 454.6927,735.961429 463,736 L561,736 C569.3073,735.961429 576.016627,729.207373 576,720.9 L576,576 L721,576 C724.969024,576.026638 728.784638,574.468589 731.600595,571.671405 C734.416553,568.87422 736.000031,565.069113 736.000031,561.1 L736.000031,463.1 C736.016627,454.792627 729.3073,448.038571 721,448 L576,448 L576,303 Z M512,896 C300.2,896 128,723.9 128,512 C128,300.3 300.2,128 512,128 C723.8,128 896,300.2 896,512 C896,723.8 723.7,896 512,896 Z M512.1,0 C229.7,0 0,229.8 0,512 C0,794.2 229.8,1024 512.1,1024 C794.4,1024 1024,794.3 1024,512 C1024,229.7 794.4,0 512.1,0 Z";
    internal static readonly IconDefinition IconDefinition = new(name: "AddCircleOIcon", height: 1024, width: 1024, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
