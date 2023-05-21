using Cinemachine;
using Sirenix.OdinInspector;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private CustomJoystick _joystick;
    [SerializeField] private ShootButton _shootButton;
    
    private Player _player;
    private Enemy _testEnemy;
    private PersistantProgressService _persistantProgressService;
    private PlayerInputRouter _playerInputRouter;
    private SaveLoadService _saveLoadService;
    private GameFactory _gameFactory;
    private StaticDataService _staticDataService;
    private ServiceLocator _serviceLocator = ServiceLocator.Container;

    private const string PlayerSpawnPointTag = "PlayerSpawnPoint";
    private const string EnemySpawnPointTag = "EnemySpawnPoint";

    private void Awake()
    {
        RegisterServices();
        LoadStaticData();
        InitGameWorld();
        LoadProgressOrInitNew();
        InformProgressReaders();
    }

    private void LoadStaticData()
    {
        _serviceLocator.GetService<StaticDataService>().LoadStaticData();
    }

    private void InitGameWorld()
    {
        _serviceLocator.GetService<GameFactory>().Cleanup();
        SpawnPlayer();
        SpawnZombie();
        InitInputRouter();
    }

    private void InitInputRouter()
    {
        _playerInputRouter = new PlayerInputRouter(_joystick, _player.PlayerMove, _player.PlayerGunRotater,
            _player.PlayerShoot, _shootButton);
    }

    private void SpawnZombie()
    {
        Transform enemySpawnPoint = GameObject.FindGameObjectWithTag(EnemySpawnPointTag).transform;
        _testEnemy = _serviceLocator.GetService<GameFactory>().CreateEnemy(enemySpawnPoint, EnemyTypeId.zombie);
    }

    private void InformProgressReaders()
    {
        _serviceLocator.GetService<GameFactory>().ProgressReaders.ForEach(progressReader => 
            progressReader.LoadProgress(_serviceLocator.GetService<PersistantProgressService>().PlayerProgress));
    }

    private void SpawnPlayer()
    {
        Transform PlayerSpawnPoint = GameObject.FindGameObjectWithTag(PlayerSpawnPointTag).transform;
        _player = _serviceLocator.GetService<GameFactory>().CreatePlayer(PlayerSpawnPoint, PlayerTypeId.DefaultPlayer, BulletTypeId.DefaultBullet);
        _camera.Follow = _player.transform;
    }

    private void RegisterServices()
    {
        _serviceLocator.RegisterService<StaticDataService>(new StaticDataService());        
        _serviceLocator.RegisterService<GameFactory>(new GameFactory(_serviceLocator.GetService<StaticDataService>()));
        _serviceLocator.RegisterService<PersistantProgressService>(new PersistantProgressService());
        _serviceLocator.RegisterService<SaveLoadService>(new SaveLoadService
                (_serviceLocator.GetService<GameFactory>()
                ,_serviceLocator.GetService<PersistantProgressService>()));
    }

    private void LoadProgressOrInitNew()
    {
        _serviceLocator.GetService<PersistantProgressService>().PlayerProgress = _serviceLocator.GetService<SaveLoadService>().LoadProgress() ?? NewProgress();
    }

    private PlayerProgress NewProgress() => 
        new PlayerProgress();

    private void OnEnable()
    {
        _playerInputRouter.OnEnable();
    }

    private void OnDisable()
    {
        _playerInputRouter.OnDisable();
    }

    private void FixedUpdate()
    {
        _playerInputRouter.Update(Time.deltaTime);
    }

    [Button]
    public void SaveProgress()
    {
        _saveLoadService.SaveProgress();
    }
    
    [Button]
    public void LoadProgress()
    {
        _saveLoadService.LoadProgress();
        _gameFactory.ProgressReaders.ForEach((progressReader => progressReader.LoadProgress(_persistantProgressService.PlayerProgress)));
    }
    
    [Button]
    public void ResetProgress()
    {
        _saveLoadService.ResetProgress(NewProgress());
    }
}