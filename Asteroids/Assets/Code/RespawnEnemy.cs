using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class RespawnEnemy : MonoBehaviour
    {
        [SerializeField]
        GameObject prefab;
        [SerializeField]
        float time = 1;
        [SerializeField]
        float Speed = 5;
        [SerializeField]
        [Range(0, 1)]
        float Spread = 0.5f;
        SimpleTimer _simpleTimer;
        EnemyFactory _enemyFactory;
        void Start()
        {
            _simpleTimer = new SimpleTimer();
            _enemyFactory = new EnemyFactory(prefab);
            _simpleTimer.OnTimesUp += Respawn;
            _simpleTimer.Set(time);
        }

        private void Respawn()
        {
            Vector2 direction = Random.insideUnitCircle.normalized;
            Vector2 position=(Vector2)Player.GetPlayer().transform.position+direction * LODmodule.minLODdist;
            Quaternion rotation = RotationShip.RotationToDir(-direction);
            GameObject enemy=_enemyFactory.CreateEnemy(position,rotation);
            Vector2 force = (-direction + Random.insideUnitCircle * Spread)*Speed;
            enemy.GetComponent<Rigidbody2D>().AddForce(force);
            _simpleTimer.Set(time);
        }
    }
}