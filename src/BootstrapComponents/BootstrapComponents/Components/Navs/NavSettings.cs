namespace BootstrapComponents.Components.Navs
{
    public class NavSettings
    {
        public NavStyle Style { get; set; }
        public bool Justified { get; set; }
        public bool NavbarRight { get; set; }

        public NavSettings Tabs()
        {
            Style = NavStyle.Tabs;
            return this;
        }

        public NavPillSettings Pills()
        {
            Style = NavStyle.Pills;
            return new NavPillSettings(this);
        }

        public NavSettings Justify(bool justified = true)
        {
            Justified = justified;
            return this;
        }
    }

    public class NavPillSettings : NavSettings
    {
        public bool Stacked { get; set; }

        public NavPillSettings(NavSettings settings)
        {
            Style = settings.Style;
            Justified = settings.Justified;
            var nps = settings as NavPillSettings;
            if (nps != null)
            {
                Stacked = nps.Stacked;
            }
        }

        public NavPillSettings Stack(bool stacked = true)
        {
            Stacked = stacked;
            return this;
        }
    }

    public enum NavStyle { Pills, Tabs, Navbar }
}