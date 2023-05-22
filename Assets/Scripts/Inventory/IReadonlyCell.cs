namespace Inventory
{
    public interface IReadonlyCell
    {
        Item Item { get; }
        int Count { get; }    
    }
}