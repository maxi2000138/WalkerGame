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

        private PlayerInputRouter _playerInputRouter;
        private Player.Player _player;
        private GameFactory _gameFactory;
        private const string PlayerSpawnPointTag = "PlayerSpawnPoint";
        private const string EnemySpawnPointTag = "EnemySpawnPoint";


        public void Construct(GameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        private void OnEnable()
        {
            _playerInputRouter.OnEnable();
        }

        private void FixedUpdate()
        {
            _playerInputRouter.Update(Time.deltaTime);
        }
    
        private void OnDisable()
        {
            _playerInputRouter.OnDisable();
        }

        public void InitGameWorld()
        {
            _gameFactory.Cleanup();
            SpawnPlayer();
            InitSpawner();
            //SpawnZombie();
            _saveArea.Construct(ServiceLocator.Container.GetService<SaveLoadService>()); //Delete or переделать!
            InitInputRouter();
            CreateAndInitInventory();
        }

        private void InitSpawner()
        {
            _enemySpawner.Construct(_gameFactory);
        }

        private void CreateAndInitInventory() => 
            _inventoryPresenter.Construct(_gameFactory.CreateInventory());

        private void SpawnZombie()
        {
            Transform enemySpawnPoint = GameObject.FindGameObjectWithTag(EnemySpawnPointTag).transform;
            _gameFactory.CreateEnemy(enemySpawnPoint.position, EnemyTypeId.zombie);
        }

        private void SpawnPlayer()
        {
            Transform PlayerSpawnPoint = GameObject.FindGameObjectWithTag(PlayerSpawnPointTag).transform;
            _player = _gameFactory.CreatePlayer(PlayerSpawnPoint, PlayerTypeId.DefaultPlayer, BulletTypeId.DefaultBullet);
            _camera.Follow = _player.transform;
        }

        private void InitInputRouter()
        {
            _playerInputRouter = new PlayerInputRouter(_joystick, _player.PlayerMove, _player.PlayerGunRotater,
                _player.PlayerShoot, _shootButton);
        }
    }
}
