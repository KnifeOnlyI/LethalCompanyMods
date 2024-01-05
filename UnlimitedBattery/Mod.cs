using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace Koi.LethalCompany.UnlimitedBattery
{
    /// <summary>
    /// The mod entry point.
    /// </summary>
    [BepInPlugin(ModConstants.Meta.ModGuid, ModConstants.Meta.ModName, ModConstants.Meta.ModVersion)]
    public class Mod : BaseUnityPlugin
    {
        /// <summary>
        /// The mod instance.
        /// </summary>
        private static Mod _instance;

        /// <summary>
        /// The mod logger.
        /// </summary>
        internal static ManualLogSource ModLogger;

        /// <summary>
        /// The harmony instance to patch game methods.
        /// </summary>
        private readonly Harmony _harmony = new Harmony(ModConstants.Meta.ModGuid);

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }

            ModLogger = BepInEx.Logging.Logger.CreateLogSource(ModConstants.Meta.ModGuid);

            ModLogger.LogInfo("The mod has been loaded successfully");

            ModConfig.Init(Config);

            _harmony.PatchAll();
        }
    }
}