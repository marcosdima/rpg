public class Consumable : Item {
    // Implements Rarity.
    private Rarity rarity;
    private Rarity Rarity { get => rarity; }

    public Consumable(ItemName name, int maxStack, RarityGrade rarity) : base(name, maxStack) {
        this.rarity = new Rarity(rarity);
    }
    public Consumable(ItemName name) : this(name, 1, RarityGrade.LOW) {}

    public override Item Copy(){
        throw new NotImplementedException();
    }

    public override bool Equals(object? obj) {
        bool result;

        // Checks if obj its null or it's from a different class.
        if (obj == null || this.GetType() != obj.GetType()) result = false;
        else {
            Consumable itemAux = (Consumable) obj;
            // If has the same name and rarity, they're equals.
            result = (itemAux.Name == this.Name &&
                        itemAux.Rarity.Grade == this.Rarity.Grade);
        }

        return result;
    }

    public override int GetHashCode(){
        // A prime number initial value to avoid frequent collisions.
        int hashCode = 17;
        hashCode = hashCode * 31 + this.Name.GetHashCode();
        hashCode = hashCode * 31 + this.Rarity.Grade.GetHashCode();

        return hashCode;
    }

    public override string ToString() {
        return this.Name.ToString() + "_" + this.Rarity.Grade;
    }

}