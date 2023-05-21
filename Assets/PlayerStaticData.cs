using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Static Data/Player")]
public class PlayerStaticData : ScriptableObject
{
    public int HP;
    public float Speed = 1f;

    public PlayerTypeId TypeId;
    
    public GameObject Prefab;
}
