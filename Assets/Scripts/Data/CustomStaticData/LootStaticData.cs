using Data.TypeIds;
using UnityEngine;

namespace Data.CustomStaticData
{
    [CreateAssetMenu(fileName = "New Loot", menuName = "Static Data/Loot")]
    public class LootStaticData : ScriptableObject
    {
        public Sprite Icon;
        public string Name;

        public LootTypeId TypeId;
        public GameObject Prefab;
    }
}
