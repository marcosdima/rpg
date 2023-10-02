using System.Reflection.Metadata;

public class Recovery : Consumable {

    public Recovery(RarityGrade rarity, Attribute attribute, int power) : base(rarity, attribute, power) {}

    public Recovery(Attribute attribute, int power) : base(attribute, power) {}

    public override Modifier Consume() => new Modifier(this.Att, this.Power, ModifierAction.BUFF);
}