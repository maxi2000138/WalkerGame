namespace Inventory.Model
{
    public interface IReadonlyCell
    {
        Item Item { get; }
        int Count { get; }    
    }
}