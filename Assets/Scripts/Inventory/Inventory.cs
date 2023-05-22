using System.Collections.Generic;

namespace Inventory
{
    public class Inventory
    {
        public IReadOnlyList<IReadonlyCell> Cells;
    
        private List<Cell> _cells;
    
        public int MaxWeight { get; private set; }
    
        public void AddItem(Item item, int count)
        {
            Cell newCell = new Cell(item, count);

            Cell listCel = _cells.Find(cell => cell.Item == item);

            if (listCel == null)
                _cells.Add(newCell);
            else
                listCel.Merge(newCell);
        }
    
    }
}