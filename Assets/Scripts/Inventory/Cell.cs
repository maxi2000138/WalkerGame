using System;

public class Cell : IReadonlyCell
{
    public Item Item { get; private set; }
    public int Count { get; private set; }
    
    public Cell(Item item, int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException();
        
        Item = item;
        Count = count;
    }

    public void Merge(Cell newCell)
    {
        Count += newCell.Count;
    }
}