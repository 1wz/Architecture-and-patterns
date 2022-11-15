using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPool;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    internal class Enemy : MonoBehaviour, IRespawn
    {
        [SerializeField] private float _hp;
        private Collider2D _collider;
        private HPModule _hpmolule;
        private CollisionObserver _collisionObserver;
        private LODmodule _LODmodule;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();

            _collisionObserver = new CollisionObserver(_collider);
            _hpmolule = new HPModule(_hp, _collisionObserver);
            _hpmolule.OnHealthIsOver += Destroy;
            _LODmodule = new LODmodule(transform);
            _LODmodule.OnExitZone += Destroy;
        }

        public void Respawn()
        {
            _collisionObserver.On();
            _hpmolule.Reset();
            _LODmodule.On();
        }
        public void Destroy()
        {
            _collisionObserver.Off();
            SingleViewServices.ViewServices.Destroy(gameObject);
            _LODmodule.Off();
        }
    }
}