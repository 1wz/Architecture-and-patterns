using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class InputShoot
    {

        Transform _barrel;
        float _force;
        EnemyFactory _enemyFactory;
        public InputShoot(Bullet bullet, Transform barrel, float force)
        {

            _barrel = barrel;
            _force = force;
            _enemyFactory = new EnemyFactory(bullet.gameObject);
        }

        public void Shoot()
        {
           var bullet= _enemyFactory.CreateEnemy(_barrel.position, _barrel.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(_barrel.up * _force,ForceMode2D.Impulse);
        }

        public void On()
        {
            InputObserver.Fire1 += Shoot;
        }
        public void Off()
        {
            InputObserver.Fire1 -= Shoot;
        }
    }
}