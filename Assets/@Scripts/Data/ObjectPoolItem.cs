using System;
using UnityEngine;

namespace Defender.Data
{
    [Serializable]
    public class ObjectPoolItem
    {
        public GameObject ObjectToPool;
        public int AmountToPool;
        public bool ShouldExpand;
    }
}
