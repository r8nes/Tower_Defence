using UnityEngine;

namespace Defender.Entity
{
    public class Ammo : MonoBehaviour, IAmmo
    {
        private Rigidbody2D objectRigidbody;
        public float speed;

        void OnEnable()
        {
            objectRigidbody = transform.GetComponent<Rigidbody2D>();
            objectRigidbody.velocity = transform.up * speed;
        }
    }
}
