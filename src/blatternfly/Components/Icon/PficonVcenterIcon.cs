namespace Blatternfly.Components
{
    public sealed class PficonVcenterIcon : BaseIcon
    {
        private static readonly string _svgPath = "M896,0 L448,0 C377.3,0 320,57.3 320,128 L320,320 L128,320 C57.3,320 0,377.3 0,448 L0,896 C0,966.7 57.3,1024 128,1024 L576,1024 C646.7,1024 704,966.7 704,896 L704,704 L896,704 C966.7,704 1024,646.7 1024,576 L1024,128 C1024,57.3 966.7,0 896,0 L896,0 Z M576,576 L576,896 L128,896 L128,448 L448,448 L448,128 L896,128 L896,576 L576,576 Z M464,512 C490.5,512 512,490.5 512,464 L512,224 C512,206.3 526.3,192 544,192 L800,192 C817.7,192 832,206.3 832,224 L832,480 C832,497.7 817.7,512 800,512 L560,512 C533.5,512 512,533.5 512,560 L512,800 C512,817.7 497.7,832 480,832 L224,832 C206.3,832 192,817.7 192,800 L192,544 C192,526.3 206.3,512 224,512 L464,512 Z";
        private static readonly IconDefinition _definition = new(name: "PficonVcenterIcon", height: 1024, width: 1024, svgPath: _svgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}
