namespace Blatternfly.Components
{
    public sealed class AsleepIcon : BaseIcon
    {
        private static readonly string _svgPath = "M512,128 C300.2,128 128,300.3 128,512 C128,723.9 300.2,896 512,896 C723.8,896 896,723.8 896,512 C896,300.2 723.7,128 512,128 M512.1,1024 C229.8,1024 0,794.3 0,512 C0,229.7 229.7,0 512.1,0 C794.5,0 1024,229.7 1024,512 C1024,794.3 794.4,1024 512.1,1024 M744.1,619.2 C723.2,664.3 691.733333,700.333333 649.7,727.3 C607.666667,754.266667 561.766667,767.766667 512,767.801349 C477.880448,767.912684 444.106349,760.967204 412.8,747.4 C381.4,733.8 354,715.7 331,692.7 C308,669.7 289.9,642.6 276.3,611.1 C262.774308,579.78407 255.863244,546.011774 255.998009,511.9 C255.891693,478.450317 262.417551,445.311196 275.2,414.4 C288,383.4 305.333333,356.566667 327.2,333.9 C349.066667,311.233333 375.233333,292.966667 405.7,279.1 C436.09495,265.229747 468.913253,257.449838 502.3,256.2 C512,255.8 523.3,262.3 527.1,271.4 C531.1,280.5 531.7,290.8 524.3,297.7 C505.1,315 488.3,335.2 478.2,358.2 C468.1,381.2 460.8,403.2 460.8,428.7 C460.8,461.6 466.7,489.6 482.9,517.4 C498.746034,544.796001 521.503999,567.553966 548.9,583.4 C576.6,599.6 607,607.7 639.9,607.7 C666.146645,607.723074 692.070807,601.916608 715.8,590.7 C724.9,586.7 732.9,588.1 739.8,595 C742.843305,598.084991 744.867601,602.02888 745.6,606.3 C746.409483,610.652973 745.8867,615.148908 744.1,619.2";
        private static readonly IconDefinition _definition = new(name: "AsleepIcon", height: 1024, width: 1024, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}