public class Damage : ConstantModifier {

    public Damage(int power) : base(Attribute.HP, (power * (-1))) {}

    public override void SetPower(int power) {
        this.Power = power * -1;
    }
    
}