using Data.TypeIds;
using UnityEngine;

namespace Data.CustomStaticData
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Static Data/Player")]
    public class PlayerStaticData : ScriptableObject
    {
        public int HP;
        public float Speed = 1f;
        public float AutoAimDistance = 5f;

        public PlayerTypeId TypeId;
    
        public GameObject Prefab;
    }
}
