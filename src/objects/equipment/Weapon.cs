public class Weapon : Equipment {
    private int power;

    // Properties.
    public int Power { get; }

    public Weapon(int power, int maxUses) : base(EquipmentType.WEAPON, maxUses) {
        // Adds the ATK modifier...
        this.AddModifier(new RemovableModifier(Attribute.ATK, power));
    }

}