using System.Collections.Generic;
using Defender.Data;
using UnityEngine;

namespace Defender.Utility
{

    public class ObjectPooler : MonoBehaviour
    {
        public static ObjectPooler SharedInstance;
        public List<ObjectPoolItem> ItemsToPool;
        public List<GameObject> PooledObjects;

        void Awake()
        {
            SharedInstance = this;
        }

        void Start()
        {
            PooledObjects = new List<GameObject>();

            foreach (ObjectPoolItem item in ItemsToPool)
            {
                for (int i = 0; i < item.AmountToPool; i++)
                {
                    GameObject obj = (GameObject)Instantiate(item.ObjectToPool, transform);
                    obj.SetActive(false);
                    PooledObjects.Add(obj);
                }
            }
        }

        // в параметры можно кинуть на проверку нужного на типа
        public GameObject GetPooledObject()
        {
            for (int i = 0; i < PooledObjects.Count; i++)
            {
                if (!PooledObjects[i].activeInHierarchy)
                {
                    return PooledObjects[i];
                }
            }
            foreach (ObjectPoolItem item in ItemsToPool)
            {
                if (item.ObjectToPool.TryGetComponent(out IAmmo ammo))
                {
                    if (item.ShouldExpand)
                    {
                        GameObject obj = (GameObject)Instantiate(item.ObjectToPool, transform);
                        obj.SetActive(false);
                        PooledObjects.Add(obj);
                        return obj;
                    }
                }
            }
            return null;
        }
    }
}
