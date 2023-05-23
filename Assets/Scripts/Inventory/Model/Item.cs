using Data.TypeIds;
using UnityEngine;

namespace Inventory.Model
{
    public class Item
    {
        public readonly Sprite Icon;
        public readonly LootTypeId TypeId;

        public Item(Sprite icon, LootTypeId typeId)
        {
            TypeId = typeId;
            Icon = icon;
        }
    }
}