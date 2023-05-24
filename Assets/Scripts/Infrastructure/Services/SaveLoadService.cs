using System.IO;
using Data.DataStructures;
using Data.Extensions;
using Infrastructure.DI;
using Services;
using UnityEngine;

namespace Infrastructure.Services
{
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

        public async void ResetProgress()
        {
            _progressService.PlayerProgress = null;
        
            StreamWriter writer = new StreamWriter(filePath, false);
            await writer.WriteAsync(_progressService.PlayerProgress.ToJson());
            writer.Close();
        }

        public async void SaveProgress()
        {
            _gameFactory.ProgressWriters.ForEach(progressWriters => 
                progressWriters.UpdateProgress(_progressService.PlayerProgress));
        
            StreamWriter writer = new StreamWriter(filePath, false);
            await writer.WriteAsync(_progressService.PlayerProgress.ToJson());
            writer.Close();
        }
        
        public PlayerProgress LoadProgress()
        {
            if (!File.Exists(filePath))
                return null;
            
            StreamReader reader = new StreamReader(filePath);
            string line = reader.ReadLine();
            return line.ToDeserialized<PlayerProgress>();
        }
    }
}