using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class RespawnEnemy
    {
        GameObject _prefab;
        float _time = 1;
        float _Speed = 5;
        float _Spread = 0.5f;
        SimpleTimer _simpleTimer;
        EnemyFactory _enemyFactory;
        public  RespawnEnemy(GameObject prefab,float time,float enemySpeed,float speedSpread)
        {
            _prefab = prefab;
            _time = time;
            _Speed = enemySpeed;
            _Spread = speedSpread>=0&&speedSpread<=1?speedSpread:0;
            _simpleTimer = new SimpleTimer();
            _enemyFactory = new EnemyFactory(_prefab);
            _simpleTimer.OnTimesUp += Respawn;
            _simpleTimer.Set(_time);
        }

        private void Respawn()
        {
            Vector2 direction = Random.insideUnitCircle.normalized;
            Vector2 position=(Vector2)Player.GetPlayer().transform.position+direction * LODmodule.minLODdist;
            Quaternion rotation = RotationShip.RotationToDir(-direction);
            GameObject enemy=_enemyFactory.CreateEnemy(position,rotation);
            Vector2 force = (-direction + Random.insideUnitCircle * _Spread)*_Speed;
            enemy.GetComponent<Rigidbody2D>().AddForce(force);
            _simpleTimer.Set(_time);
        }
    }
}