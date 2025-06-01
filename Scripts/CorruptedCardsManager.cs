using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using CorruptedCardsManager.MonoBehaviours;
using CorruptedCardsManager.StatsGroup;
using CorruptedCardsManager.Utils;
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

    public static class CorruptedCardsManager {
        public readonly static Dictionary<CardInfo, DrawableRandomCard> DrawableCorruptedCards = new Dictionary<CardInfo, DrawableRandomCard>();
        public readonly static CardCategory CantCorruptedCardCategory = CustomCardCategories.instance.CardCategory("CantCorruptedCardCategory");

        public static ModRandomCardsGenerators<CorruptedCardRarity> CorruptedCardsGenerators;

        private readonly static Dictionary<CorruptedCardRarity, RandomCardsGenerator> cardGenerators = new Dictionary<CorruptedCardRarity, RandomCardsGenerator>();

        internal static void Init() {
            CreateCardGenerators();
            CorruptedCardsGenerators = new ModRandomCardsGenerators<CorruptedCardRarity>(cardGenerators);
            
            LoggerUtils.LogInfo("Corrupted Cards Manager initialized!");
#if DEBUG
            LoggerUtils.LogInfo(GenerateCorruptedCardMarkdown());
#endif
        }

        private static void CreateCardGenerators() {
            LoggerUtils.LogInfo("Creating corrupted card generators...");
            CreateRandomCardsGenerator(CorruptedCardRarity.Trinket, new List<RandomStatGenerator> {
                new DamageStatGenerator(-0.15f, 0.1f),
                new ReloadTimeStatGenerator(-0.1f, 0.1f),
                new AttackSpeedStatGenerator(-0.1f, 0.1f),
                new MovementSpeedStatGenerator(-0.05f, 0.05f, 0.01f),
                new HealthStatGenerator(-0.1f, 0.1f),
                new BulletSpeedStatGenerator(-0.1f, 0.1f),
                new AmmoStatGenerator(-1f, 1f),
            }, 1, 2);
            CreateRandomCardsGenerator(CorruptedCardRarity.Common, new List<RandomStatGenerator> {
                new DamageStatGenerator(-0.3f, 0.3f),
                new ReloadTimeStatGenerator(-0.3f, 0.15f),
                new AttackSpeedStatGenerator(-0.3f, 0.15f),
                new MovementSpeedStatGenerator(-0.1f, 0.1f),
                new HealthStatGenerator(-0.3f, 0.3f),
                new BlockCooldownStatGenerator(-0.05f, 0.05f),
                new BulletSpeedStatGenerator(-0.3f, 0.3f),
                new AmmoStatGenerator(-2f, 2f),
                new CorruptedCardSpawnChanceStatGenerator(-0.05f, 0.05f)
            }, 1, 3);
            CreateRandomCardsGenerator(CorruptedCardRarity.Scarce, new List<RandomStatGenerator> {
                new DamageStatGenerator(-0.35f, 0.4f),
                new ReloadTimeStatGenerator(-0.4f, 0.2f),
                new AttackSpeedStatGenerator(-0.4f, 0.2f),
                new MovementSpeedStatGenerator(-0.15f, 0.2f),
                new HealthStatGenerator(-0.25f, 0.4f),
                new BlockCooldownStatGenerator(-0.1f, 0.1f),
                new BulletSpeedStatGenerator(-0.3f, 0.35f),
                new AmmoStatGenerator(-2f, 3f),
                new CorruptedCardSpawnChanceStatGenerator(-0.075f, 0.075f)
            }, 1, 3);
            CreateRandomCardsGenerator(CorruptedCardRarity.Uncommon, new List<RandomStatGenerator> {
                new DamageStatGenerator(-0.4f, 0.5f),
                new ReloadTimeStatGenerator(-0.45f, 0.255f),
                new AttackSpeedStatGenerator(-0.45f, 0.25f),
                new MovementSpeedStatGenerator(-0.15f, 0.25f),
                new HealthStatGenerator(-0.25f, 0.5f),
                new BlockCooldownStatGenerator(-0.15f, 0.1f),
                new BulletSpeedStatGenerator(-0.3f, 0.4f),
                new AmmoStatGenerator(-2f, 4f),
                new RegenStatGenerator(0, 5f),
                new AdditionalBlocksStatGenerator(0, RandomStatsUtils.ScaleStatByIntensity(0.15f, 1f)),
                new CorruptedCardSpawnChanceStatGenerator(-0.1f, 0.1f)
            }, 1, 3);
            CreateRandomCardsGenerator(CorruptedCardRarity.Exotic, new List<RandomStatGenerator> {
                new DamageStatGenerator(-0.45f, 0.6f),
                new ReloadTimeStatGenerator(-0.5f, 0.25f),
                new AttackSpeedStatGenerator(-0.5f, 0.25f),
                new MovementSpeedStatGenerator(-0.2f, 0.3f),
                new HealthStatGenerator(-0.3f, 0.6f),
                new BlockCooldownStatGenerator(-0.20f, 0.15f),
                new BulletSpeedStatGenerator(-0.3f, 0.5f),
                new AmmoStatGenerator(-3f, 5f),
                new RegenStatGenerator(0, 8),
                new AdditionalBlocksStatGenerator(0, RandomStatsUtils.ScaleStatByIntensity(0.2f, 1f)),
                new CorruptedCardSpawnChanceStatGenerator(-0.15f, 0.15f)
            }, 1, 4);
            CreateRandomCardsGenerator(CorruptedCardRarity.Rare, new List<RandomStatGenerator> {
                new DamageStatGenerator(-0.5f, 0.8f),
                new ReloadTimeStatGenerator(-0.6f, 0.3f),
                new AttackSpeedStatGenerator(-0.6f, 0.3f),
                new MovementSpeedStatGenerator(-0.2f, 0.35f),
                new HealthStatGenerator(-0.35f, 0.75f),
                new BlockCooldownStatGenerator(-0.25f, 0.15f),
                new BulletSpeedStatGenerator(-0.3f, 0.60f),
                new AmmoStatGenerator(-3f, 6f),
                new RegenStatGenerator(0, 15f),
                new JumpStatGenerator(0f, 1f),
                new AdditionalBlocksStatGenerator(0, RandomStatsUtils.ScaleStatByIntensity(0.25f, 1f)),
                new CorruptedCardSpawnChanceStatGenerator(-0.2f, 0.2f)
            }, 1, 4);
            CreateRandomCardsGenerator(CorruptedCardRarity.Epic, new List<RandomStatGenerator> {
                new DamageStatGenerator(-0.55f, 0.9f),
                new ReloadTimeStatGenerator(-0.7f, 0.35f),
                new AttackSpeedStatGenerator(-0.7f, 0.35f),
                new MovementSpeedStatGenerator(-0.25f, 0.4f),
                new HealthStatGenerator(-0.45f, 0.9f),
                new BlockCooldownStatGenerator(-0.3f, 0.20f),
                new BulletSpeedStatGenerator(-0.3f, 0.65f),
                new AmmoStatGenerator(-4f, 7f),
                new RegenStatGenerator(0, 25f),
                new JumpStatGenerator(0f, 1.5f),
                new AdditionalBlocksStatGenerator(0, RandomStatsUtils.ScaleStatByIntensity(0.3f, 1f)),
                new ExtraLiveStatGenerator(0, RandomStatsUtils.ScaleStatByIntensity(0.275f, 1f)),
                new CorruptedCardSpawnChanceStatGenerator(-0.25f, 0.25f)
            }, 1, 5);
            CreateRandomCardsGenerator(CorruptedCardRarity.Legendary, new List<RandomStatGenerator> {
                new DamageStatGenerator(-0.6f, 1f),
                new ReloadTimeStatGenerator(-0.75f, 0.40f),
                new AttackSpeedStatGenerator(-0.75f, 0.40f),
                new MovementSpeedStatGenerator(-0.25f, 0.45f),
                new HealthStatGenerator(-0.50f, 1f),
                new BlockCooldownStatGenerator(-0.35f, 0.20f),
                new BulletSpeedStatGenerator(-0.3f, 0.75f),
                new AmmoStatGenerator(-4f, 8f),
                new RegenStatGenerator(0, 35),
                new JumpStatGenerator(0f, 2f),
                new AdditionalBlocksStatGenerator(0, RandomStatsUtils.ScaleStatByIntensity(0.4f, 1f)),
                new ExtraLiveStatGenerator(0, RandomStatsUtils.ScaleStatByIntensity(0.35f, 1f)),
                new CorruptedCardSpawnChanceStatGenerator(-0.35f, 0.35f)
            }, 1, 5);
            CreateRandomCardsGenerator(CorruptedCardRarity.Mythical, new List<RandomStatGenerator> {
                new DamageStatGenerator(-0.65f, 1.25f),
                new ReloadTimeStatGenerator(-0.8f, 0.45f),
                new AttackSpeedStatGenerator(-0.8f, 0.45f),
                new MovementSpeedStatGenerator(-0.3f, 0.5f),
                new HealthStatGenerator(-0.55f, 1.25f),
                new BlockCooldownStatGenerator(-0.4f, 0.25f),
                new BulletSpeedStatGenerator(-0.3f, 0.8f),
                new AmmoStatGenerator(-5f, 10f),
                new RegenStatGenerator(0, 45),
                new JumpStatGenerator(0f, 2.5f),
                new AdditionalBlocksStatGenerator(0, RandomStatsUtils.ScaleStatByIntensity(0.5f, 1f)),
                new ExtraLiveStatGenerator(0, RandomStatsUtils.ScaleStatByIntensity(0.45f, 1f)),
                new CorruptedCardSpawnChanceStatGenerator(-0.4f, 0.4f)
            }, 1, 6);
            CreateRandomCardsGenerator(CorruptedCardRarity.Divine, new List<RandomStatGenerator> {
                new DamageStatGenerator(-0.7f, 1.5f),
                new ReloadTimeStatGenerator(-0.85f, 0.5f),
                new AttackSpeedStatGenerator(-0.85f, 0.5f),
                new MovementSpeedStatGenerator(-0.35f, 0.55f),
                new HealthStatGenerator(-0.65f, 1.5f),
                new BlockCooldownStatGenerator(-0.45f, 0.25f),
                new BulletSpeedStatGenerator(-0.3f, 0.85f),
                new AmmoStatGenerator(-6f, 15f),
                new RegenStatGenerator(0, 60),
                new JumpStatGenerator(0f, 3f),
                new AdditionalBlocksStatGenerator(0, RandomStatsUtils.ScaleStatByIntensity(0.2f, 2f)),
                new ExtraLiveStatGenerator(0, RandomStatsUtils.ScaleStatByIntensity(0.5f, 2f)),
                new CorruptedCardSpawnChanceStatGenerator(-0.5f, 0.5f)
            }, 1, 6);
            LoggerUtils.LogInfo("Created all corrupted card generators!");
        }

        private static void CreateRandomCardsGenerator(CorruptedCardRarity rarity, List<RandomStatGenerator> statGenerators, int min, int max) {
            cardGenerators[rarity] = new RandomCardsGenerator($"CorruptedCardsGenerator_{rarity}", CreateCardOption(RarityUtils.GetRarity(rarity.ToString()), min, max), statGenerators);
            cardGenerators[rarity].OnCardGenerated += (generatedCardInfo) => {
                generatedCardInfo.CardInfo.gameObject.AddComponent<FancyIcon>().fancyIcon = Main.corruptedCardFancyIconPrefab;
                generatedCardInfo.CardInfo.gameObject.AddComponent<GlitchingCardEffect>();
            };
            
            var drawableCard = new DrawableRandomCard(cardGenerators[rarity]);
            DrawableCorruptedCards[drawableCard.CardInfo] = drawableCard;
            LoggerUtils.LogInfo($"Created {rarity} corrupted card generator!");
        }

        private static RandomCardOption CreateCardOption(CardInfo.Rarity rarity, int min, int max) {
            return new RandomCardOption("Corrupted Card", Main.modInitials, "A corrupted card", "CO", min, max, rarity, CardThemeColor.CardThemeColorType.EvilPurple);
        }

#if DEBUG
        /// <summary>
        /// Only used to generate a markdown file for all the corrupted card rarities and their stats.
        /// </summary>
        private static string GenerateCorruptedCardMarkdown() {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("## Corrupted Cards Rarities");
            foreach(var generator in cardGenerators) {
                sb.AppendLine($"### {generator.Key}");
                sb.AppendLine($"- **Stats**:");
                foreach(var stat in generator.Value.StatGenerators) {
                    sb.AppendLine($"  - **{stat.StatName}**: `{stat.GetStatString(stat.MinValue)}` - `{stat.GetStatString(stat.MaxValue)}`");
                }
                sb.AppendLine($"- **Card Option**:");
                sb.AppendLine($"  - **Min Stats**: {generator.Value.RandomCardOption.Min}");
                sb.AppendLine($"  - **Max Stats**: {generator.Value.RandomCardOption.Max}");
            }
            return sb.ToString();
        }
#endif
    }
}
