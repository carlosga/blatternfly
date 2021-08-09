namespace Blatternfly.Components
{
    public sealed class StorageDomainIcon : BaseIcon
    {
        private static readonly string _svgPath = "M0,640 L0,544 C0,544 0,525.6 14.5,544 C44.3,581.9 135.8,640 416,640 C427.2,640 438.2,639.9 448.8,639.7 C454.3,639.6 458.2,644.9 456.5,650.1 C455.7,652.5 455,654.9 454.3,657.3 C444.8,690.5 441.3,724.7 443.9,759.1 C444.3,763.7 440.7,767.7 436,767.8 C429.3,767.900131 422.6,767.900131 415.8,767.900131 C186.2,768 0,710.7 0,640 M602.1,995.8 C609.1,999.3 607.4,1009.7 599.7,1010.9 C544.3,1019.3 481.9,1024 416,1024 C186.2,1023.9 0,966.7 0,896 L0,768 C0,768 0,749.6 14.5,768 C44.3,806 135.8,864.2 416,864 C433.7,864 450.6,863.7 466.8,863.3 C469.9,863.2 472.8,864.9 474.2,867.7 C502.1,923.1 547.2,968 602.1,995.8 M0,192 L0,128 C0,57.3 186.2,0 416,0 C645.8,0 832,57.3 832,128 L832,192 C832,262.7 645.8,320 416,320 C186.2,320 0,262.7 0,192 M0,416 L0,320 C0,320 0,301.6 14.5,320 C44.3,357.9 135.8,416 416,416 C696.2,416 787.7,357.9 817.5,320 C832,301.6 832,320 832,320 L832,416 C832,429.4 825.3,442.3 812.9,454.4 C810.9,456.3 808.1,457.1 805.4,456.4 C782.3,450.5 758.2,447.3 733.4,447.3 C721.6,447.3 709.7,448 698,449.5 C659.2,454.2 622.5,466.5 588.8,485.8 C564.3,499.9 542.2,517.3 522.9,537.6 C521.5,539 519.7,539.9 517.7,540.1 C485.1,542.6 451.1,544 416,544 C186.2,544 0,486.7 0,416 M1067.4,944.1 L933.2,855.6 C919.9,846.2 906.5,842.6 895.9,843.9 C895.4,843.9 895,844.1 894.5,844.1 C919.2,806.8 931.1,761.1 925.4,713.6 C912.7,607.5 816,531.8 709.7,544.8 C603.4,557.8 527.8,654.3 540.6,760.6 C553.4,866.9 650.1,942.5 756.4,929.5 C804.2,923.8 845.5,900.9 875.7,868.2 C876.6,879.2 883.5,892 896.3,903.2 L1014.5,1012 C1023.6,1020 1034.7,1024 1045.6,1024 C1058.2,1024 1072.1,1017.1 1079.2,1007.9 C1085.4,999.9 1088,992 1088,981 C1088,967.1 1080.5,953.2 1067.4,944.1 Z M748.8,865.5 C677.9,874.2 613.3,823.7 604.8,752.8 C596.3,681.9 646.6,617.3 717.5,608.8 C788.4,600.3 853,650.6 861.5,721.5 C869.9,792.4 819.7,856.8 748.8,865.5 Z";
        public static readonly IconDefinition IconDefinition = new(name: "StorageDomainIcon", height: 1024, width: 1088, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}