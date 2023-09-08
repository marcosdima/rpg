public abstract class Modifier {
    private Attribute attribute;
    private int power;
    private int uses;

    public Modifier(Attribute attribute, int power, int uses) {
        this.power = power;
        this.attribute = attribute;
        this.uses = uses;
    }

    // Returns True if the modifier has to be reseted when the uses are equals to zero.
    public abstract bool HasToReset();
    public bool Applicable() {
        /*
            A modifier is 'Applicable' if uses is higher than zero.
        */
        return (this.uses > 0);
    }
    public Attribute GetAttribute() {
        return this.attribute;
    }
    public int GetPower() {
        return this.power;
    }
    public void ReduceUses() {
        this.uses--;
    }
}