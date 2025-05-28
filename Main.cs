using BepInEx;
using BepInEx.Logging;
using CorruptedCardsManager.Extensions;
using HarmonyLib;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnboundLib.GameModes;
using UnityEngine;

namespace CorruptedCardsManager {
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("com.aalund13.rounds.random_cards_generator", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("root.rarity.lib", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("com.CrazyCoders.Rounds.RarityBundle", BepInDependency.DependencyFlags.HardDependency)]

    [BepInDependency("com.willuwontu.rounds.tabinfo", BepInDependency.DependencyFlags.SoftDependency)]

    [BepInPlugin(modId, modName, "1.0.0")]
    [BepInProcess("Rounds.exe")]
    public class Main : BaseUnityPlugin {
        private const string modId = "com.aalund13.rounds.corrupted_cards_manager";
        private const string modName = "Corrupted Cards Manager";
        internal const string modInitials = "CCM";

        internal static Main instance;
        internal static AssetBundle assets;
        internal static ManualLogSource ModLogger;
        internal static GameObject corruptedCardFancyIconPrefab;


        private void Awake() {
            instance = this;
            ModLogger = Logger;

            new Harmony(modId).PatchAll();

            assets = Jotunn.Utils.AssetUtils.LoadAssetBundleFromResources("corruptedmanager_assets", typeof(Main).Assembly);
            corruptedCardFancyIconPrefab = assets.LoadAsset<GameObject>("I_Corrupted");

            Debug.Log($"{modName} loaded!");
        }

        private void Start() {
            var Plugins = (List<BaseUnityPlugin>)typeof(BepInEx.Bootstrap.Chainloader).GetField("_plugins", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);
            if(Plugins.Exists(plugin => plugin.Info.Metadata.GUID == "com.willuwontu.rounds.tabinfo"))
                TabinfoInterface.Setup();

            GameModeManager.AddHook(GameModeHooks.HookBattleStart, WhenBattleStarts);
            GameModeManager.AddHook(GameModeHooks.HookGameStart, WhenGameStart);

            CorruptedCardsManager.Init();
        }

        private IEnumerator WhenBattleStarts(IGameModeHandler handler) {
            foreach(var player in PlayerManager.instance.players) {
                player.data.GetAdditionalData().CorruptedCardSpawnChance += player.data.GetAdditionalData().CorruptedCardSpawnChancePerFight;
            }
            yield break;
        }

        private IEnumerator WhenGameStart(IGameModeHandler handler) {
            foreach(var player in PlayerManager.instance.players) {
                player.data.GetAdditionalData().CorruptedCardSpawnChance = 0f;
            }
            yield break;
        }
    }
}