using System;

namespace Data.DataStructures
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
            Inventory = new InventoryData();
        }
    }
}