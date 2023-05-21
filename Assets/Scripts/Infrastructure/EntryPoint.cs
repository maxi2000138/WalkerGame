using System;
using Cinemachine;
using Sirenix.OdinInspector;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private Config _config;
    [SerializeField] private CustomJoystick _joystick;
    [SerializeField] private ShootButton _shootButton;
    
    private Player _player;
    private Enemy _testEnemy;
    private PersistantProgressService _persistantProgressService;
    private PlayerInputRouter _playerInputRouter;
    private SaveLoadService _saveLoadService;
    private GameFactory _gameFactory;

    private const string PlayerSpawnPointTag = "PlayerSpawnPoint";
    private const string EnemySpawnPointTag = "EnemySpawnPoint";

    private void Awake()
    {
        InitServices();
        
        InitGameWorld();
        LoadProgressOrInitNew();
        InformProgressReaders();
        
        _player.Construct(_config);
        _testEnemy.Construct(_player, _config);
        _playerInputRouter = new PlayerInputRouter(_joystick, _player.PlayerMove, _player.PlayerGunRotater, _player.PlayerShoot, _shootButton);
    }

    private void InitGameWorld()
    {
        SpawnPlayer();
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        Transform enemySpawnPoint = GameObject.FindGameObjectWithTag(EnemySpawnPointTag).transform;
        _testEnemy = _gameFactory.CreateEnemy(enemySpawnPoint);
    }

    private void InformProgressReaders()
    {
        _gameFactory.ProgressReaders.ForEach(progressReader => 
            progressReader.LoadProgress(_persistantProgressService.PlayerProgress));
    }

    private void SpawnPlayer()
    {
        Transform PlayerSpawnPoint = GameObject.FindGameObjectWithTag(PlayerSpawnPointTag).transform;
        _player = _gameFactory.CreatePlayer(PlayerSpawnPoint);
        _camera.Follow = _player.transform;
    }

    private void InitServices()
    {
        _gameFactory = new GameFactory();
        _persistantProgressService = new PersistantProgressService();
        _saveLoadService = new SaveLoadService(_gameFactory, _persistantProgressService);
        _gameFactory.Cleanup();
    }

    private void LoadProgressOrInitNew()
    {
        _persistantProgressService.PlayerProgress = _saveLoadService.LoadProgress() ?? NewProgress();
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
}