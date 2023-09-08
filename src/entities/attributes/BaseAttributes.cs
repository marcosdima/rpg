using System.Collections.Generic;
using System;

public class BaseAttributes {
    public Dictionary<Attribute, int> attributes;

    public BaseAttributes() {
        this.SetAttributes();
    }

    private void SetAttributes() {
        this.attributes = new Dictionary<Attribute, int>();
        Attribute[] attributes = (Attribute[]) Enum.GetValues(typeof(Attribute));
        foreach (Attribute attr in attributes) {
            this.attributes.Add(attr, 0);
        }
    }
    private void ModifyAttribute(Attribute attribute, int magnitude) {
        // If the key exists, increase the magnitude.
        if (this.attributes.ContainsKey(attribute)) 
            attributes[attribute] = Math.Max(attributes[attribute] += magnitude, 0);
        else Console.WriteLine("The attribute ", attribute, " doesn't exist...");
    }
    public void RiseAttribute(Attribute attribute) {
        this.ModifyAttribute(attribute, 1);
    }
    public void DecreaseAttribute(Attribute attribute) {
        this.ModifyAttribute(attribute, -1);
    }
    public int GetAttribute(Attribute attribute) {
        return this.attributes[attribute];
    }
}