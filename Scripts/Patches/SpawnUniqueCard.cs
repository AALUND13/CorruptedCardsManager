using CorruptedCardsManager.Extensions;
using CorruptedCardsManager.Utils;
using HarmonyLib;
using ModdingUtils.Patches;
using System.Linq;
using UnityEngine;

namespace CorruptedCardsManager.Patches {
    [HarmonyPatch(typeof(CardChoice), "SpawnUniqueCard")]
    [HarmonyAfter("com.Root.Null")]
    internal class SpawnUniqueCardPatch {
        [HarmonyPriority(Priority.Last)]
        private static void Postfix(int ___pickrID, ref GameObject __result) {
            Player player = PlayerManager.instance.players.Find(p => p.playerID == ___pickrID);
            CardInfo cardInfo = __result.GetComponent<CardInfo>();
            if(player == null) return;

            // Check if the card is a 'Null' card, if so skip it
            if(cardInfo.GetComponents<MonoBehaviour>().Any(x => x.GetType().Name == "NullCard")) return;

            bool corruptedCardSpawnChance = Random.Range(0f, 1f) < player.data.GetAdditionalData().CorruptedCardSpawnChance;
            if(!corruptedCardSpawnChance) return;

            GameObject pickCard = CardChoicePatchGetRanomCard.OrignialGetRanomCard(CorruptedCardsGenerators.DrawableCorruptedCards.Keys.ToArray());
            __result = CorruptedCardsGenerators.DrawableCorruptedCards[pickCard.GetComponent<CardInfo>()].ReplaceCard(cardInfo);

            LoggerUtils.LogInfo($"Corrupted Card Spawned: {cardInfo.cardName} -> {pickCard.GetComponent<CardInfo>().cardName}");
        }
    }
}
