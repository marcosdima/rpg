public class Modifier : IModifier {
    private Attribute attribute;
    private int power;
    private ModifierAction buff;
    private int id;
    private static int ModifierCount = 1;

    // Properties.
    public Attribute Att { get => this.attribute; }
    public int Power { get => this.power; set => this.power = value; } 
    public int ID { get => this.id; }
    public ModifierAction IsBuff { get => this.buff; set => this.buff = value; }

    public Modifier(Attribute attribute, int power, ModifierAction buff) {
        this.attribute = attribute;
        this.buff = buff;
        this.SetPower(power);
        this.SetID();
    }

    private void SetID() {
        this.id = Modifier.ModifierCount;
        Modifier.ModifierCount++;
    }

    public void SetPower(int power) {
        // If its a debuff, sets the power as negative.
        if (this.buff == ModifierAction.DEBUFF) power *= -1;

        this.power = power;
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