using UnityEngine;

namespace Defender.Assets
{
    public class AssetsProvider : IAssetsProvider
    {
        public GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return UnityEngine.Object.Instantiate(prefab);
        }

        public GameObject Instantiate(string path, Vector2 point)
        {
            var prefab = Resources.Load<GameObject>(path);
            return UnityEngine.Object.Instantiate(prefab, point, Quaternion.identity);
        }
    }
}
