using System.Collections.Generic;
using System;

public class BaseAttributes {
    public Dictionary<Attribute, int> attributes;

    public BaseAttributes() {
        // Because of Error CS8618.
        this.attributes = new Dictionary<Attribute, int>();
        this.SetAttributes();
    }

    private void SetAttributes() {
        this.attributes = new Dictionary<Attribute, int>();
        // Gets the values of the Attribute enum.
        Attribute[] attributes = (Attribute[]) Enum.GetValues(typeof(Attribute));
        foreach (Attribute attr in attributes) {
            this.attributes.Add(attr, 1);
        }
    }
    private void ModifyAttribute(Attribute attribute, int magnitude) {
        // If the key exists, adds the magnitude.
        if (this.attributes.ContainsKey(attribute)) 
            // The attributes must be positive or 0.
            this.attributes[attribute] = .Max(this.attributes[attribute] += magnitude, 0);
        // This never should happen.
        else Console.WriteLine("The attribute ", attribute, " doesn't exist...");
    }
    public void RiseAttribute(Attribute attribute) {
        this.ModifyAttribute(attribute, 1);
    }
    public void DecreaseAttribute(Attribute attribute) {
        this.ModifyAttribute(attribute, -1);
    }
    public int GetAttribute(Attribute attribute) {
        int value;

        if (attributes.TryGetValue(attribute, out value)) {}
        else {
            // This never should happen.
            Console.WriteLine($"Attribute ({attribute}) does not exists... Wierd...");
            value = -1;
        }

        return value;
    }
}