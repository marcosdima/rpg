public class Armor : IArmor {
    private Dictionary<EquipmentType, Equipment> armor;
    private Character wearer;

    public Armor(Character wearer) {
        this.armor = new Dictionary<EquipmentType, Equipment>();
        this.wearer = wearer;
    }

    private void Remove(Equipment toRemove) {
        foreach (RemovableModifier mod in toRemove.GetModifiers()) this.wearer.RecieveModifier(mod.Reset());
    }

    private void Add(Equipment newPart) {
        this.armor.Add(newPart.Type, newPart);
        foreach (RemovableModifier mod in newPart.GetModifiers()) this.wearer.RecieveModifier(mod);
    }

    /// <summary>
    ///     Adds a new armor equipment. In case its place was full, returns the old equipment.
    /// </summary>
    /// <param name="newPart">New armor equipment</param>
    /// <returns>The former equipment or, in case the place was empty, null.</returns>
    public Equipment? AddEquipment(Equipment newPart) {
        Equipment? oldPart;
        if (this.armor.TryGetValue(newPart.Type, out oldPart)) this.Remove(oldPart);
        this.Add(newPart);
        return oldPart;
    }

    /// <summary>
    ///     Removes a piece of armor.
    /// </summary>
    /// <param name="target">The piece which has to be removed.</param>
    /// <returns>The piece removed or, in case there was no piece, null.</returns>
    public Equipment? RemoveEquipment(EquipmentType target) {
        Equipment? removed;
        if (this.armor.TryGetValue(target, out removed)) this.Remove(removed);
        return removed;
    }

    // IArmor //
    public Dictionary<EquipmentType, IEquipable> GetComponents() {
        Dictionary<EquipmentType, IEquipable> result = new Dictionary<EquipmentType, IEquipable>();
        foreach (KeyValuePair<EquipmentType, Equipment> pair in this.armor) result.Add(pair.Key, pair.Value);
        return result;
    }
}