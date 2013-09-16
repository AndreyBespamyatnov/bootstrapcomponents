namespace BootstrapComponents.Components.Navs
{
    public class NavSettings
    {
        public NavStyle Style { get; set; }
        public bool Justified { get; set; }
        public bool NavbarRight { get; set; }
        public bool Stacked { get; set; }

        public NavSettings Tabs()
        {
            Style = NavStyle.Tabs;
            return this;
        }

        public NavSettings Pills()
        {
            Style = NavStyle.Pills;
            return this;
        }

        public NavSettings Justify(bool justified = true)
        {
            Justified = justified;
            return this;
        }

        public NavSettings Stack(bool stacked = true)
        {
            Stacked = stacked;
            return this;
        }
    }

    public enum NavStyle { Tabs, Pills, Navbar }
}