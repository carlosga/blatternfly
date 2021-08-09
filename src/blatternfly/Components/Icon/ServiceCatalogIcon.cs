namespace Blatternfly.Components
{
    public sealed class ServiceCatalogIcon : BaseIcon
    {
        private static readonly string _svgPath = "M544,403.2 C604.1,403.2 652.8,451.9 652.8,512 C652.8,572.1 604.1,620.8 544,620.8 C483.9,620.8 435.2,572.1 435.2,512 C435.2,451.9 483.9,403.2 544,403.2 L544,403.2 Z M504.1,785.8 C498.1,785.8 492.2,781.1 491.3,775.1 L484.3,683.8 C473,680.4 472.1,680.8 461.9,675.7 L398.7,734.6 C396.6,736.7 393.2,737.6 390.2,737.6 C386.8,737.6 383.8,736.3 381.2,734.2 C370.1,724 319.5,678.1 319.5,665.7 C319.5,662.7 320.8,660.2 322.5,657.6 C334.9,641.4 366.2,605.8 378.6,589.1 C372.6,577.4 373.5,581.2 369.6,569.3 L280,563.5 C274,562.6 269.8,557.1 269.8,551.1 L269.8,472.2 C269.8,466.7 274.1,460.3 279.6,459.4 L368.3,455.1 C371.7,443.8 370.9,438.9 376.4,428.2 C364.5,411.1 334.8,383.4 321.1,367.2 C319.4,364.6 318.1,361.7 318.1,358.7 C318.1,355.7 319,352.7 321.1,350.2 C329.6,338.7 377.6,286.8 390,286.8 C393.4,286.8 396.4,288.1 399,289.8 L464.9,347.6 C475.8,342.1 474.7,341.2 486.2,337.4 C488.3,315.9 485.6,269.6 491.1,248.7 C492.8,242.7 497.9,238.5 503.9,238.5 L511.9,238.5 L511.9,160 C400.6,88.3 212.9,32 128,32 L128,800 C189.3,783.2 352,760.5 512,864 L512,785.7 L504.1,785.8 Z M1024,96 L1024,928 C1024,928 863,728.7 576,925.4 L576,992 C576,992 863.1,804.7 985.7,989.9 C985.7,989.9 1088,992 1088,928 L1088,162.8 C1088,162.8 1088,96 1024,96 L1024,96 Z M584,238.2 C590,238.2 595.1,242.4 596.8,248.4 C602.3,269.3 599.6,315.6 601.7,337.1 C613.2,340.9 612.1,341.8 623,347.3 L688.9,289.7 C691.5,288 694.5,286.7 697.9,286.7 C710.3,286.7 758.3,338.6 766.8,350.1 C768.9,352.6 769.8,355.6 769.8,358.6 C769.8,361.6 768.5,364.5 766.8,367.1 C753.1,383.3 723.4,411 711.5,428.1 C717,438.8 716.2,443.7 719.6,455 L808.3,459.3 C813.8,460.2 818.1,466.6 818.1,472.1 L818.1,551 C818.1,557 813.9,562.5 807.9,563.4 L718.3,569.2 C714.4,581.1 715.3,577.3 709.3,589 C721.7,605.7 753,641.3 765.4,657.5 C767.1,660.1 768.4,662.6 768.4,665.6 C768.4,678 717.8,723.9 706.7,734.1 C704.1,736.2 701.1,737.5 697.7,737.5 C694.7,737.5 691.3,736.6 689.2,734.5 L626.1,675.6 C615.9,680.7 615,680.3 603.7,683.7 L596.7,775 C595.8,781 589.9,785.7 583.9,785.7 L575.9,785.7 L575.9,864 C737.9,760.5 898.7,783.1 959.9,800 L959.9,32 C874.5,32 687.2,88.6 575.9,160 L575.9,238.3 L584,238.2 Z M64,928 L64,96 C0,96 0,162.8 0,162.8 L0,928 C0,992 102.5,989.9 102.5,989.9 C227.9,805.8 512,992 512,992 L512,925.4 C226,728.7 64,927.9 64,928 L64,928 Z M544.1,511.9 C543.9,512.2 543.9,512.2 544.1,511.9 L544.1,511.9 Z M543.9,512.3 L543.9,511.7 C544.1,511.9 544.1,512.1 543.9,512.3 L543.9,512.3 Z";
        public static readonly IconDefinition IconDefinition = new(name: "ServiceCatalogIcon", height: 1024, width: 1088, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}