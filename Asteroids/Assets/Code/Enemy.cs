using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPool;

namespace Asteroids
{

    internal class Enemy :  IRespawn,IDamagebl
    {
        public const float _hp=1f;
        private HPModule _hpmolule;
        private LODmodule _LODmodule;
        public GameObject View { get; private set; } 
        public Enemy()
        {
            View= UnityEngine.Object.Instantiate((GameObject)Resources.Load("Enemy"));
            _hpmolule = new HPModule(_hp, Destroy);
            _LODmodule = new LODmodule(View.transform,Destroy);
            ServiceLocator.Resolve<CollisionService2D>().AddListener(this, View.GetComponent<Collider2D>(), null);
        }

        public void Respawn()
        {
            View.SetActive(true);
            _hpmolule.Reset();
            _LODmodule.On();
        }
        public void Destroy()
        {
            View.SetActive(false);
            _LODmodule.Off();
            ServiceLocator.Resolve<ViewServices>().Destroy(this);
        }

        public void Damage(float damage)
        {
            _hpmolule.Damage(damage);
        }
    }
}