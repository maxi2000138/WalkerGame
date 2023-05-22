using System;

namespace Data.DataObjects
{
    [Serializable]
    public class PlayerProgress
    {
        public WorldData WorldData;
        public State HeroState;

        public PlayerProgress()
        {
            WorldData = new WorldData();
            HeroState = new State();
        }
    }
}