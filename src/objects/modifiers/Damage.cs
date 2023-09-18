public class Damage : SimpleModifier {
    public Damage(int power) : base(Attribute.HP, (power * (-1))) {}
}