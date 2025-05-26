using CorruptedCardsManager.Extensions;
using UnityEngine;

namespace CorruptedCardsManager {
    public class CorruptedStatModifers : MonoBehaviour {
        public float CorruptedCardSpawnChance = 0f;
        public float CorruptedCardSpawnChancePerPick = 0f;
        public float CorruptedCardSpawnChancePerFight = 0f;

        public void Apply(Player player) {
            CharacterData data = player.data;
            var additionalData = data.GetAdditionalData();

            additionalData.CorruptedCardSpawnChance = Mathf.Max(additionalData.CorruptedCardSpawnChance + CorruptedCardSpawnChance, 0f);
            additionalData.CorruptedCardSpawnChancePerPick += CorruptedCardSpawnChancePerPick;
            additionalData.CorruptedCardSpawnChancePerFight += CorruptedCardSpawnChancePerFight;
        }
    }
}
