namespace Blatternfly.Components
{
    public sealed class UnknownIcon : BaseIcon
    {
        private static readonly string _svgPath = "M943.3,317.2 L706.9,80.7 C653,26.9 582.5,0 512,0 C441.5,0 371,26.9 317.1,80.7 L80.7,317.1 C-26.9,424.7 -26.9,599.2 80.7,706.8 L317.1,943.2 C371,997.1 441.5,1024 512,1024 C582.5,1024 653,997.1 706.9,943.3 L943.3,706.9 C1050.9,599.3 1050.9,424.8 943.3,317.2 Z M866.4,602.2 L602.8,866.1 C552.8,916.1 471.8,916.2 421.7,866.2 L157.7,602.2 C107.8,552.2 107.8,471.2 157.8,421.3 L421.4,158.4 C471.3,108.6 552.1,108.6 602.1,158.3 L866.3,421.3 C916.3,471.3 916.3,552.2 866.4,602.2 Z M521.3,576 C627.5,576 713.7,502 713.7,413.7 C713.7,325.4 627.6,253.6 521.3,253.6 C366,253.6 334.5,337.7 329.2,407.2 C329.2,414.3 335.2,416 343.5,416 L445,416 C450.5,416 458,415.5 460.8,406.5 C460.8,362.6 582.9,357.1 582.9,413.6 C582.9,441.9 556.2,470.9 521.3,473 C486.4,475.1 447.3,479.8 447.3,521.7 L447.3,553.8 C447.3,570.8 456.1,576 472,576 C488,576.1 521.3,576 521.3,576 L521.3,576 Z M575.3,751.3 L575.3,655.3 C575.3,650.9 573.7,647.3 570.6,644 C567.5,640.9 563.7,639.3 559.3,639.3 L463.3,639.3 C458.9,639.3 455.3,640.9 452,644 C448.9,647.1 447.3,650.9 447.3,655.3 L447.3,751.3 C447.3,755.7 448.9,759.3 452,762.6 C455.1,765.7 458.9,767.3 463.3,767.3 L559.3,767.3 C563.7,767.3 567.3,765.7 570.6,762.6 C573.8,759.4 575.3,755.6 575.3,751.3 L575.3,751.3 Z";
        private static readonly IconDefinition _definition = new(name: "UnknownIcon", height: 1024, width: 1024, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}