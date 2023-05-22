using System.Collections.Generic;
using System.Linq;
using Data.CustomStaticData;
using Data.TypeIds;
using Infrastructure.DI;
using Pathes;
using UnityEngine;

namespace Infrastructure.Services
{
    public class StaticDataService : IService
    {
        private Dictionary<EnemyTypeId,EnemyStaticData> _enemies;
        private Dictionary<PlayerTypeId,PlayerStaticData> _players;
        private Dictionary<BulletTypeId,BulletStaticData> _bullets;

        public void LoadStaticData()
        {
            _enemies = Resources
                .LoadAll<EnemyStaticData>(ResourcePathes.EnemyStaticData)
                .ToDictionary(x => x.TypeId, x => x);

            _players = Resources
                .LoadAll<PlayerStaticData>(ResourcePathes.PlayerStaticData)
                .ToDictionary(x => x.TypeId, x => x);
        
            _bullets = Resources
                .LoadAll<BulletStaticData>(ResourcePathes.BulletStaticData)
                .ToDictionary(x => x.TypeId, x => x);
        }

        public EnemyStaticData GetMonster(EnemyTypeId enemyTypeId) => 
            _enemies.TryGetValue(enemyTypeId, out EnemyStaticData staticData) 
                ? staticData 
                : null;
    
        public PlayerStaticData GetPlayer(PlayerTypeId playerTypeId) => 
            _players.TryGetValue(playerTypeId, out PlayerStaticData staticData) 
                ? staticData 
                : null;
    
        public BulletStaticData GetBullet(BulletTypeId bulletTypeId) => 
            _bullets.TryGetValue(bulletTypeId, out BulletStaticData staticData) 
                ? staticData 
                : null;
    }
}
