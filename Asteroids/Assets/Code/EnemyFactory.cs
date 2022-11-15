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
            try
            {

                var enemy = SingleViewServices.ViewServices.Instantiate<Transform>(_prefab);
                enemy.position = position;
                enemy.rotation = rotation;
                enemy.GetComponent<IRespawn>().Respawn();
                return enemy.gameObject;
            }
            catch(InvalidOperationException e)
            {
                throw new Exception("Only IRespawn objects can be created: "+e.Message);
            }
        }
    }
}