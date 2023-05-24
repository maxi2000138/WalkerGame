using Data.CustomStaticData;
using Data.DataStructures;
using Data.Extensions;
using GameOver;
using Services;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerMove))]
    [RequireComponent(typeof(PlayerGunRotater))]
    [RequireComponent(typeof(PlayerShoot))]
    [RequireComponent(typeof(PlayerHealth))]
    public class Player : MonoBehaviour, ISavedProgress
    {
        public PlayerMove PlayerMove { get; private set; }
        public PlayerShoot PlayerShoot { get; private set; }
        public PlayerGunRotater PlayerGunRotater { get; private set; }
        public PlayerHealth PlayerHealth { get; private set; }
        public PlayerDeath PlayerDeath { get; private set; }
        public PlayerAimRangeDrawer PlayerAimRangeDrawer{get; private set; }
    
        public void Construct(PlayerStaticData playerStaticData, BulletStaticData bulletStaticData, GameOverPopup gameOverPopup)
        {
            PlayerMove = GetComponent<PlayerMove>();
            PlayerShoot = GetComponent<PlayerShoot>();
            PlayerGunRotater = GetComponent<PlayerGunRotater>();
            PlayerHealth = GetComponent<PlayerHealth>();
            PlayerAimRangeDrawer = GetComponentInChildren<PlayerAimRangeDrawer>();
            PlayerDeath = GetComponent<PlayerDeath>();
        
            PlayerDeath.Construct(gameOverPopup);
            PlayerMove.Construct(playerStaticData.Speed);
            PlayerShoot.Construct(bulletStaticData);
            PlayerGunRotater.Construct(playerStaticData.AutoAimDistance);
            PlayerAimRangeDrawer.Construct(playerStaticData.AutoAimDistance);
        }
    
        public void LoadProgress(PlayerProgress playerProgress)
        {
            Vector3Data dataPosition = playerProgress.WorldData.Position;
            if(dataPosition != null)
                transform.position = dataPosition.AsUnityVector();
        }

        public void UpdateProgress(PlayerProgress playerProgress)
        {
            if(transform != null && playerProgress != null)
                playerProgress.WorldData.Position = transform.position.AsVector3Data();
        }
    }
}
