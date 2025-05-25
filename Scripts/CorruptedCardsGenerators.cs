using CorruptedCardsManager.MonoBehaviours;
using CorruptedCardsManager.StatsGroup;
using FancyCardBar;
using RandomCardsGenerators;
using RandomCardsGenerators.Cards;
using RandomCardsGenerators.StatsGroup;
using RandomCardsGenerators.Utils;
using RarityLib.Utils;
using System.Collections.Generic;

namespace CorruptedCardsManager {
    public enum CorruptedCardRarity {
        Trinket,
        Common,
        Scarce,
        Uncommon,
        Exotic,
        Rare,
        Epic,
        Legendary,
        Mythical,
        Divine,
    }

    public static class CorruptedCardsGenerators {
        public static ModRandomCardsGenerators<CorruptedCardRarity> CorruptedCardsGenerator;
        public readonly static Dictionary<CardInfo, DrawableRandomStatsCard> DrawableCorruptedCards = new Dictionary<CardInfo, DrawableRandomStatsCard>();

        private readonly static Dictionary<CorruptedCardRarity, RandomCardsGenerator> cardGenerators = new Dictionary<CorruptedCardRarity, RandomCardsGenerator>();


        internal static void Init() {
            CreateCardGenerators();
            CorruptedCardsGenerator = new ModRandomCardsGenerators<CorruptedCardRarity>(cardGenerators);
        }

