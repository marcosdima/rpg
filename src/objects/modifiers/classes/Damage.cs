public class Damage : Modifier {
    public Damage(int power) : base(Attribute.HP, (power * (-1))) {}
}