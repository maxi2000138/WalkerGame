using UnityEngine;

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
    
    public void Construct(PlayerStaticData playerStaticData, BulletStaticData bulletStaticData)
    {
        PlayerMove = GetComponent<PlayerMove>();
        PlayerShoot = GetComponent<PlayerShoot>();
        PlayerGunRotater = GetComponent<PlayerGunRotater>();
        PlayerHealth = GetComponent<PlayerHealth>();
        
        PlayerMove.Construct(playerStaticData.Speed);
        PlayerShoot.Construct(bulletStaticData);
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
