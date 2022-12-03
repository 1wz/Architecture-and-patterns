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

        public HPModule(float HP,Action onHealthIsOver)
        {
            max_hp = HP;
            _hp = max_hp;
            OnHealthIsOver += onHealthIsOver;
        }

        public void  Reset()
        {
            _hp = max_hp;
        }

        public void Damage(float damage)
        {
            _hp -= damage;
            if (_hp <= 0)
            {
                OnHealthIsOver?.Invoke();
            }
        }

    }
}
