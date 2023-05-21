using UnityEngine;

[CreateAssetMenu(fileName = "BulletData", menuName = "Static Data/Bullet")]
public class BulletStaticData : ScriptableObject
{
    [Range(1,20)]
    public float FlyTime;
    [Range(1,50)]
    public float Damage;
    [Range(1,50)]
    public float Speed;

    public BulletTypeId TypeId;
}
