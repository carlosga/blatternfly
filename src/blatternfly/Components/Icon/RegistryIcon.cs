namespace Blatternfly.Components
{
    public sealed class RegistryIcon : BaseIcon
    {
        private static readonly string _svgPath = "M504.601506,583.6 C499.901506,576.8 493.701506,572 485.901506,569.1 L270.001506,450.5 C265.501506,448.8 261.001506,448 256.401506,448 L255.701506,448 L255.001506,448 C250.601506,448 246.001506,448.8 241.601506,450.5 L25.7015061,569.2 C18.0015061,572.1 11.7015061,576.9 7.00150606,583.7 C2.30150606,590.4 0.00074731781,598 0.00074731781,606.2 L0.00074731781,862.6 C-0.098493943,879.8 9.70150606,886 20.4015061,892 L236.401506,1019.1 C242.101506,1022.4 248.401506,1024 255.101506,1024 L255.801506,1024 L256.501506,1024 C263.201506,1024 269.501506,1022.4 275.201506,1019.1 L491.201506,892 C501.401506,886.5 511.701506,879.8 511.701506,865.4 L511.701506,606.1 C511.701506,597.9 509.301506,590.4 504.601506,583.6 Z M474.801506,832 L255.801506,960 L35.6015061,832 L35.6015061,768 L255.701506,896 L474.801506,768 L474.801506,832 Z M474.801506,704 L255.801506,832 L35.6015061,704 L35.6015061,640 L255.701506,768 L474.801506,640 L474.801506,704 Z M1144.60151,583.6 C1139.90151,576.8 1133.70151,572 1125.90151,569.1 L910.001506,450.5 C905.501506,448.8 901.001506,448 896.401506,448 L895.701506,448 L895.001506,448 C890.601506,448 886.001506,448.8 881.601506,450.5 L665.701506,569.2 C658.001506,572.1 651.701506,576.9 647.001506,583.7 C642.301506,590.4 640.001506,598 640.001506,606.2 L640.001506,862.6 C640.001506,879.8 649.801506,886 660.501506,892 L876.501506,1019.1 C882.201506,1022.4 888.501506,1024 895.201506,1024 L895.901506,1024 L896.601506,1024 C903.301506,1024 909.601506,1022.4 915.301506,1019.1 L1131.30151,892 C1141.50151,886.5 1151.80151,879.8 1151.80151,865.4 L1151.80151,606.1 C1151.70151,597.9 1149.30151,590.4 1144.60151,583.6 Z M1114.80151,832 L895.701506,960 L675.601506,832 L675.601506,768 L895.701506,896 L1114.80151,768 L1114.80151,832 Z M1114.80151,704 L895.701506,832 L675.601506,704 L675.601506,640 L895.701506,768 L1114.80151,640 L1114.80151,704 Z M824.601506,95.6 C819.901506,88.8 813.701506,84 805.901506,81.1 L590.001506,2.5 C585.501506,0.8 581.001506,0 576.401506,0 L575.701506,0 L575.001506,0 C570.601506,0 566.001506,0.8 561.601506,2.5 L345.701506,81.2 C338.001506,84.1 331.701506,88.9 327.001506,95.7 C322.401506,102.4 320.001506,110 320.001506,118.2 L320.001506,359.6 C320.001506,376.8 329.801506,383 340.501506,389 L556.501506,507.1 C562.201506,510.4 568.501506,512 575.201506,512 L575.901506,512 L576.601506,512 C583.301506,512 589.601506,510.4 595.301506,507.1 L811.301506,389 C821.501506,383.5 831.801506,376.8 831.801506,362.4 L831.801506,118.1 C831.701506,109.9 829.301506,102.4 824.601506,95.6 Z M794.801506,332.3 L575.801506,448 L355.601506,332.3 L355.601506,272 L575.701506,384 L794.801506,272 L794.801506,332.3 Z M794.801506,208 L575.801506,320 L355.601506,208 L355.601506,144 L575.701506,256 L794.801506,144 L794.801506,208 Z";
        private static readonly IconDefinition _definition = new(name: "RegistryIcon", height: 1024, width: 1152, svgPath: _svgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}
