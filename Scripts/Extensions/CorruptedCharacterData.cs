using System;
using System.Runtime.CompilerServices;

namespace CorruptedCardsManager.Extensions {
    public class CorruptedCharacterData {
        public float CorruptedCardSpawnChance = 0f;
        public float CorruptedCardSpawnChancePerPick = 0f;
        public float CorruptedCardSpawnChancePerFight = 0f;

        public void Reset() {
            CorruptedCardSpawnChancePerPick = 0f;
            CorruptedCardSpawnChancePerFight = 0f;
        }
    }

    public static class CorruptedCharacterDataExtensions {
        public static readonly ConditionalWeakTable<CharacterData, CorruptedCharacterData> data = new ConditionalWeakTable<CharacterData, CorruptedCharacterData>();

        public static CorruptedCharacterData GetAdditionalData(this CharacterData block) {
            return data.GetOrCreateValue(block);
        }

        public static void AddData(this CharacterData block, CorruptedCharacterData value) {
            try {
                data.Add(block, value);
            } catch(Exception) { }
        }
    }
}
