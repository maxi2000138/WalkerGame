using System.Collections.Generic;
using Data.CustomStaticData;
using Data.TypeIds;
using HP;
using Infrastructure.DI;
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

        public GameFactory(StaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public Player.Player CreatePlayer(Transform spawnPoint, PlayerTypeId playerTypeId, BulletTypeId bulletTypeId)
        {
            PlayerStaticData staticData = _staticDataService.GetPlayer(playerTypeId);
            GameObject playerObj = Object.Instantiate(staticData.Prefab, spawnPoint.position,
                Quaternion.identity);
        
            IHealth health = playerObj.GetComponent<IHealth>();
            health.Current = staticData.HP;
            health.Max = staticData.HP;
            playerObj.GetComponent<ActorUI>().Construct(health);
        
            _player = playerObj.GetComponent<Player.Player>();
            _player.Construct(staticData, _staticDataService.GetBullet(bulletTypeId));
        
            RegisterProgressWatchers(playerObj);

            return _player;
        }
    
        public Enemy.Enemy CreateEnemy(Transform spawnPoint, EnemyTypeId enemyTypeId)
        {
            EnemyStaticData enemyStaticData = _staticDataService.GetMonster(enemyTypeId);
            GameObject enemyObj = Object.Instantiate(enemyStaticData.Prefab, spawnPoint.position,
                Quaternion.identity);

            IHealth health = enemyObj.GetComponent<IHealth>();
            health.Current = enemyStaticData.HP;
            health.Max = enemyStaticData.HP;
            enemyObj.GetComponent<ActorUI>().Construct(health);
        
            Enemy.Enemy enemy = enemyObj.GetComponent<Enemy.Enemy>();
            enemy.Construct(_player, enemyStaticData);

            RegisterProgressWatchers(enemyObj);

            return enemy;
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
