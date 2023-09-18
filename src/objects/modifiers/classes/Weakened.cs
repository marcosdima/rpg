public class Weakened : FiniteModifier {
    public Weakened(int power) : base(Attribute.ATK, (power * -1), 10) {}
}