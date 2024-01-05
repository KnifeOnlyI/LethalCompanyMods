using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;

namespace Koi.LethalCompany.DisableSpeaker.Patches
{
    /// <summary>
    /// All patches for the PlayerControllerB class.
    /// </summary>
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatches
    {
        /// <summary>
        /// The reference to the speaker audio source in the ship.
        /// </summary>
        private static AudioSource _speakerAudioSource;

        /// <summary>
        /// Disable the speaker audio source in ship on player awake.
        /// </summary>
        [HarmonyPatch("Awake")]
        [HarmonyPostfix]
        // ReSharper disable once InconsistentNaming
        private static void DisableSpeaker()
        {
            if (!ModConfig.ConfigEnabled.Value) return;

            var speaker = GameObject.Find(ModConstants.GameObjectPath.SpeakerAudioGameObjectPath);

            if (speaker == null)
            {
                Mod.ModLogger.LogWarning("SpeakerAudio game object not found in scene");

                return;
            }

            _speakerAudioSource = speaker.GetComponent<AudioSource>();

            if (_speakerAudioSource == null)
            {
                Mod.ModLogger.LogWarning("AudioSource component not found in SpeakerAudio game object");

                return;
            }

            Mod.ModLogger.LogInfo("SpeakerAudio has been muted");

            _speakerAudioSource.mute = true;
        }
    }
}