using Infrastructure.DI;
using Infrastructure.Installers;
using Infrastructure.Services;
using Player;
using Services;
using UnityEngine;

namespace Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private ServiceInstaller _serviceInstaller;
        [SerializeField] private GameWorldInstaller _gameWorldInstaller;
        [SerializeField] private StaticDataInstaller _staticDataInstaller;
        [SerializeField] private ProgressInstaller _progressInstaller;
        [SerializeField] private LoadingCurtain _loadingCurtain;
    
        private readonly ServiceLocator _serviceLocator = ServiceLocator.Container;
    
        private void Awake()
        {
            _serviceInstaller.Construct(_serviceLocator); 
            _serviceInstaller.RegisterServices();
     
            _staticDataInstaller.Construct(_serviceLocator.GetService<StaticDataService>());
            _staticDataInstaller.LoadStaticData();
        
            _gameWorldInstaller.Construct(_serviceLocator.GetService<GameFactory>(), _serviceLocator.GetService<SaveLoadService>());
            _gameWorldInstaller.InitGameWorld();
        
            _progressInstaller.Construct(
                _serviceLocator.GetService<GameFactory>()
                ,_serviceLocator.GetService<PersistantProgressService>()
                , _serviceLocator.GetService<SaveLoadService>());
            _progressInstaller.LoadProgressOrInitNew();
            _progressInstaller.InformProgressReaders();
            
            _loadingCurtain.Hide();
        }
    }
}