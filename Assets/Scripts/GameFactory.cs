using System.Collections.Generic;
using UnityEngine;

public class GameFactory
{
    public List<ISavedProgress> ProgressWriters = new List<ISavedProgress>();
    public List<ISavedProgressReader> ProgressReaders = new List<ISavedProgressReader>();


    public Player CreatePlayer(Transform spawnPoint)
    {
        GameObject player = GameObject.Instantiate(Resources.Load(ResourcePathes.Player), spawnPoint.position,
            Quaternion.identity) as GameObject;

        RegisterProgressWatchers(player);

        return player.GetComponent<Player>();
    }
    
    public Enemy CreateEnemy(Transform spawnPoint)
    {
        GameObject enemy = GameObject.Instantiate(Resources.Load(ResourcePathes.Enemy), spawnPoint.position,
            Quaternion.identity) as GameObject;

        RegisterProgressWatchers(enemy);

        return enemy.GetComponent<Enemy>();
    }
    
    

    private void RegisterProgressWatchers(GameObject player)
    {
        foreach (ISavedProgressReader progressReader in player.GetComponentsInChildren<ISavedProgressReader>())
            Register(progressReader);
    }

    private void Register(ISavedProgressReader progressReader)
    {
        if(progressReader is ISavedProgress progressWriter)
            ProgressWriters.Add(progressWriter);
        
        ProgressReaders.Add(progressReader);
    }

    public void Cleanup()
    {
        ProgressReaders.Clear();
        ProgressWriters.Clear();
    }
}
