using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using MyFirstMod.gui;
using MyFirstMod.Patches;
using UnityEngine;

namespace MyFirstMod
{
    [BepInPlugin(ModGUI, ModName, ModVersion)]
    public class MyFirstMod : BaseUnityPlugin
    {
        private const string ModGUI = "KnifeOnlyI.LethalCompany.MyFirstMod";
        private const string ModName = "MyFirstMod";
        private const string ModVersion = "1.0.0";

        private readonly Harmony _harmony = new Harmony(ModGUI);

        private static MyFirstMod _instance;


        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }

            Data.ModLogger = BepInEx.Logging.Logger.CreateLogSource(ModGUI);

            Data.ModLogger.LogInfo("The mod has been loaded!");

            _harmony.PatchAll(typeof(MyFirstMod));
            _harmony.PatchAll(typeof(PlayerControllerBPatches));
        }

        public void FixedUpdate()
        {
            if (GameObject.Find("Loader")) return;

            var loader = new GameObject("Loader");

            loader.AddComponent<Gui>();
        }
    }
}