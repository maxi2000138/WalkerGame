using System.Collections.Generic;
using Data.CustomStaticData;
using Data.TypeIds;
using HP;
using Infrastructure.DI;
using Inventory.Model;
using Pathes;
using Services;
using UI;
using UnityEngine;

namespace Infrastructure.Services
{
    public class GameFactory : IService
    {
        public List<ISavedProgress> ProgressWriters = new List<ISavedProgress>();
        public List<ISavedProgressReader> ProgressReaders = new List<ISavedProgressReader>();
        private Player.Player _player;
        private StaticDataService _staticDataService;
        private Inventory.Model.Inventory _inventory;

        public GameFactory(StaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public Player.Player CreatePlayer(Transform spawnPoint, PlayerTypeId playerTypeId, BulletTypeId bulletTypeId, GameOverPopup gameOverPopup)
        {
            PlayerStaticData staticData = _staticDataService.GetPlayer(playerTypeId);
            GameObject playerObj = Object.Instantiate(staticData.Prefab, spawnPoint.position,
                Quaternion.identity);
        
            IHealth health = playerObj.GetComponent<IHealth>();
            health.Current = staticData.HP;
            health.Max = staticData.HP;
            playerObj.GetComponent<HealthUIChanger>().Construct(health);
        
            _player = playerObj.GetComponent<Player.Player>();
            _player.Construct(staticData, _staticDataService.GetBullet(bulletTypeId), gameOverPopup);
        
            RegisterProgressWatchers(playerObj);

            return _player;
        }
    
        public Enemy.Enemy CreateEnemy(Vector2 spawnPosition, EnemyTypeId enemyTypeId)
        {
            EnemyStaticData enemyStaticData = _staticDataService.GetMonster(enemyTypeId);
            GameObject enemyObj = Object.Instantiate(enemyStaticData.Prefab, spawnPosition,
                Quaternion.identity);

            IHealth health = enemyObj.GetComponent<IHealth>();
            health.Current = enemyStaticData.HP;
            health.Max = enemyStaticData.HP;
            enemyObj.GetComponent<HealthUIChanger>().Construct(health);
        
            Enemy.Enemy enemy = enemyObj.GetComponent<Enemy.Enemy>();
            enemy.Construct(_player, enemyStaticData, this);
            RegisterProgressWatchers(enemyObj);

            return enemy;
        }

        public Item CreateLootItem(LootTypeId typeId)
        {
            LootStaticData lootStaticData = _staticDataService.GetLootItem(typeId);
            return new Item(lootStaticData.Icon, typeId);
        }

        public GameObject CreateLootGameObject(LootTypeId typeId, Transform transform)
        {
            LootStaticData lootStaticData = _staticDataService.GetLootItem(typeId);
            GameObject prefab = Resources.Load(ResourcePathes.LootPrefab) as GameObject;
            GameObject gameObject = Object.Instantiate(prefab, transform.position, Quaternion.identity);
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
