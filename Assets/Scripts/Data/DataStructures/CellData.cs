using System;
using Data.TypeIds;
using Inventory.Model;

namespace Data.DataStructures
{
    [Serializable]
    public class CellData
    {
        public LootTypeId LootTypeId;
        public int Count;

        public CellData(IReadonlyCell cell)
        {
            LootTypeId = cell.Item.TypeId;
            Count = cell.Count;
        }
    }
}