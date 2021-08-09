namespace Blatternfly.Components
{
    public sealed class IntegrationIcon : BaseIcon
    {
        private static readonly string _svgPath = "M1032.4,414.7 C1012.1,414.7 996.5,430.9 985.5,446.4 C974.5,461.9 960,434.2 960,410.2 L960,303.6 C960.087961,291.000936 955.142478,278.888102 946.261586,269.950882 C937.380693,261.013663 925.299368,255.991697 912.7,256 L838.8,256 C806.4,256 793.4,247.6 806.7,233.2 C822.4,216.3 832.5,202.1 832.5,183.9 C832.5,153 803.5,128 767.6,128 C731.7,128 702.7,153 702.7,183.9 C702.7,204.2 710.7,215.8 727.2,231.7 C743.2,247.1 727.9,256 699,256 L625.2,256 C598.560066,255.881894 576.706519,277.069174 576,303.7 L576,355.9 C582.7,354.9 584.4,354.3 590.6,354.3 C653.6,354.3 704.8,412.2 704.8,483.7 C704.8,555.2 653.7,613.1 590.6,613.1 C584.4,613.1 582.7,612.5 576,611.5 L576,719.5 C576,745.8 591.6,768 618,768 L700,768 C732.8,768 747.1,774.5 731.6,791.6 C716.1,808.7 702.7,822.1 702.7,841.1 C702.7,871.5 731.7,896 767.6,896 C803.5,896 832.5,871.4 832.5,841.1 C832.5,823.5 828,810.8 807.4,794.4 C786.8,778 804,767.7 837.9,767.7 L916.4,767.7 C942.7,767.7 960,744.4 960,718.1 L960,546.9 C960,523.4 974,493 984.5,510.7 C995,528.4 1011.4,544.2 1032.4,544.2 C1063.1,544.2 1088,515.2 1088,479.4 C1088,443.6 1063.1,414.7 1032.4,414.7 M645.4,479.4 C645.4,443.6 620.8,414.6 590.3,414.6 C570.5,414.6 554.7,425.4 543.5,445.3 C532.3,465.2 512,435 512,409.2 L512,367.2 C512,340.9 490.1,320 463.8,320 L381.1,320 C345.9,320 336.8,314.9 352.9,294 C370.4,273.7 378.9,261.2 378.9,243.7 C378.9,214 349.9,190 314,190 C278.1,190 249.1,214 249.1,243.7 C249.1,258.7 255.6,269.9 270.9,291.1 C286.2,312.3 280.9,320 244.1,320 L176.5,320 C150.1,320 128,340 128,366.3 L128,408.3 C128,431.6 119.4,458.8 102.4,444.5 C85.4,430.2 75.5,414.6 55.5,414.6 C24.3,414.7 0,443.7 0,479.4 C0,515.1 24.3,544.2 55.7,544.2 C76.7,544.2 92.6,530.3 104.2,511.8 C115.8,493.3 128,525.4 128,547.8 L128,780.9 C128,807.2 154.1,831.1 181.4,832 L237.8,832 C229.9,817.1 226.4,799.3 226.4,783.5 C226.4,729.1 253.4,704.4 313.1,702.7 L312,702.7 C355.8,701.7 391.9,727.4 391.9,783.5 C391.650624,800.300668 387.761268,816.847489 380.5,832 L463,832 C489.4,832 512,808.1 512,781.8 L512,546.9 C512,521.5 532.8,490.9 542.2,510.8 C551.6,530.7 569.6,544.2 590.3,544.2 C620.8,544.2 645.4,515.2 645.4,479.4";
        public static readonly IconDefinition IconDefinition = new(name: "IntegrationIcon", height: 1024, width: 1088, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}