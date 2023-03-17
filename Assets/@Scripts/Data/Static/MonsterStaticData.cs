using UnityEngine;

namespace Defender.Data.Static
{
    [CreateAssetMenu(fileName = "MonsterData", menuName = "StaticData/Monsters")]
    public class MonsterStaticData : ScriptableObject
    {
        public EnemyTypeId MonsterTypeId;

        [Range(0, 100)] public int Hp = 10;

        [Header("Attack Setting")]
        [Range(0.1f, 10f)] public float Speed = 3f;

        [Header("Loot Setting")]
        public int MinLoot;
        public int MaxLoot;

        public GameObject Prefab;
    }
}