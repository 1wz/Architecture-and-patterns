using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPool;

namespace Asteroids
{    

    public class Bullet : IRespawn
    {

        private LODmodule _LODmodule;
        public GameObject View { get; private set; }
        public void Destroy()
        {
            View.SetActive(false);
            _LODmodule.Off();
            ServiceLocator.Resolve<ViewServices>().Destroy(this);
        }

        public void Respawn()
        {
            View.SetActive(true);
            _LODmodule.On();
        }

        public Bullet()
        {
            View= UnityEngine.Object.Instantiate((GameObject)Resources.Load("Bullet"));
            var _collider = View.GetComponent<Collider2D>();
            ServiceLocator.Resolve<CollisionService2D>().AddListener(this, _collider, AnyCollision);
            _LODmodule = new LODmodule(View.transform,Destroy);

        }

        private void AnyCollision(List<object> obj)
        {
            if (obj[0] is IDamagebl idamagebl) idamagebl.Damage(1);
            Destroy();
        }

    }
}