        private static void CreateCardGenerators() {
            CreateRandomCardsGenerator(CorruptedCardRarity.Trinket, new List<RandomStatGenerator> {
                new DamageStatGenerator(-0.3f, 0.1f),
                new ReloadTimeStatGenerator(-0.1f, 0.1f),
                new AttackSpeedStatGenerator(-0.1f, 0.1f),
                new MovementSpeedStatGenerator(-0.05f, 0.05f, 0.01f),
                new HealthStatGenerator(-0.1f, 0.1f),
                new BulletSpeedStatGenerator(-0.1f, 0.1f),
                new AmmoStatGenerator(-1f, 1f),
            }, 1, 2);
            CreateRandomCardsGenerator(CorruptedCardRarity.Common, new List<RandomStatGenerator> {
                new DamageStatGenerator(-0.3f, 0.3f),
                new ReloadTimeStatGenerator(-0.3f, 0.3f),
                new AttackSpeedStatGenerator(-0.3f, 0.3f),
                new MovementSpeedStatGenerator(-0.1f, 0.1f),
                new HealthStatGenerator(-0.3f, 0.3f),
                new BlockCooldownStatGenerator(-0.05f, 0.05f),
                new BulletSpeedStatGenerator(-0.3f, 0.3f),
                new AmmoStatGenerator(-2f, 2f),
                new CorruptedCardSpawnChanceStatGenerator(-0.05f, 0.05f)
            }, 1, 3);
            CreateRandomCardsGenerator(CorruptedCardRarity.Scarce, new List<RandomStatGenerator> {
                new DamageStatGenerator(-0.3f, 0.4f),
                new ReloadTimeStatGenerator(-0.4f, 0.3f),
                new AttackSpeedStatGenerator(-0.4f, 0.3f),
                new MovementSpeedStatGenerator(-0.15f, 0.2f),
                new HealthStatGenerator(-0.3f, 0.4f),
                new BlockCooldownStatGenerator(-0.1f, 0.1f),
                new BulletSpeedStatGenerator(-0.3f, 0.35f),
                new AmmoStatGenerator(-2f, 3f),
                new RegenStatGenerator(0, 10),
                new CorruptedCardSpawnChanceStatGenerator(-0.075f, 0.075f)
            }, 1, 3);
            CreateRandomCardsGenerator(CorruptedCardRarity.Uncommon, new List<RandomStatGenerator> {
                new DamageStatGenerator(-0.3f, 0.5f),
                new ReloadTimeStatGenerator(-0.45f, 0.3f),
                new AttackSpeedStatGenerator(-0.45f, 0.3f),
                new MovementSpeedStatGenerator(-0.15f, 0.25f),
                new HealthStatGenerator(-0.3f, 0.5f),
                new BlockCooldownStatGenerator(-0.15f, 0.15f),
                new BulletSpeedStatGenerator(-0.3f, 0.4f),
                new AmmoStatGenerator(-2f, 4f),
                new RegenStatGenerator(0, 15),
                new AdditionalBlocksStatGenerator(0, RandomStatsUtils.ScaleStatByIntensity(0.15f, 1f)),
                new CorruptedCardSpawnChanceStatGenerator(-0.1f, 0.1f)
            }, 1, 3);
            CreateRandomCardsGenerator(CorruptedCardRarity.Exotic, new List<RandomStatGenerator> {
                new DamageStatGenerator(-0.3f, 0.6f),
                new ReloadTimeStatGenerator(-0.5f, 0.3f),
                new AttackSpeedStatGenerator(-0.5f, 0.3f),
                new MovementSpeedStatGenerator(-0.2f, 0.3f),
                new HealthStatGenerator(-0.3f, 0.6f),
                new BlockCooldownStatGenerator(-0.20f, 0.20f),
                new BulletSpeedStatGenerator(-0.3f, 0.5f),
                new AmmoStatGenerator(-3f, 5f),
                new RegenStatGenerator(0, 20),
                new AdditionalBlocksStatGenerator(0, RandomStatsUtils.ScaleStatByIntensity(0.2f, 1f)),
                new CorruptedCardSpawnChanceStatGenerator(-0.15f, 0.15f)
            }, 1, 4);
            CreateRandomCardsGenerator(CorruptedCardRarity.Rare, new List<RandomStatGenerator> {
                new DamageStatGenerator(-0.3f, 0.8f),
                new ReloadTimeStatGenerator(-0.6f, 0.3f),
                new AttackSpeedStatGenerator(-0.6f, 0.3f),
                new MovementSpeedStatGenerator(-0.2f, 0.35f),
                new HealthStatGenerator(-0.3f, 0.75f),
                new BlockCooldownStatGenerator(-0.25f, 0.20f),
                new BulletSpeedStatGenerator(-0.3f, 0.60f),
                new AmmoStatGenerator(-3f, 6f),
                new RegenStatGenerator(0, 35),
                new JumpStatGenerator(0f, 1f),
                new AdditionalBlocksStatGenerator(0, RandomStatsUtils.ScaleStatByIntensity(0.25f, 1f)),
                new CorruptedCardSpawnChanceStatGenerator(-0.2f, 0.2f)
            }, 1, 4);
            CreateRandomCardsGenerator(CorruptedCardRarity.Epic, new List<RandomStatGenerator> {
                new DamageStatGenerator(-0.3f, 0.9f),
                new ReloadTimeStatGenerator(-0.7f, 0.3f),
                new AttackSpeedStatGenerator(-0.7f, 0.3f),
                new MovementSpeedStatGenerator(-0.25f, 0.4f),
                new HealthStatGenerator(-0.3f, 0.9f),
                new BlockCooldownStatGenerator(-0.3f, 0.25f),
                new BulletSpeedStatGenerator(-0.3f, 0.65f),
                new AmmoStatGenerator(-4f, 7f),
                new RegenStatGenerator(0, 40),
                new JumpStatGenerator(0f, 1.5f),
                new AdditionalBlocksStatGenerator(0, RandomStatsUtils.ScaleStatByIntensity(0.3f, 1f)),
                new ExtraLiveStatGenerator(0, RandomStatsUtils.ScaleStatByIntensity(0.275f, 1f)),
                new CorruptedCardSpawnChanceStatGenerator(-0.25f, 0.25f)
            }, 1, 5);
            CreateRandomCardsGenerator(CorruptedCardRarity.Legendary, new List<RandomStatGenerator> {
                new DamageStatGenerator(-0.3f, 1f),
                new ReloadTimeStatGenerator(-0.75f, 0.3f),
                new AttackSpeedStatGenerator(-0.75f, 0.3f),
                new MovementSpeedStatGenerator(-0.25f, 0.45f),
                new HealthStatGenerator(-0.3f, 1f),
                new BlockCooldownStatGenerator(-0.35f, 0.25f),
                new BulletSpeedStatGenerator(-0.3f, 0.75f),
                new AmmoStatGenerator(-4f, 8f),
                new RegenStatGenerator(0, 50),
                new JumpStatGenerator(0f, 2f),
                new AdditionalBlocksStatGenerator(0, RandomStatsUtils.ScaleStatByIntensity(0.4f, 1f)),
                new ExtraLiveStatGenerator(0, RandomStatsUtils.ScaleStatByIntensity(0.35f, 1f)),
                new CorruptedCardSpawnChanceStatGenerator(-0.35f, 0.35f)
            }, 1, 5);
            CreateRandomCardsGenerator(CorruptedCardRarity.Mythical, new List<RandomStatGenerator> {
                new DamageStatGenerator(-0.3f, 1.125f),
                new ReloadTimeStatGenerator(-0.8f, 0.3f),
                new AttackSpeedStatGenerator(-0.8f, 0.3f),
                new MovementSpeedStatGenerator(-0.25f, 0.5f),
                new HealthStatGenerator(-0.3f, 1.25f),
                new BlockCooldownStatGenerator(-0.4f, 0.25f),
                new BulletSpeedStatGenerator(-0.3f, 0.8f),
                new AmmoStatGenerator(-5f, 10f),
                new RegenStatGenerator(0, 65),
                new JumpStatGenerator(0f, 2.5f),
                new AdditionalBlocksStatGenerator(0, RandomStatsUtils.ScaleStatByIntensity(0.5f, 1f)),
                new ExtraLiveStatGenerator(0, RandomStatsUtils.ScaleStatByIntensity(0.45f, 1f)),
                new CorruptedCardSpawnChanceStatGenerator(-0.4f, 0.4f)
            }, 1, 6);
            CreateRandomCardsGenerator(CorruptedCardRarity.Divine, new List<RandomStatGenerator> {
                new DamageStatGenerator(-0.3f, 1.5f),
                new ReloadTimeStatGenerator(-0.85f, 0.3f),
                new AttackSpeedStatGenerator(-0.85f, 0.3f),
                new MovementSpeedStatGenerator(-0.25f, 0.55f),
                new HealthStatGenerator(-0.3f, 1.5f),
                new BlockCooldownStatGenerator(-0.45f, 0.25f),
                new BulletSpeedStatGenerator(-0.3f, 0.85f),
                new AmmoStatGenerator(-6f, 15f),
                new RegenStatGenerator(0, 100),
                new JumpStatGenerator(0f, 3f),
                new AdditionalBlocksStatGenerator(0, RandomStatsUtils.ScaleStatByIntensity(0.2f, 2f)),
                new ExtraLiveStatGenerator(0, RandomStatsUtils.ScaleStatByIntensity(0.5f, 2f)),
                new CorruptedCardSpawnChanceStatGenerator(-0.5f, 0.5f)
            }, 1, 6);
        }

        private static void CreateRandomCardsGenerator(CorruptedCardRarity rarity, List<RandomStatGenerator> statGenerators, int min, int max) {
            cardGenerators[rarity] = new RandomCardsGenerator("CorruptedStatGenerator_Trinket", CreateCardOption(RarityUtils.GetRarity(rarity.ToString()), min, max), statGenerators);
            cardGenerators[rarity].OnCardGenerated += (generatedCardInfo) => {
                generatedCardInfo.CardInfo.gameObject.AddComponent<FancyIcon>().fancyIcon = Main.corruptedCardFancyIconPrefab;
                generatedCardInfo.CardInfo.gameObject.AddComponent<GlitchingCardEffect>();
            };

            var drawableCard = new DrawableRandomStatsCard(cardGenerators[rarity]);
            DrawableCorruptedCards[drawableCard.CardInfo] = drawableCard;
        }

        private static RandomCardOption CreateCardOption(CardInfo.Rarity rarity, int min, int max) {
            return new RandomCardOption("Corrupted Card", rarity, Main.modInitials, "A card corrupted by the [REDACTED]", "CO", min, max);
        }
    }
}
