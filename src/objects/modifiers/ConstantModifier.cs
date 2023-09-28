public class ConstantModifier : Modifier {
    public ConstantModifier(Attribute attribute, int power) : base(attribute, power) {}

    public override void SetPower(int power) => this.Power = power;
}