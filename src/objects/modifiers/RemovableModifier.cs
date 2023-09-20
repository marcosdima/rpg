public class RemovableModifier : Modifier {
    private int resetPower = 0;

    // Properties.
    public int ResetPower { get => resetPower; set => resetPower = value; }

    public RemovableModifier(Attribute attribute, int power) : base(attribute, power) {
        this.resetPower = power * -1;
    }

    public Modifier Reset() {
        return new Modifier(this.Att, this.resetPower);
    }
}