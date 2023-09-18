public abstract class SimpleModifier : Modifier {
    public SimpleModifier(Attribute attribute, int power) : base(attribute, power, 1) {}

    override public bool HasToReset() {
        /*
        * This kind of modifier doesn't have to reset.
        */
        return false;
    }
}