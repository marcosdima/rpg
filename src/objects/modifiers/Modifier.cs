public abstract class Modifier {
    private Attribute attribute;
    private int power;
    private int id;
    private static int ModifierCount = 1;

    // Properties.
    public Attribute Att { get => this.attribute; }
    public int Power { get => this.power; } 
    public int ID { get => this.id; }

    public Modifier(Attribute attribute, int power) {
        this.power = power;
        this.attribute = attribute;
        this.SetID();
    }

    private void SetID() {
        this.id = Modifier.ModifierCount;
        Modifier.ModifierCount++;
    }

    // Comparation.
    public static bool operator ==(Modifier? obj1, Modifier? obj2) {
        return obj1?.Equals(obj2) ?? false;
    }

    public static bool operator !=(Modifier obj1, Modifier obj2) {
        return !(obj1.Equals(obj2));
    }

    public override bool Equals(object? obj)  {
        bool result;

        // Checks if obj its null or it's from a different class.
        if (obj == null || this.GetType() != obj.GetType()) result = false;
        else {
            Modifier modAux = (Modifier) obj;
            // If has the same name and rarity, they're equals.
            result = (modAux.ID == this.ID);
        }

        return result;
    }
    
    public override int GetHashCode(){
        // A prime number initial value to avoid frequent collisions.
        int hashCode = 17;
        hashCode = hashCode * 31 + this.ID.GetHashCode();

        return hashCode;
    }

    public override string ToString() {
        return $"{this.Att} -> {this.power}";
    }
}