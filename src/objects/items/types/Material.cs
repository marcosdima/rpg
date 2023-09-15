public class Material : Item {

    public Material(ItemName name, int maxStack) : base(name, maxStack) {}
    public Material(ItemName name) : base(name) {}

    public override Item Copy(){
        return new Material(this.Name, this.MAX_STACK);
    }

    public override bool Equals(object? obj){
        bool result;

        // Checks if obj its null or it's from a different class.
        if (obj == null || this.GetType() != obj.GetType()) result = false;
        else {
            Item itemAux = (Item) obj;
            // If has the same name and rarity, they're equals.
            result = (itemAux.Name == this.Name);
        }

        return result;
    }

    public override int GetHashCode(){
        // A prime number initial value to avoid frequent collisions.
        int hashCode = 17;
        hashCode = hashCode * 31 + this.Name.GetHashCode();

        return hashCode;
    }

    public override string ToString() {
        return this.Name.ToString();
    }
}