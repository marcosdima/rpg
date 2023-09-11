public class Item : Usable {
    private ItemName name;

    // Property
    public ItemName Name { get => name; private set => this.name = value; }

    public Item(ItemName name, Rarity rarity) : base(rarity) {
        this.name = name;
    }
}