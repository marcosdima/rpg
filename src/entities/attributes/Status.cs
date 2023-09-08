using System.Collections.Generic;
using System;
using UnityEngine;
using RandomSystem = System.Random;

public class Status {
    private Dictionary<Attribute, StatusField> statusValues;

    public Status(BaseAttributes attributes) {
        this.SetStatusValues(attributes);
    }
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
    public void AddStatusField(Attribute attribute, int value) {}
    public void ModifyStatusField(Attribute attribute, int magnitude) {
        // Gets the attribute 'attribute' and applies the magnitude.
        this.statusValues[attribute].ModifyCurrentValue(magnitude);
    }
    public IStatusField GetStatusField(Attribute attribute) {
        // Puede dar error si es nulo.
        return this.statusValues[attribute];
    }
    public void Reset() {}
    public Dictionary<Attribute, IStatusField> GetStatusValues() {
        Dictionary<Attribute, IStatusField> response = new Dictionary<Attribute, IStatusField>();
        foreach(KeyValuePair<Attribute, StatusField> kvp in this.statusValues) {
            response.Add(kvp.Key, (IStatusField) kvp.Value);
        }

        return response;
    }
    public int GetAttribute(Attribute attribute) {
        return this.GetStatusField(attribute).GetCurrentValue();
    }
}