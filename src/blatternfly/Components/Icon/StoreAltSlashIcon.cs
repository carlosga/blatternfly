namespace Blatternfly.Components
{
    public sealed class StoreAltSlashIcon : BaseIcon
    {
        private static readonly string _svgPath = "M17.89,123.62,5.51,142.2c-14.2,21.3,1,49.8,26.59,49.8h74.26ZM576,413.42V224H512V364L384,265V224H330.92l-41.4-32H608c25.5,0,40.7-28.5,26.59-49.8l-85.29-128A32.18,32.18,0,0,0,522.6,0H117.42A31.87,31.87,0,0,0,90.81,14.2l-10.66,16L45.46,3.38A16,16,0,0,0,23,6.19L3.37,31.46A16,16,0,0,0,6.18,53.91L594.53,508.63A16,16,0,0,0,617,505.81l19.64-25.26a16,16,0,0,0-2.81-22.45ZM320,384H128V224H64V480a32,32,0,0,0,32,32H352a32,32,0,0,0,32-32V406.59l-64-49.47Z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "StoreAltSlashIcon", height: 512, width: 640, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public StoreAltSlashIcon() : base(_definition) { }
    }
}