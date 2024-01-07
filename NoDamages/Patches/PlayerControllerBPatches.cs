using GameNetcodeStuff;
using HarmonyLib;

namespace Koi.LethalCompany.NoDamages.Patches
{
    /// <summary>
    /// All patches for the PlayerControllerB class.
    /// </summary>
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatches
    {
        /// <summary>
        /// Cancel damages to player.
        /// </summary>
        /// <param name="damageNumber">The amount of damage inflicted to player before patch</param>
        [HarmonyPatch("DamagePlayer")]
        [HarmonyPrefix]
        private static void CancelDamagesToPlayer(ref int damageNumber)
        {
            if (!ModConfig.ConfigEnabled.Value) return;

            damageNumber = 0;
        }

        /// <summary>
        /// Cancel player death.
        /// </summary>
        /// <param name="__result">The initial result of the patched method</param>
        /// <returns></returns>
        [HarmonyPatch("AllowPlayerDeath")]
        [HarmonyPrefix]
        // ReSharper disable once InconsistentNaming
        private static bool CancelPlayerDeath(ref bool __result)
        {
            if (!ModConfig.ConfigEnabled.Value || !ModConfig.NoDeath.Value) return true;

            __result = false;

            return false;
        }
    }
}