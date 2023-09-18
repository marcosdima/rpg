public abstract class Modifier {
    private Attribute attribute;
    private int power;

    // Properties.
    public Attribute Att { get => this.attribute; }
    public int Power { get => this.power; } 

    public Modifier(Attribute attribute, int power) {
        this.power = power;
        this.attribute = attribute;
    }
}