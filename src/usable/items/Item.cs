public class Item : Rarity {
    private ItemName name;
    public readonly int MAX_STACK;
    // Property
    public ItemName Name { get => name; private set => this.name = value; }

    public Item(ItemName name, RarityGrade rarity, int maxStack) : base(rarity) {
        this.name = name;
        MAX_STACK = maxStack;
    }

    public Item(ItemName name, RarityGrade rarity) : this(name, rarity, 1) {}

    /// <summary>
    /// Creates a copy of the Item object.
    /// </summary>
    /// <returns>A new item object that is a copy of itself.</returns>
    public Item Copy() {
        Item copy = new Item(this.name, this.Grade, this.MAX_STACK);
        return copy;
    }

    public override bool Equals(object? obj){
        bool result;

        // Checks if obj its null or it's from a different class.
        if (obj == null || this.GetType() != obj.GetType()) result = false;
        else {
            Item itemAux = (Item) obj;
            // If has the same name and rarity, they're equals.
            result = (itemAux.Name == this.Name && 
                        itemAux.Grade == this.Grade);
        }

        return result;
    }

    public override int GetHashCode(){
        // A prime number initial value to avoid frequent collisions.
        int hashCode = 17;
        hashCode = hashCode * 31 + this.name.GetHashCode();
        hashCode = hashCode * 31 + this.Grade.GetHashCode();

        return hashCode;
    }

    public override string ToString() {
        return this.name + "_" + this.Grade;
    }
}