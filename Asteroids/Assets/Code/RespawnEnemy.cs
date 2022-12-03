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
        Builder _enemyBuilder;
        public  RespawnEnemy(float time,float enemySpeed,float speedSpread)
        {
            _time = time;
            _Speed = enemySpeed;
            _Spread = speedSpread>=0&&speedSpread<=1?speedSpread:0;
            _simpleTimer = new SimpleTimer();
            _enemyBuilder = ServiceLocator.Resolve<Builder>();
            _simpleTimer.OnTimesUp += Respawn;
            _simpleTimer.Set(_time);
        }

        private void Respawn()
        {
            Vector2 direction = Random.insideUnitCircle.normalized;
            Vector2 position=(Vector2)ServiceLocator.Resolve<Player>().View.transform.position+direction * LODmodule.minLODdist;
            Quaternion rotation = RotationShip.RotationToDir(-direction);
            Vector2 force = (-direction + Random.insideUnitCircle * _Spread)*_Speed;
            _enemyBuilder.Build<Enemy>(position,rotation,force);
            _simpleTimer.Set(_time);
        }
    }
}