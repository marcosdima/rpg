public class Rarity {
    private RarityGrade rarity;
    public static RarityGrade LOWEST_RARITY = RarityGrade.LOW;
    public static RarityGrade HIGHEST_RARITY = RarityGrade.HIGH;

    // Property
    public RarityGrade Grade { get => rarity; private set => rarity = value; }
    public int Interger {get => (int) Grade; }

    public Rarity(RarityGrade rarity) {
        this.rarity = rarity;
    }

    /// <summary>
    /// Increases the rarity of the item if it is lower than the highest possible rarity.
    /// </summary>
    public void UpgradeRarity() {
        if (this.rarity < Rarity.HIGHEST_RARITY) this.rarity++;
    }

    /// <summary>
    /// Decreases the rarity of the item if it is higher than the lowest possible rarity.
    /// </summary>
    public void DegradeRarity() {
        if (this.rarity > Rarity.LOWEST_RARITY) this.rarity--;
    }
}