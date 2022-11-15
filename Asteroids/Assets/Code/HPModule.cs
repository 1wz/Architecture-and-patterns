using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class HPModule
    {
        public Action OnHealthIsOver;
        public float max_hp;
        public float _hp { get; private set; }
        private CollisionObserver _collisionObserver;
        public HPModule(float HP,CollisionObserver collisionObserver)
        {
            max_hp = HP;
            _hp = max_hp;
            _collisionObserver = collisionObserver;
            _collisionObserver.CollisionEvent += Damage;
            
        }

        public void  Reset()
        {
            _hp = max_hp;
        }

        public void Damage(List<Collider2D> colisionObj)
        {
            if (_hp <= 0)
            {
                OnHealthIsOver?.Invoke();
            }
            else
            {
                _hp--;
            }
        }

    }
}
