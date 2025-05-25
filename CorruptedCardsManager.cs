using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace CorruptedCardsManager {
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("com.aalund13.rounds.random_cards_generator", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin(modId, modName, "1.0.0")]
    [BepInProcess("Rounds.exe")]
    public class CorruptedCardsManager : BaseUnityPlugin {
        private const string modId = "com.aalund13.rounds.corrupted_manager";
        private const string modName = "Corrupted Manager";
        internal const string modInitials = "CM";
        
        internal static CorruptedCardsManager instance;
        internal static AssetBundle assets;
        internal static GameObject corruptedCardFancyIconPrefab;

        void Awake() {
            instance = this;
            new Harmony(modId).PatchAll();

            assets = Jotunn.Utils.AssetUtils.LoadAssetBundleFromResources("corruptedmanager_assets", typeof(CorruptedCardsManager).Assembly);
            corruptedCardFancyIconPrefab = assets.LoadAsset<GameObject>("I_Corrupted");

            CorruptedCardsGenerators.Init();

            Debug.Log($"{modName} loaded!");
        }
    }
}