using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class InputShoot
    {

        Transform _barrel;
        float _force;
        Builder _builder;
        public InputShoot(Bullet bullet, Transform barrel, float force)
        {

            _barrel = barrel;
            _force = force;
            _builder = ServiceLocator.Resolve<Builder>();
        }

        public void Shoot()
        {
            var force = _barrel.up * _force;
             _builder.Build<Bullet>(_barrel.position, _barrel.rotation, force);

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