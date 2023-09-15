public abstract class Item {
    private ItemName name;
    public readonly int MAX_STACK;
    // Property
    public ItemName Name { get => name; private set => this.name = value; }

    public Item(ItemName name, int maxStack) {
        this.name = name;
        MAX_STACK = maxStack;
    }

    public Item(ItemName name) : this(name, 1) {}

    /// <summary>
    /// Creates a copy of the Item object.
    /// </summary>
    /// <returns>A new item object that is a copy of itself.</returns>
    public abstract Item Copy();

    public static bool operator ==(Item obj1, Item obj2) {
        return obj1.Equals(obj2);
    }

    public static bool operator !=(Item obj1, Item obj2) {
        return !(obj1.Equals(obj2));
    }

    // Abstract methods.
    public abstract override bool Equals(object? obj);
    public abstract override int GetHashCode();
    public abstract override string ToString();
}