using UnityEngine;

[CreateAssetMenu(fileName = "New Config", menuName = "Configs/GameConfig")]
public class Config : ScriptableObject
{
    public float PlayerSpeed = 1f;
    public float BulletSpeed = 5f;
    public float EnemySpeed = 0.5f;
    public float PlayerDamage = 1f;
    public float EnemyDamage = 1f;
    public float EnemyAttackDelay = 1f;
    public float BulletFlyTime = 10f;
}

