public class ItemReference {
    private ItemName name;
    private ItemCategory category;
    private ItemSubCategory? subCategory;
    private readonly int maxStack;

    public int MAX_STACK { get => this.maxStack; }

    // Properties.
    public ItemName Name { get => name; }
    public ItemCategory Category { get => category; }
    public ItemSubCategory? SubCategory { get => subCategory; }

    public ItemReference(ItemName name, ItemCategory category, ItemSubCategory? subCategory, int maxStack) {
        this.name = name;
        this.category = category;
        this.subCategory = subCategory;
        this.maxStack = maxStack;
    }

    public ItemReference(ItemName name, ItemCategory category, int maxStack) : this(name, category, null, maxStack) {}

    public override string ToString() => 
            $"{this.category}.{this.subCategory}.{this.name}" ?? 
            // If subcategory is null...
            $"{this.category}.{this.name}";

    public static bool operator ==(ItemReference obj1, ItemReference obj2) => obj1.ToString() == obj2.ToString();

    public static bool operator !=(ItemReference obj1, ItemReference obj2) => !(obj1.ToString() == obj2.ToString());

    public override bool Equals(object? obj) {
        bool result;

        // Checks if obj its null or it's from a different class.
        if (obj == null || this.GetType() != obj.GetType()) result = false;
        else {
            ItemReference itemAux = (ItemReference) obj;
            // If has the same name and rarity, they're equals.
            result = (this.ToString() == itemAux.ToString());
        }

        return result;
    }
    
    public override int GetHashCode() {
        // A prime number initial value to avoid frequent collisions.
        int hashCode = 17;
        hashCode = hashCode * 31 + this.ToString().GetHashCode();

        return hashCode;
    }

}