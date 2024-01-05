namespace Koi.LethalCompany.UnlimitedStamina
{
    /// <summary>
    /// Contains all mod constants.
    /// </summary>
    public abstract class ModConstants
    {
        public static class Meta
        {
            /// <summary>
            /// The mod GUID.
            /// </summary>
            public const string ModGuid = "Koi.LethalCompany.UnlimitedStamina";

            /// <summary>
            /// The mod name.
            /// </summary>
            public const string ModName = "Unlimited Stamina";

            /// <summary>
            /// The mod version.
            /// </summary>
            public const string ModVersion = "0.0.1";
        }

        public static class Config
        {
            public static class Sections
            {
                public const string General = "General";
            }


            public static class Fields
            {
                public static class Enabled
                {
                    public const string Label = "Enabled";
                    public const bool DefaultValue = true;
                    public const string Description = "Check to enable mod functionnalities, uncheck to disable.";
                }
            }
        }
    }
}