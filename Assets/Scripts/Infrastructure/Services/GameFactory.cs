using System.Collections.Generic;
using Data;
using Data.CustomStaticData;
using Data.TypeIds;
using GameOver;
using HP;
using Infrastructure.DI;
using Inventory.Model;
using Loot;
using Pathes;
using Player;
using Services;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Services
{
    public class GameFactory : IService
    {
        public List<ISavedProgress> ProgressWriters = new List<ISavedProgress>();
        public List<ISavedProgressReader> ProgressReaders = new List<ISavedProgressReader>();
        private Player.Player _player;
        private readonly ServiceLocator _serviceLocator;
        private readonly Transform _objectSpawnPoint;
        private Inventory.Model.Inventory _inventory;
        private PlayerHealth _playerHealth;

        public GameFactory(ServiceLocator serviceLocator, Transform objectSpawnPoint)
        {
            _serviceLocator = serviceLocator;
            _objectSpawnPoint = objectSpawnPoint;
        }

        public Player.Player SpawnPlayer(Transform spawnPoint, PlayerTypeId playerTypeId, BulletTypeId bulletTypeId, GameOverPopup gameOverPopup)
        {
            PlayerStaticData staticData = _serviceLocator.GetService<StaticDataService>().GetPlayer(playerTypeId);
            GameObject playerObj = Object.Instantiate(staticData.Prefab, spawnPoint.position,
                Quaternion.identity, _objectSpawnPoint);
        
            _playerHealth = playerObj.GetComponent<PlayerHealth>();
            _playerHealth.Current = staticData.HP;
            _playerHealth.Max = staticData.HP;
            playerObj.GetComponent<HealthUIChanger>().Construct(_playerHealth);
        
            _player = playerObj.GetComponent<Player.Player>();
            _player.Construct(staticData, _serviceLocator.GetService<StaticDataService>().GetBullet(bulletTypeId), gameOverPopup);
        
            RegisterProgressWatchers(playerObj);

            return _player;
        }
    
        public void SpawnEnemy(Vector2 spawnPosition, EnemyTypeId enemyTypeId)
        {
            EnemyStaticData enemyStaticData = _serviceLocator.GetService<StaticDataService>().GetMonster(enemyTypeId);
            GameObject enemyObj = Object.Instantiate(enemyStaticData.Prefab, spawnPosition,
                Quaternion.identity, _objectSpawnPoint);

            IHealth health = enemyObj.GetComponent<IHealth>();
            health.Current = enemyStaticData.HP;
            health.Max = enemyStaticData.HP;
            enemyObj.GetComponent<HealthUIChanger>().Construct(health);
        
            Enemy.Enemy enemy = enemyObj.GetComponent<Enemy.Enemy>();
            enemy.Construct(_player, enemyStaticData, this);
            RegisterProgressWatchers(enemyObj);
        }

        public void SpawnDataSaver()
        {
            DataSaver dataSaver = GameObject
                .Instantiate(Resources.Load(ResourcePathes.DataSaverPrefab), _objectSpawnPoint)
                .GetComponent<DataSaver>();
            
            dataSaver.Construct(_serviceLocator.GetService<SaveLoadService>(), _inventory, _player);
            
            dataSaver.gameObject.SetActive(true);
        }

        public Item CreateLootItem(LootTypeId typeId)
        {
            LootStaticData lootStaticData = _serviceLocator.GetService<StaticDataService>().GetLootItem(typeId);
            return new Item(lootStaticData.Icon, typeId);
        }

        public GameObject SpawnLootGameObject(LootTypeId typeId, Transform transform)
        {
            LootStaticData lootStaticData = _serviceLocator.GetService<StaticDataService>().GetLootItem(typeId);
            GameObject prefab = Resources.Load(ResourcePathes.LootPrefab) as GameObject;
            GameObject gameObject = Object.Instantiate(prefab, transform.position, Quaternion.identity, _objectSpawnPoint);
            LootObject lootObject = gameObject.GetComponent<LootObject>();
            lootObject.Construct(new Item(lootStaticData.Icon, typeId), _inventory);
            return gameObject;
        }

        public Inventory.Model.Inventory CreateInventory()
        {
            _inventory = new Inventory.Model.Inventory();
            Register(_inventory);
            return _inventory;
        }
    
        private void RegisterProgressWatchers(GameObject player)
        {
            foreach (ISavedProgressReader progressReader in player.GetComponentsInChildren<ISavedProgressReader>())
                Register(progressReader);
        }

        private void Register(ISavedProgressReader progressReader)
        {
            if(progressReader is ISavedProgress progressWriter)
                ProgressWriters.Add(progressWriter);
        
            ProgressReaders.Add(progressReader);
        }

        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }
    }
}
