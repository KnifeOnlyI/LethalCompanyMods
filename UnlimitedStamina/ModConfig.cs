using BepInEx.Configuration;

namespace Koi.LethalCompany.UnlimitedStamina
{
    public class ModConfig
    {
        /// <summary>
        /// The configuration entry to indicates if the mod must be enabled or not.
        /// </summary>
        public static ConfigEntry<bool> ConfigEnabled { get; private set; }

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
        }
    }
}