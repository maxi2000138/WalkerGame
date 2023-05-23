using System;
using System.Collections.Generic;
using Inventory.Model;
using Sirenix.Utilities;

namespace Data.DataObjects
{
    [Serializable]
    public class InventoryData
    {
        public List<CellData> Cells;
        public InventoryData(IReadOnlyList<IReadonlyCell> inventory)
        {
           
        }
    }
}