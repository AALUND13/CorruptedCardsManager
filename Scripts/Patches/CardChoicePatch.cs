using CorruptedCardsManager.Extensions;
using HarmonyLib;
using ModdingUtils.Patches;
using System;
using System.Linq;

namespace CorruptedCardsManager.Patches {
    [HarmonyPatch(typeof(CardChoice), "StartPick")]
    public class CardChoicePatch {
        private static void Prefix(int pickerIDToSet) {
            Player player = PlayerManager.instance.players[pickerIDToSet];
            player.data.GetAdditionalData().CorruptedCardSpawnChance += player.data.GetAdditionalData().CorruptedCardSpawnChancePerPick;
        }
    }

    [HarmonyPatch(typeof(CardChoicePatchGetRanomCard), "EfficientGetRanomCard", new Type[] { typeof(Player), typeof(CardInfo[]) })]
    public class CardChoicePatchGetRanomCardPatch {
        private static void Prefix(Player player, ref CardInfo[] cards) {
            if(player == null || cards == null || cards.Length == 0)
                return;

            bool corruptedCardSpawnChance = UnityEngine.Random.Range(0f, 1f) < player.data.GetAdditionalData().CorruptedCardSpawnChance;
            if(!corruptedCardSpawnChance) return;

            cards = CorruptedCardsManager.DrawableCorruptedCards.Keys.ToArray();
        }
    }
}
