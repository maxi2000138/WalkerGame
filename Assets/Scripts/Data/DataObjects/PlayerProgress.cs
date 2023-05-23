using System;
using System.Collections.Generic;
using Inventory.Model;

namespace Data.DataObjects
{
    [Serializable]
    public class PlayerProgress
    {
        public WorldData WorldData;
        public State HeroState;
        public InventoryData Inventory;

        public PlayerProgress()
        {
            WorldData = new WorldData();
            HeroState = new State();
            Inventory = new InventoryData(new List<IReadonlyCell>());
        }
    }
}