public class Storage {
    private List<Slot> space;
    private int totalSpace;

    // Properties.
    public int Size { get => totalSpace ; private set => totalSpace = value; }
    public int Count { get => this.space.Count; }
    
    public Storage(int size) {
        this.Size = size;
        this.space = new List<Slot>();
    }

    private void Remove(Item item, int cantity) {
        Slot slotAux;

        // Searchs for the item 
        foreach (Slot slot in this.space) {
            if (slot.Content == item) slotAux = slot;
        }
    }
    
    /// <summary>
    /// Adds a new item to the storage while ensuring there is enough space.
    /// </summary>
    /// <param name="item">The item to be added.</param>
    /// <param name="quantity">The quantity of the item to add.</param>
    /// <returns>The quantity of items that couldn't be added due to insufficient space.</returns>
    private int AddNewItem(Item item, int quantity) {
        Slot auxSlot;
        int leftOvers = quantity;

        // Creates all the slots needed, while storage has available space and has items to add (leftOvers > 0).
        while (leftOvers > 0 && this.totalSpace > this.Count) {
            auxSlot = new Slot(item);
            leftOvers = auxSlot.IncreaseQuantity(leftOvers);
            this.space.Add(auxSlot);
        }

        return leftOvers;
    }

    /// <summary>
    /// Adds 'quantiy' items to the Storage if there is available space.
    /// </summary>
    /// <param name="item">The item to be added.</param>
    /// <param name="quantity">The quantity of items to be added.</param>
    public int Add(Item item, int quantity) {
        // Searchs for all the slots wich has 'item' as content and increse its quantity.
        foreach (Slot slot in this.space) {
            if (slot.Content == item && quantity > 0) {
                quantity = slot.IncreaseQuantity(quantity);
            }
        }

        // If after the search leftOvers is higher than 0 and storage has space available...
        if (quantity > 0) quantity = this.AddNewItem(item, quantity);

        return quantity;
    }

    /// <summary>
    /// Adds an item to the Storage if there is available space.
    /// </summary>
    /// <param name="item">The item to be added.</param>
    public int Add(Item item) {
        return this.Add(item, 1);
    }

    /// <summary>
    /// Retrieves a list of slots from the space, converted to the ISlot interface.
    /// </summary>
    /// <returns>A list of ISlot interfaces representing the slots in the space.</returns>
    public List<ISlot> GetSpace() {
        List<ISlot> result = new List<ISlot>();

        foreach (Slot slot in this.space) result.Add((ISlot) slot);

        return result;
    }
}