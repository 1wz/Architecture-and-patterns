using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{

    public class CollisionObserver : MonoBehaviour
    {
        public Action<List<Collider2D>> CollisionEvent;
        Collider2D _collider;
        public CollisionObserver(Collider2D collider)
        {
            _collider = collider;
            EventSender.UpdateEvent += OnCollision;
        }

        public void OnCollision()
        {
            if (_collider.IsTouchingLayers())
            {
                List<Collider2D> colliders = new List<Collider2D>();
                _collider.GetContacts(colliders);
                CollisionEvent(colliders);
            }
        }
    }
}
