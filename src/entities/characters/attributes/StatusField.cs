using System;
public class StatusField : IStatusField {
    private int baseValue;
    private int currentValue;

    public StatusField(int baseValue, int currentValue) {
        this.baseValue = baseValue;
        this.currentValue = currentValue;
    }

    public StatusField(int value) : this(value, value) {}

    public void ModifyCurrentValue(int magnitude) {
        // Current value must be >= 0.
        this.currentValue = Math.Max(this.currentValue + magnitude, 0);
    }

    public int GetCurrentValue() {
        return this.currentValue;
    }

    public int GetBaseValue() {
        return this.baseValue;
    }

}