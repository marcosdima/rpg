using System.Text.Json.Serialization;

public abstract class Consumable : Item {
    private Attribute attribute;
    private int power;

    // Properties.
    public Attribute Att { get => attribute; }
    public int Power { get => power; }

    // Implements Rarity.
    private Rarity rarity;
    private Rarity Rarity { get => rarity; }

    public Consumable(RarityGrade rarity, Attribute attribute, int power) : base(rarity) {
        this.rarity = new Rarity(rarity);
        this.attribute = attribute;
        this.power = power;
    }
    
    public Consumable(Attribute attribute, int power) : this(RarityGrade.LOW, attribute, power) {}

    private int GetPower() {
        return (this.rarity.Interger * power);
    }

    public abstract Modifier Consume();

    public override string ToString() {
        return $"{base.ToString()}_{this.Att}_{this.power}";
    }
}