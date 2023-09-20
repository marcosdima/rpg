public class Status {
    private Dictionary<Attribute, StatusField> statusValues;

    public Status(BaseAttributes attributes) {
        this.statusValues = new Dictionary<Attribute, StatusField>();
        this.SetStatusValues(attributes);
    }
    
    /// <summary>
    /// Initializes and configures status values for each attribute based on the provided 'BaseAttribute'.
    /// Status values are stored in a dictionary, where the key is the attribute and the value is the corresponding StatusField.
    /// </summary>
    /// <param name="attributes">The 'BaseAttribute' to use for initializing status values.</param>
    private void SetStatusValues(BaseAttributes attributes) {
        // Capaz no deberían conocerse entre sí... pero bueeeno.
        StatusField aux;
        this.statusValues = new Dictionary<Attribute, StatusField>();

        Attribute[] attsEnum = (Attribute[]) Enum.GetValues(typeof(Attribute));
        foreach (Attribute att in attsEnum) {
            aux = new StatusField(attributes.GetAttribute(att));
            this.statusValues.Add(att, aux);
        }
    }

    public void AddStatusField(Attribute attribute, int value) {} // TODO
    
    /// <summary>
    /// Gets the attribute 'attribute' and applies a modification of 'magnitude' on it.
    /// </summary>
    /// <param name="attribute">Attribute target.</param>
    /// <param name="magnitude">Magnitude of the modification.</param>
    public int ModifyStatusField(Attribute attribute, int magnitude) {
        return this.statusValues[attribute].ModifyCurrentValue(magnitude);
    }
    
    /// <summary>
    /// Retrieves the status field (as IStatusField) associated with the specified attribute.
    /// </summary>
    /// <param name="attribute">Attribute target.</param>
    public IStatusField GetStatusField(Attribute attribute) {
         // Could throw an error if attribute is null, but by definition 'Status' have references to all elements of 'Attribute'.
        return this.statusValues[attribute];
    }
    
    public void Reset() {} // TODO
    
    /// <summary>
    /// Retrieves the status values for all attributes as a dictionary.
    /// Converts the internal status field values to the IStatusField interface.
    /// </summary>
    /// <returns>A dictionary containing status values for all attributes.</returns>
    public Dictionary<Attribute, IStatusField> GetStatusValues() {
        Dictionary<Attribute, IStatusField> response = new Dictionary<Attribute, IStatusField>();
        
        foreach(KeyValuePair<Attribute, StatusField> kvp in this.statusValues) {
            response.Add(kvp.Key, (IStatusField) kvp.Value);
        }

        return response;
    }
}