namespace Blatternfly.Components
{
    public sealed class NetworkIcon : BaseIcon
    {
        private static readonly string _svgPath = "M574,320 L574,448 L896,448 C931.332514,448.033078 959.966922,476.667486 960,512 L960,512 L960,640 L1024,640 C1059.33251,640.033078 1087.96692,668.667486 1088,704 L1088,704 L1088,896 C1087.96692,931.332514 1059.33251,959.966922 1024,960 L1024,960 L832,960 C796.667486,959.966922 768.033078,931.332514 768,896 L768,896 L768,704 C768.033078,668.667486 796.667486,640.033078 832,640 L832,640 L896,640 L896,512 L574,512 L574,640 L639,640 C674.332514,640.033078 702.966922,668.667486 703,704 L703,704 L703,896 C702.966922,931.332514 674.332514,959.966922 639,960 L639,960 L447,960 C411.667486,959.966922 383.033078,931.332514 383,896 L383,896 L383,704 C383.033078,668.667486 411.667486,640.033078 447,640 L447,640 L510,640 L510,512 L192,512 L192,640 L256,640 C291.332514,640.033078 319.966922,668.667486 320,704 L320,704 L320,896 C319.966922,931.332514 291.332514,959.966922 256,960 L256,960 L64,960 C28.6674863,959.966922 0.0330777378,931.332514 0,896 L0,896 L0,704 C0.0330777378,668.667486 28.6674863,640.033078 64,640 L64,640 L128,640 L128,512 C128.033078,476.667486 156.667486,448.033078 192,448 L192,448 L510,448 L510,320 L574,320 Z M1024,64 L1024,256 L64,256 L64,64 L1024,64 Z M704,192 L960.5,192 L960.5,128 L704,128 L704,192 Z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "NetworkIcon", height: 1024, width: 1088, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public NetworkIcon() : base(_definition) { }
    }
}