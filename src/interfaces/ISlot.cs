public interface ISlot {
    public ItemReference Content { get; } 
    public int Quantity { get; } 
    public int ID { get; }
    public int Take(int took);
    public int IncreaseQuantity(int newQuantity);
    public bool IsEmpty();
}