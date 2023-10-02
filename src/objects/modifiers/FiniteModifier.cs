public abstract class FiniteModifier : RemovableModifier {
    private int uses = 0;

    // Properties.
    public int Uses { get => this.uses; }

    public FiniteModifier(Attribute attribute, int power, int uses, ModifierAction buff) : base(attribute, power, buff) {
        this.uses = uses;
    }

    /// <summary>
    /// Checks if the modifier is applicable based on the number of remaining uses.
    /// A modifier is considered applicable if the number of uses is higher than zero.
    /// </summary>
    /// <returns>True if the modifier is applicable. Otherwise, false.</returns>
    public bool Applicable() => (this.uses > 0);

    /// <summary>
    /// Reduces the number of remaining uses by one.
    /// </summary>
    public void ReduceUses() {
        if (uses > 0) this.uses--;
    }
}