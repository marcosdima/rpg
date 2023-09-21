public interface IEquipable {
    public int UsesLeft { get; }
    public int MaxUses { get; }

    /// <summary>
    /// Retrieves a list of IModifier, which corresponds with the object modifiers.
    /// </summary>
    /// <returns>A list of IModifier.</returns>
    public List<IModifier> GetModifiers();
    
    /// <summary>
    /// Checks if the item is equipable.
    /// </summary>
    /// <returns>True if the item is equipable. Otherwise, false.</returns>
    public bool Equipable();

}