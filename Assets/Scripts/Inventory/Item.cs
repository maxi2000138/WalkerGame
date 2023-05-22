using UnityEngine;

namespace Inventory
{
    public class Item
    {
        private readonly Sprite _icon;

        public Item(Sprite Icon)
        {
            _icon = Icon;
        }
    }
}