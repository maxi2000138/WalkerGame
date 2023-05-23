using System;
using System.Collections.Generic;
using System.Linq;
using Data.DataObjects;
using Data.Extensions;
using Services;

namespace Inventory.Model
{
    public class Inventory : ISavedProgress
    {
        public IReadOnlyList<IReadonlyCell> Cells => _cells;

        private List<Cell> _cells;
    
        public int MaxWeight { get; private set; }

        public event Action OnInventoryChanged;

        public Inventory()
        {
            _cells = new List<Cell>();
        }
    
        public void AddItem(Item item, int count)
        {
            Cell newCell = new Cell(item, count);

            Cell listCel = _cells.FirstOrDefault(cell => cell.Item.TypeId == item.TypeId);

            if (listCel == null)
                _cells.Add(newCell);
            else
                listCel.Merge(newCell);
            
            OnInventoryChanged?.Invoke();
        }

        public void LoadProgress(PlayerProgress playerProgress)
        {
            List<CellData> cells = playerProgress.Inventory.Cells;
            if (cells == null)
                _cells = new List<Cell>();
            else
                _cells = cells.ToInventoryList();
        }

        public void UpdateProgress(PlayerProgress playerProgress)
        {
            playerProgress.Inventory.Cells = _cells.ToInventoryDataList();
        }
    }
}