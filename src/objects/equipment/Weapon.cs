public class Weapon : Equipment {
    private int power;

    // Properties.
    public int Power { get; }

    public Weapon(RarityGrade rarity, int power, int maxUses) : base(rarity, EquipmentType.WEAPON, maxUses) {
        // Adds the ATK modifier...
        this.AddModifier(new RemovableModifier(Attribute.ATK, power));
        this.power = power;
    }

}