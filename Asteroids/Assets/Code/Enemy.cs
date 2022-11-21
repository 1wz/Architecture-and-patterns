using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPool;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    internal class Enemy : MonoBehaviour, IRespawn,IDamagebl
    {
        [SerializeField] private float _hp;
        private HPModule _hpmolule;
        private LODmodule _LODmodule;

        private void Awake()
        {

            _hpmolule = new HPModule(_hp, Destroy);
            _LODmodule = new LODmodule(transform,Destroy);
        }

        public void Respawn()
        {
            _hpmolule.Reset();
            _LODmodule.On();
        }
        public void Destroy()
        {
            _LODmodule.Off();
            SingleViewServices.ViewServices.Destroy(gameObject);
        }

        public void Damage(float damage)
        {
            _hpmolule.Damage(damage);
        }
    }
}