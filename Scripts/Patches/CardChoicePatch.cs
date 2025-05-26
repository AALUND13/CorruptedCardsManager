using CorruptedCardsManager.Extensions;
using HarmonyLib;

namespace AALUND13Card.Patches {
    [HarmonyPatch(typeof(CardChoice), "StartPick")]
    public class CardChoicePatch {
        private static void Prefix(int pickerIDToSet) {
            Player player = PlayerManager.instance.players[pickerIDToSet];
            player.data.GetAdditionalData().CorruptedCardSpawnChance += player.data.GetAdditionalData().CorruptedCardSpawnChancePerPick;
        }
    }
}
