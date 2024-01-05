using HarmonyLib;

namespace Koi.LethalCompany.UnlimitedBattery.Patches
{
    /// <summary>
    /// All patches for the PlayerControllerB class.
    /// </summary>
    [HarmonyPatch(typeof(GrabbableObject))]
    internal class GrabbableObjectPatches
    {
        /// <summary>
        /// Set the battery charge to 100% on update of the grabbable object.
        /// </summary>
        /// <param name="__instance">The instance</param>
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        // ReSharper disable once InconsistentNaming
        public static void UnlimitedBattery(GrabbableObject __instance)
        {
            if (!ModConfig.ConfigEnabled.Value || !__instance.itemProperties.requiresBattery) return;

            __instance.insertedBattery.empty = false;
            __instance.insertedBattery.charge = 100f;
        }
    }
}