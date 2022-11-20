using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPool;

namespace Asteroids
{    
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class Bullet : MonoBehaviour,IRespawn
    {
        private Collider2D _collider;
        private CollisionObserver _collisionObserver;
        private LODmodule _LODmodule;

        public void Destroy()
        {
            _collisionObserver.Off();
            _LODmodule.Off();
            SingleViewServices.ViewServices.Destroy(gameObject);
        }

        public void Respawn()
        {
            _collisionObserver.On();
            _LODmodule.On();
        }

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _collisionObserver = new CollisionObserver(_collider,AnyCollision);
            _LODmodule = new LODmodule(transform,Destroy);

        }

        private void AnyCollision(List<Collider2D> obj)
        {
            IDamagebl iDamagebl = obj[0].gameObject.GetComponent<IDamagebl>();
            if (iDamagebl!=null) iDamagebl.Damage(1);
            Destroy();
        }
    }
}