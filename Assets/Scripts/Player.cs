using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
[RequireComponent(typeof(PlayerGunRotater))]
[RequireComponent(typeof(PlayerShoot))]
public class Player : MonoBehaviour, ISavedProgress
{
    public PlayerMove PlayerMove { get; private set; }
    public PlayerShoot PlayerShoot { get; private set; }
    public PlayerGunRotater PlayerGunRotater { get; private set; }
    public PlayerAttack PlayerAttack { get; private set;  }
    
    public void Construct(Config config)
    {
        PlayerMove = GetComponent<PlayerMove>();
        PlayerShoot = GetComponent<PlayerShoot>();
        PlayerGunRotater = GetComponent<PlayerGunRotater>();
        PlayerAttack = GetComponent<PlayerAttack>();
        
        PlayerMove.Construct(config);
        PlayerShoot.Construct(config);
    }
    
    public void LoadProgress(PlayerProgress playerProgress)
    {
        Vector3Data dataPosition = playerProgress.WorldData.Position;
        if(dataPosition != null)
                transform.position = dataPosition.AsUnityVector();
    }

    public void UpdateProgress(PlayerProgress playerProgress)
    {
        playerProgress.WorldData.Position = transform.position.AsVector3Data();
    }
}
