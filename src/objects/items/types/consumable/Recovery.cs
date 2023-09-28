using System.Reflection.Metadata;

public class Recovery : Consumable {

    public Recovery(RarityGrade rarity, Attribute attribute, int power) : base(rarity, attribute, power) {}

    public Recovery(Attribute attribute, int power) : base(attribute, power) {}

    public override Modifier Consume() => new ConstantModifier(this.Att, this.Power);
}