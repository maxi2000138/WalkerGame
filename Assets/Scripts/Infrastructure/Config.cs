using UnityEngine;

[CreateAssetMenu(fileName = "New Config", menuName = "Configs/GameConfig")]
public class Config : ScriptableObject
{
    public float PlayerSpeed = 1f;
    public float BulletSpeed = 5f;
    public float EnemySpeed = 0.5f;
}
