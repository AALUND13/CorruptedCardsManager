using CorruptedCardsManager.Extensions;
using TabInfo.Utils;

namespace CorruptedCardsManager {
    public class TabinfoInterface {
        public static void Setup() {
            var CCMStatsCategory = TabInfoManager.RegisterCategory("CCM Stats", 3);
            TabInfoManager.RegisterStat(CCMStatsCategory, "Corrupted Cards Spawn Chance", (p) => p.data.GetAdditionalData().CorruptedCardSpawnChance != 0,
                (p) => $"{p.data.GetAdditionalData().CorruptedCardSpawnChance * 100:0}%");
            TabInfoManager.RegisterStat(CCMStatsCategory, "Corrupted Cards Spawn Chance Per Pick", (p) => p.data.GetAdditionalData().CorruptedCardSpawnChancePerPick != 0,
                (p) => $"{p.data.GetAdditionalData().CorruptedCardSpawnChancePerPick * 100:0}%");
            TabInfoManager.RegisterStat(CCMStatsCategory, "Corrupted Cards Spawn Chance Per Fight", (p) => p.data.GetAdditionalData().CorruptedCardSpawnChancePerFight != 0,
                (p) => $"{p.data.GetAdditionalData().CorruptedCardSpawnChancePerFight * 100:0}%");
        }
    }
}
