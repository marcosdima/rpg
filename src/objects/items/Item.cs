public abstract class Item {

    private Rarity rarity;

    // Properties.
    public Rarity Grade { get => this.rarity; }

    public Item(RarityGrade rarity) {
        this.rarity = new Rarity(rarity);
    }
    
}