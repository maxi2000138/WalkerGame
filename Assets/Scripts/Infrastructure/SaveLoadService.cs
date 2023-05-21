using UnityEngine;
using System.IO;

public class SaveLoadService : IService
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

    public async void ResetProgress(PlayerProgress defaultProgress)
    {
        _progressService.PlayerProgress = defaultProgress;
        
        StreamWriter writer = new StreamWriter(filePath, false);
        await writer.WriteAsync(_progressService.PlayerProgress.ToJson());
        writer.Close();
        Debug.Log(_progressService.PlayerProgress.ToJson() + "\n" + filePath);
    }

    public async void SaveProgress()
    {
        _gameFactory.ProgressWriters.ForEach(progressWriters => 
            progressWriters.UpdateProgress(_progressService.PlayerProgress));
        
        StreamWriter writer = new StreamWriter(filePath, false);
        await writer.WriteAsync(_progressService.PlayerProgress.ToJson());
        writer.Close();
        Debug.Log(_progressService.PlayerProgress.ToJson() + "\n" + filePath);
    }
    public PlayerProgress LoadProgress()
    {
        StreamReader reader = new StreamReader(filePath);
        string line = reader.ReadLine();
        Debug.Log(line.ToDeserialized<PlayerProgress>());
        return line.ToDeserialized<PlayerProgress>();
    }
}