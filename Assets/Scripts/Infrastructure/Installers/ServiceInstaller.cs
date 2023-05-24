using Infrastructure.DI;
using Infrastructure.Services;
using Services;
using UnityEngine;

namespace Infrastructure.Installers
{
    public class ServiceInstaller : MonoBehaviour
    {
        [SerializeField] private Transform _ObjectsSpawnPoint;
        
        private ServiceLocator _serviceLocator;

        public void Construct(ServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }
    
        public void RegisterServices()
        {
            _serviceLocator.RegisterService<StaticDataService>(new StaticDataService());        
            _serviceLocator.RegisterService<GameFactory>(
                new GameFactory(_serviceLocator, _ObjectsSpawnPoint));
            _serviceLocator.RegisterService<PersistantProgressService>(new PersistantProgressService());
            _serviceLocator.RegisterService<SaveLoadService>(new SaveLoadService
            (_serviceLocator.GetService<GameFactory>()
                ,_serviceLocator.GetService<PersistantProgressService>()));
        }
    }
}
