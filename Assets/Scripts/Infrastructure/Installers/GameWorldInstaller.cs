using Cinemachine;
using Data.TypeIds;
using Infrastructure.DI;
using Infrastructure.Services;
using Input;
using Inventory.View;
using Player;
using UI;
using UnityEngine;

namespace Infrastructure.Installers
{
    public class GameWorldInstaller : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _camera;
        [SerializeField] private CustomJoystick _joystick;
        [SerializeField] private ShootButton _shootButton;
        [SerializeField] private InventoryPresenter _inventoryPresenter;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private SaveArea _saveArea;
        [SerializeField] private GameOverPopup _gameOverPopup;

        private PlayerInputRouter _playerInputRouter;
        private Player.Player _player;
        private GameFactory _gameFactory;
        private SaveLoadService _saveLoadService;
        private const string PlayerSpawnPointTag = "PlayerSpawnPoint";

        public void Construct(GameFactory gameFactory, SaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
            _gameFactory = gameFactory;
        }

        private void OnEnable()
        {
            _playerInputRouter.OnEnable();
        }

        private void FixedUpdate()
        {
            _playerInputRouter.Update(Time.fixedDeltaTime);
        }
    
        private void OnDisable()
        {
            _playerInputRouter.OnDisable();
        }

        public void InitGameWorld()
        {
            CleanupProgressReadersWriters();
            SpawnPlayer();
            InitSpawner();
            InitSaveArea();
            InitInputRouter();
            CreateAndInitInventory();
        }

        private void CleanupProgressReadersWriters() => 
            _gameFactory.Cleanup();


        private void InitSaveArea() => 
            _saveArea.Construct(_saveLoadService);

        private void InitSpawner() => 
            _enemySpawner.Construct(_gameFactory);

        private void CreateAndInitInventory() => 
            _inventoryPresenter.Construct(_gameFactory.CreateInventory());

        private void InitInputRouter() => 
            _playerInputRouter = new PlayerInputRouter(_joystick, _player, _shootButton);

        private void SpawnPlayer()
        {
            Transform PlayerSpawnPoint = GameObject.FindGameObjectWithTag(PlayerSpawnPointTag).transform;
            _player = _gameFactory.CreatePlayer(PlayerSpawnPoint, PlayerTypeId.DefaultPlayer, BulletTypeId.DefaultBullet, _gameOverPopup);
            _camera.Follow = _player.transform;
        }
    }
}
