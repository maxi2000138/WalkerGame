using Data.DataStructures;
using Infrastructure.Services;
using Services;
using UnityEngine;

namespace Infrastructure.Installers
{
    public class ProgressInstaller : MonoBehaviour
    {
    
        private GameFactory _gameFactory;
        private PersistantProgressService _persistantProgressService;
        private SaveLoadService _saveLoadService;

        public void Construct(GameFactory gameFactory, PersistantProgressService persistantProgressService, SaveLoadService saveLoadService)
        {
            _gameFactory = gameFactory;
            _saveLoadService = saveLoadService;
            _persistantProgressService = persistantProgressService;
        }
    
        public void InformProgressReaders()
        {
            _gameFactory.ProgressReaders.ForEach(progressReader => 
                progressReader.LoadProgress(_persistantProgressService.PlayerProgress));
        }
    
        public void LoadProgressOrInitNew()
        {
            _persistantProgressService.PlayerProgress = _saveLoadService.LoadProgress() ?? NewProgress();
        }

        private PlayerProgress NewProgress() => 
            new PlayerProgress();
        
    }
}
