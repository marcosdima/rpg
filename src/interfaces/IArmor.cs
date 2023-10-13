using System.Collections.Generic;
public interface IArmor {
    public Dictionary<EquipmentType, IEquipable> GetComponents();
}