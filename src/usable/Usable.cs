public abstract class Usable {
    private Rarity rarity;
    public static Rarity LOWEST_RARITY = Rarity.LOW;
    public static Rarity HIGHEST_RARITY = Rarity.HIGH;

    // Property
    public Rarity Rarity { get => rarity; private set => rarity = value; }

    public Usable(Rarity rarity) {
        this.Rarity = rarity;
    }

    public void UpgradeRarity() {
        if (this.rarity < Usable.HIGHEST_RARITY) this.rarity++; 
    }

    public void DegradeRarity() {
        if (this.rarity > Usable.LOWEST_RARITY) this.rarity--; 
    }
}