using System;

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