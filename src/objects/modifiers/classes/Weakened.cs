public class Weakened : FiniteModifier {
    public Weakened(int power) : base(Attribute.ATK, (power * -1), 10) {}

    public override void SetPower(int power) {
        this.Power = power * -1;
    }
}