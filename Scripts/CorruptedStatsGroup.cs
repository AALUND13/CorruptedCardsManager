using RandomCardsGenerators;
using UnboundLib;
using UnityEngine;

namespace CorruptedCardsManager.StatsGroup {
    public class CorruptedCardSpawnChanceStatGenerator : RandomStatGenerator {
        public override string StatName => "Corrupted Cards Spawn Chance";

        public float ThresholdToZero;
        public CorruptedCardSpawnChanceStatGenerator(float minValue, float maxValue, float thresholdToZero = 0.05f) : base(minValue, maxValue) {
            ThresholdToZero = thresholdToZero;
        }

        public override bool ShouldApply(float value) => Mathf.Abs(value) >= ThresholdToZero;
        public override void Apply(float value, CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block) {
            CorruptedStatModifers corruptedStatModifers = cardInfo.gameObject.GetOrAddComponent<CorruptedStatModifers>();
            corruptedStatModifers.CorruptedCardSpawnChance += value;
        }

        public override bool IsPositive(float value) => value < 0;
    }

}
