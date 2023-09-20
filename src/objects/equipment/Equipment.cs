public abstract class Equipment : IEquipable {
    private int maxUses = 0;   
    private int usesLeft = 0;
    private Character? wearer;
    // This modifiers will be applied to the wearer.
    private List<RemovableModifier> modifiers = new List<RemovableModifier>();

    // Properties.
    public int UsesLeft { get => usesLeft; }
    public int MaxUses { get => maxUses; }

    public Equipment(int maxUses) {
        this.SetMaxUses(maxUses);
    }

    /// <summary>
    /// Sets the maximum number of uses for an item, ensuring it's a non-negative value.
    /// Initializes the current number of uses to the maximum value.
    /// </summary>
    /// <param name="maxUses">The maximum number of uses for the item.</param>
    private void SetMaxUses(int maxUses) {
        this.maxUses = Math.Max(maxUses, 0);
        this.usesLeft = this.maxUses;
    }

    /// <summary>
    /// Repairs the item by increasing its current uses.
    /// </summary>
    /// <param name="magnitude">The amount by which to repair the item's uses.</param>
    public void Repair(int magnitude) {
        this.usesLeft = Math.Min(this.usesLeft + magnitude, this.maxUses);
    }

    /// <summary>
    /// Reduces the number of remaining uses by one.
    /// </summary>
    public void Use() {
        if (this.usesLeft > 0) this.usesLeft--;
    }

    public void Equip(Character ch) {
        if (this.wearer != null) this.Unequip();
        this.wearer = ch;
        foreach(RemovableModifier mod in this.modifiers) ch.RecieveModifier(mod);
    }

    public void Unequip() {
        foreach(RemovableModifier mod in this.modifiers) this.wearer?.RecieveModifier(mod.Reset());
    }

    // IEquipment //
    public bool Equipable() {
        return (this.usesLeft > 0);
    }

    public List<IModifier> GetModifiers() {
        List<IModifier> result = new List<IModifier>();
        foreach (Modifier mod in modifiers) result.Add(mod);
        return result;
    }
}

