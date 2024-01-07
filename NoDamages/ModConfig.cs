using BepInEx.Configuration;

namespace Koi.LethalCompany.NoDamages
{
    public abstract class ModConfig
    {
        /// <summary>
        /// The configuration entry to indicates if the mod must be enabled or not.
        /// </summary>
        public static ConfigEntry<bool> ConfigEnabled { get; private set; }

        /// <summary>
        /// The configuration entry to indicates if the mod must cancel player death or not.
        /// </summary>
        public static ConfigEntry<bool> NoDeath { get; private set; }

        /// <summary>
        /// Initialize.
        /// </summary>
        /// <param name="configFile">The mod configuration file</param>
        public static void Init(ConfigFile configFile)
        {
            ConfigEnabled = configFile.Bind(
                ModConstants.Config.Sections.General,
                ModConstants.Config.Fields.Enabled.Label,
                ModConstants.Config.Fields.Enabled.DefaultValue,
                ModConstants.Config.Fields.Enabled.Description
            );

            NoDeath = configFile.Bind(
                ModConstants.Config.Sections.General,
                ModConstants.Config.Fields.NoDeath.Label,
                ModConstants.Config.Fields.NoDeath.DefaultValue,
                ModConstants.Config.Fields.NoDeath.Description
            );
        }
    }
}