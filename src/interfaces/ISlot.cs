public interface ISlot {
    public Item Content { get; } 
    public int Quantity { get; } 
    public int ID { get; }
    public int Take(int took);
    public int IncreaseQuantity(int newQuantity);
    public bool IsEmpty();
}