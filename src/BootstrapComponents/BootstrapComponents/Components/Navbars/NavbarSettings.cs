namespace BootstrapComponents.Components.Navbars
{
    public class NavbarSettings
    {
        public NavbarSettings()
        {
            UseInnerContainer = true;
            Fixed = FixedPosition.None;
        }

        public FixedPosition Fixed { get; set; }
        public bool UseInnerContainer { get; set; }
        public bool Inverse { get; set; }

        public NavbarSettings FixedTop() { return SetFixed(FixedPosition.Top); }
        public NavbarSettings FixedBottom() { return SetFixed(FixedPosition.Bottom); }

        public NavbarSettings SetFixed(FixedPosition fixedPosition)
        {
            Fixed = fixedPosition;
            return this;
        }
        public NavbarSettings SetInverse(bool inverse = true)
        {
            Inverse = inverse;
            return this;
        }

    }
    
    public enum FixedPosition { None, Top, Bottom }
}