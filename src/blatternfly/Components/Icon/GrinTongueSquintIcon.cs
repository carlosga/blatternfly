namespace Blatternfly.Components
{
    public sealed class GrinTongueSquintIcon : BaseIcon
    {
        private static readonly string _svgPath = "M293.1 374.6c-14.4-6.5-31.1 2.2-34.6 17.6l-1.8 7.8c-2.1 9.2-15.2 9.2-17.3 0l-1.8-7.8c-3.5-15.4-20.2-24.1-34.6-17.6-.9.4.3-.2-18.9 9.4v63c0 35.2 28 64.5 63.1 64.9 35.7.5 64.9-28.4 64.9-64v-64c-19.5-9.6-18.2-8.9-19-9.3zM248 8C111 8 0 119 0 256c0 106.3 67 196.7 161 232-5.6-12.2-9-25.7-9-40v-45.5c-24.7-16.2-43.5-38.1-47.8-63.8-2-11.8 9.2-21.5 20.7-17.9C155.1 330.5 200 336 248 336s92.9-5.5 123.1-15.2c11.4-3.7 22.6 6.1 20.7 17.9-4.3 25.7-23.1 47.6-47.8 63.8V448c0 14.3-3.4 27.8-9 40 94-35.3 161-125.7 161-232C496 119 385 8 248 8zm-33.8 210.3l-80 48c-11.5 6.8-24-7.6-15.4-18l33.6-40.3-33.6-40.3c-8.6-10.3 3.8-24.9 15.4-18l80 48c7.7 4.7 7.7 15.9 0 20.6zm163 30c8.7 10.4-3.9 24.8-15.4 18l-80-48c-7.8-4.7-7.8-15.9 0-20.6l80-48c11.7-6.9 23.9 7.7 15.4 18L343.6 208l33.6 40.3z";
        public static readonly IconDefinition IconDefinition = new(name: "GrinTongueSquintIcon", height: 512, width: 496, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}