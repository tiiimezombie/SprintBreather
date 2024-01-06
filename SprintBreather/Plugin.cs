using BepInEx;
using BepInEx.Logging;

using HarmonyLib;

namespace TZ.SprintBreather
{
    public class SprintBreatherInfo : PluginInfo
    {
        public const string PLUGIN_GUID = "TZ.SprintBreather";
        public const string PLUGIN_NAME = "Sprint Breather";
        public const string PLUGIN_VERSION = "1.0.0";
    }

    /// <summary>
    /// https://www.reddit.com/r/lethalcompany_mods/comments/18refsw/tutorial_creating_lethal_company_mods_with_c/
    /// https://www.youtube.com/watch?v=4Q7Zp5K2ywI
    /// </summary>
    [BepInPlugin(SprintBreatherInfo.PLUGIN_GUID, SprintBreatherInfo.PLUGIN_NAME, SprintBreatherInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private readonly Harmony _harmony = new Harmony(SprintBreatherInfo.PLUGIN_GUID);
        internal ManualLogSource _logSource;

        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {SprintBreatherInfo.PLUGIN_GUID} is loaded!");

            _logSource = BepInEx.Logging.Logger.CreateLogSource(SprintBreatherInfo.PLUGIN_GUID);
            _harmony.PatchAll(typeof(Plugin));

            _harmony.PatchAll(typeof(PatchedPlayerController));
        }
    }
}