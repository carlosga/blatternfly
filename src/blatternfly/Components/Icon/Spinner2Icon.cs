namespace Blatternfly.Components;

/// <summary>Spinner2Icon icon.</summary>
public sealed class Spinner2Icon : BaseIcon
{
    private static readonly string _svgPath = "M515.8,0 C655.3,0 781.6,58.4 873.4,150.2 L968.9,54.7 C989,34.5 1024,48.8 1024,77.3 L1024,352 C1024,369.7 1009.2,384.1 991.5,384 L716.8,384 C688.3,384 674,349.5 694.2,329.3 L783,240.5 C713.5,171.1 617.8,128 512,128 C300.4,128 128,300.2 128,512 C128,723.8 300.2,895.1 511.9,895 C606.9,895 693.9,861.2 761,803.9 C773.7,793.1 792.6,793.8 804.4,805.6 L849.6,850.9 C862.6,864 861.9,885.4 848,897.6 C758,976.3 640.3,1024 511.7,1024 C229.1,1024 0,797 0,510.7 C0,226.2 235,0 515.8,0";
    internal static readonly IconDefinition IconDefinition = new(name: "Spinner2Icon", height: 1024, width: 1024, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
