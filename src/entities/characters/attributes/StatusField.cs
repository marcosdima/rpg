public class StatusField : IStatusField {
    private int baseValue;
    private int currentValue;

    public StatusField(int baseValue, int currentValue) {
        this.baseValue = baseValue;
        this.currentValue = currentValue;
    }

    public StatusField(int value) : this(value, value) {}

    public int ModifyCurrentValue(int magnitude) {
        // Current value must be >= 0.
        int newValue = magnitude + currentValue;

        if (newValue < 0) {
            // NewValue is negative, so sets magnitude to as the actual modification magnitude...
            magnitude = magnitude - newValue;
        }

        this.currentValue += magnitude;

        // Returns the actual modification value.
        return magnitude;
    }

    public int GetCurrentValue() {
        return this.currentValue;
    }

    public int GetBaseValue() {
        return this.baseValue;
    }
}