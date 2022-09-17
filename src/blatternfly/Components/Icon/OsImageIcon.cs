namespace Blatternfly.Components;

/// <summary>OsImageIcon icon.</summary>
public sealed class OsImageIcon : BaseIcon
{
    private static readonly string _svgPath = "M96,419.7 L96,303 L487.1,468.4 C503,475.1 521,475.1 537,468.4 L928,303 L928,419.7 C928,425.9 924.4,431.6 918.7,434.2 L538.9,610.5 C521.8,618.4 502.1,618.4 485,610.5 L105.3,434.2 C99.6,431.6 96,425.9 96,419.7 L96,419.7 Z M483,887.4 L104.7,695.4 C99.3,692.7 95.9,687.2 95.9,681.1 L95.9,563.8 L483.8,753.3 C501.5,762 522.3,762 540,753.3 L928,563.3 L928,681.2 C928,687.2 924.6,692.7 919.2,695.5 L541,887.4 C522.8,896.6 501.2,896.6 483,887.4 L483,887.4 Z M1024,239.6 C1023.4,204 1001,172.6 967.5,160.3 C825.5,108.6 683.5,56.9 541.5,5.2 C532,1.7 522,0 512,0 C502,0 492,1.7 482.5,5.2 L56.5,160.4 C23.1,172.6 0.7,204.1 0,239.6 L0,694.5 L0.1,694.5 C1.2,725.5 18.9,765.1 44.6,779.9 L470.6,1013.4 C483.5,1020.4 497.7,1024 512,1024 C526.3,1024 540.5,1020.5 553.4,1013.4 C639.6,966.1 841.7,855.5 979.4,779.9 C1006.1,765.3 1022.9,725.6 1024,694.5 L1024,239.6 Z";
    internal static readonly IconDefinition IconDefinition = new(name: "OsImageIcon", height: 1024, width: 1024, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
