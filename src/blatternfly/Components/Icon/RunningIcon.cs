namespace Blatternfly.Components;

/// <summary>RunningIcon icon.</summary>
public sealed class RunningIcon : BaseIcon
{
    private static readonly string _svgPath = "M512,0 C229.2,0 0,229.2 0,512 C0,794.8 229.2,1024 512,1024 C794.8,1024 1024,794.8 1024,512 C1024,229.2 794.8,0 512,0 Z M154.5,361.3 C174.8,314.5 202.7,273.3 237.9,237.9 C273.3,202.5 314.4,174.8 361.3,154.5 C408.1,134.2 458.4,124.1 511.7,124.1 C564.9,124.1 615.2,134.2 662.1,154.5 C708.9,174.8 750.1,202.7 785.5,237.9 C820.9,273.3 848.6,314.5 868.9,361.3 C882.4,391.7 891.3,423 895.9,455.9 L726,455.9 C709.3,455.9 693.6,464.4 684.4,478.3 L661.5,513.3 L549.1,290.3 C536.8,265.8 506.8,255.8 482.4,268.4 C470.7,274.3 462.1,284.4 457.7,296.7 L360.4,579.6 L314.9,484.3 C306.7,466.9 289.1,456 269.9,456 L128,456 C132.5,423 141.4,391.4 154.5,361.3 Z M869.2,662.7 C848.9,710 821,751.1 785.8,786.1 C750.6,821.1 709.3,848.7 662.4,869 C615.6,889.3 565.3,899.4 512,899.4 C458.8,899.4 408.5,889.3 361.6,869 C314.8,848.7 273.6,821 238.2,786.1 C202.8,751.2 175.1,710 154.8,662.7 C140.2,628.4 130.8,592.8 126.7,555.5 L238.2,555.5 L322.5,732.4 C330.7,749.8 348.3,760.7 367.5,760.7 L370.2,760.7 C390.3,759.6 407.9,746.3 414.5,727.1 L513.2,440.6 L611.5,635.3 C619.5,651.1 635.5,661.6 653.1,662.5 C670,663.4 687.8,655 697.4,640.1 L752.7,555.6 L897.1,555.6 C893.2,592.8 883.9,628.6 869.2,662.7 Z";
    internal static readonly IconDefinition IconDefinition = new(name: "RunningIcon", height: 1024, width: 1024, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
