using GameNetcodeStuff;
using HarmonyLib;

namespace Koi.LethalCompany.UnlimitedStamina.Patches
{
    /// <summary>
    /// All patches for the PlayerControllerB class.
    /// </summary>
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatches
    {
        /// <summary>
        /// Disable the stamina consumption.
        /// </summary>
        /// <param name="__instance"></param>
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        // ReSharper disable once InconsistentNaming
        private static void InfiniteStamina(PlayerControllerB __instance)
        {
            if (!ModConfig.ConfigEnabled.Value) return;

            __instance.sprintMeter = 1f;
            __instance.isExhausted = false;
        }
    }
}