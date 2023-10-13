using System;

public class Slot : ISlot {
    private static int slots = 1;
    private ItemReference content;
    private int quantity = 0;
    private int id;

    // Properties.
    public ItemReference Content { get => this.content; }
    public int Quantity { get => this.quantity; }
    public int ID { get => this.id; }

    public Slot(ItemReference item, int quantity) {
        this.content = item;
        this.IncreaseQuantity(quantity);
        this.SetID();
    }

    public Slot(ItemReference item) : this(item, 0) {}

    /// <summary>
    /// Sets the unique ID for the current slot and increments the global slot counter.
    /// </summary>
    private void SetID() {
        this.id = Slot.slots;
        Slot.slots++;
    }

    /// <summary>
    /// Increses the quantity of an item based on a new quantity, considering the maximum stack size.
    /// </summary>
    /// <param name="newQuantity">The new quantity to set.</param>
    /// <returns>The quantity that couldn't fit in the stack due to the maximum stack size.</returns>
    public int IncreaseQuantity(int newQuantity) {
        int leftOvers = newQuantity;

        // Checks if the newQuantity is positive.
        if (leftOvers <= 0) return 0;
        
        // While quantity doesn't exceed the MAX_STACK value of content, increases quantity.
        while (this.content.MAX_STACK > this.quantity && leftOvers > 0) {
            this.quantity++;
            leftOvers--;
        }
        // At the end, if quantity reachs the max value posible, with leftovers > 0, returns the 'left overs'.

        return leftOvers;
    }

    /// <summary>
    /// Checks if the content is empty.
    /// </summary>
    /// <returns>True if the content is empty. Otherwise, false.</returns>
    public bool IsEmpty() => (this.quantity == 0);

    /// <summary>
    /// Takes a specified number (positive) of items from the slot's quantity.
    /// </summary>
    /// <param name="took">The number of items to take.</param>
    /// <returns>The actual number of items which were taken.</returns>
    public int Take(int wanted) {
        int quantityTaken = 0;

        // Checks if the newQuantity is positive.
        if (wanted <= 0) return quantityTaken;

        // While quantity doesn't reach 0 and itemsTook is lower than took, decreases quantity.
        if (wanted > quantity) quantityTaken = this.quantity;
        else quantityTaken = wanted;

        // Updates quantity attribute.
        this.quantity = Math.Max(this.quantity - wanted, 0);
 
        return quantityTaken;
    }

    public override bool Equals(object? obj){
        bool result;
        
        // Checks if obj its null or it's from a different class.
        if (obj == null || this.GetType() != obj.GetType()) result = false;
        else {
            Slot itemAux = (Slot) obj;
            // If has the same id, they're equals.
            result = (itemAux.ID == this.ID);
        }

        return result;
    }

    public override int GetHashCode(){
        // A prime number initial value to avoid frequent collisions.
        int hashCode = 17;
        hashCode = hashCode * 31 + this.id.GetHashCode();

        return hashCode;
    }
}