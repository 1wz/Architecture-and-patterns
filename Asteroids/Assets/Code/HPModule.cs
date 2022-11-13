using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class HPModule
    {
        public Action OnHealthIsOver;
        public float _hp { get; private set; }
        private CollisionObserver _collisionObserver;
        public HPModule(float HP,Collider2D colliderOfThisGamrObj)
        {
            _hp = HP;
            _collisionObserver = new CollisionObserver(colliderOfThisGamrObj);
            _collisionObserver.CollisionEvent += Damage;
        }

        public void Healing()
        {

        }

        public void Damage(List<Collider2D> colisionObj)
        {
            if (_hp <= 0)
            {
                OnHealthIsOver();
            }
            else
            {
                _hp--;
            }
        }
    }
}
