## Basic Usage

### Giving Corrupted Cards to Players
To give a player a corrupted card, you can use the following method:
```csharp
CorruptedCardsManager.CorruptedCardsGenerators.CreateRandomCard(CorruptedCardRarity.Legendary, PlayerHere);
```

This will create a random corrupted card with the Legendary rarity and give it to the specified player.

### Available Rarities

The Corrupted Card Manager supports multiple rarity levels, each with different stat ranges:

- `CorruptedCardRarity.Trinket` - Basic cards with minor stat changes
- `CorruptedCardRarity.Common` - Common cards with modest stat changes
- `CorruptedCardRarity.Scarce` - Slightly better than common cards
- `CorruptedCardRarity.Uncommon` - Includes minor additional blocks
- `CorruptedCardRarity.Exotic` - More powerful cards with better stats
- `CorruptedCardRarity.Rare` - Includes jump stat changes
- `CorruptedCardRarity.Epic` - Can provide an extra life
- `CorruptedCardRarity.Legendary` - Powerful cards with significant stat boosts
- `CorruptedCardRarity.Mythical` - Very powerful cards with impressive stats
- `CorruptedCardRarity.Divine` - The most powerful cards with the largest stat ranges

## Integration with Other Mods

### Preventing Cards from Being Corrupted

If you have a special card that should never be corrupted, you can add it to the `CantCorruptedCardCategory`:

```csharp
// Add your card to the category to prevent it from being corrupted
yourCardInfo.categories = new CardCategory[] { CorruptedCardsManager.CantCorruptedCardCategory };
```

### Corrupted Card Spawn Chance

Players can accumulate corrupted card spawn chance through different methods:

1. **Base chance** - Set by cards that modify the `CorruptedCardSpawnChance` stat
2. **Per Pick chance** - Increases the spawn chance each time the player picks a card
3. **Per Fight chance** - Increases the spawn chance at the start of each battle

To modify these values, you can create cards with the `CorruptedCardSpawnChanceStatGenerator` or directly modify a player's values:

```csharp
// Increase a player's chance to find corrupted cards
player.data.GetAdditionalData().CorruptedCardSpawnChance += 0.1f; // 10% higher chance

// Make corrupted cards more likely each time the player picks a card
player.data.GetAdditionalData().CorruptedCardSpawnChancePerPick = 0.05f; // +5% per pick

// Make corrupted cards more likely after each battle
player.data.GetAdditionalData().CorruptedCardSpawnChancePerFight = 0.07f; // +7% per fight
```

## Stats and Ranges

Each rarity level has different possible stat modifiers. For example, a Legendary card might give:

- Damage: Between -30% to +100%
- Movement Speed: Between -25% to +45%
- Health: Between -30% to +100%
- And many other potential stat changes

For complete details on all stat ranges by rarity, refer to the [README.md](https://github.com/AALUND13/CorruptedCardsManager/blob/main/README.md) file.

## Advanced Usage

### Stat Modifiers
To apply custom stat modifiers to a card, you can use the `CorruptedStatModifers` component. 
This allows you to set specific stat changes that will be applied when the player picks the card.

```csharp
// Add a custom stat modifier to a card
CorruptedStatModifers modifiers = card.gameObject.GetOrAddComponent<CorruptedStatModifers>();
// Than set the desired modifiers
modifiers.CorruptedCardSpawnChance = 0.15f;
```
And once the player picks the card, the modifiers will be applied to the player.