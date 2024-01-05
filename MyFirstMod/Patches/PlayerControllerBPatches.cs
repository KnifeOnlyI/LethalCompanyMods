using GameNetcodeStuff;
using HarmonyLib;

namespace MyFirstMod.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatches
    {
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        // ReSharper disable once InconsistentNaming
        private static void InfiniteStamina(PlayerControllerB __instance)
        {
            if (Data.InfiniteStamina)
            {
                __instance.sprintMeter = 1f;
            }
        }
    }
}