using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPool;
using System;

namespace Asteroids
{
    public  class EnemyFactory
    {
        private GameObject _prefab;
        public EnemyFactory(GameObject prefab)
        {
            _prefab = prefab;
        }
        public GameObject CreateEnemy(Vector2 position, Quaternion rotation)
        {

                var enemy = SingleViewServices.ViewServices.Instantiate<Transform>(_prefab);
                enemy.position = position;
                enemy.rotation = rotation;
                var irespawn = enemy.GetComponent<IRespawn>();
                    if(irespawn!=null)irespawn.Respawn();
                return enemy.gameObject;

        }
    }
}