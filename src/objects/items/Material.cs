public class Material : Item {

    public Material(ItemName name, int maxStack) : base(name, maxStack) {}
    public Material(ItemName name) : base(name) {}

    public override Item Copy(){
        return new Material(this.Name, this.MAX_STACK);
    }
}