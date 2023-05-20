using UnityEngine;
using System.IO;

public class SaveLoadService
{
    private readonly string filePath;
    private GameFactory _gameFactory;
    private PersistantProgressService _progressService;
    
    public SaveLoadService(GameFactory gameFactory, PersistantProgressService progressService)
    {
        _gameFactory = gameFactory;
        _progressService = progressService;
        filePath = Application.persistentDataPath + "/GameData.json";
    }

    public void SaveProgress()
    {
        _gameFactory.ProgressWriters.ForEach(progressWriters => 
            progressWriters.UpdateProgress(_progressService.PlayerProgress));
        var file = File.Create(filePath);
        File.WriteAllText(filePath, _progressService.PlayerProgress.ToJson());
    }
    public PlayerProgress LoadProgress()
    {
        if (!File.Exists(filePath))
            return null;

        string jsonData = File.ReadAllText(filePath);
        return jsonData.ToDeserialized<PlayerProgress>();
    }
}