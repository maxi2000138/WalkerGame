using UnityEngine;
using UnityEngine.SocialPlatforms;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Static Data/Enemy")]
public class EnemyStaticData : ScriptableObject
{
    [Range(1,100)]
    public int HP;
    [Range(1,100)]
    public int Damage;
    [Range(1,100)]
    public float Speed;
    [Range(0.1f, 10f)]
    public float AttackDelay;

    public EnemyTypeId TypeId;
    
    public GameObject Prefab;
    
}