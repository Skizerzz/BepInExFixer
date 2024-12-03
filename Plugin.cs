using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace BepInExFixer {
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin {
        internal static new ManualLogSource Logger;

        private void Awake() {
            // Plugin startup logic
            Logger = base.Logger;
            Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

            Harmony harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(GameManager), nameof(GameManager.Init_CacheExplorer))]
        public static class GameManager_Init_CacheExplorer {
            public static bool Prefix() {
                return false;
            }
        }
    }
}
