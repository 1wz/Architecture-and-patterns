using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class CollisionService2D
    {
        List<ColliderModelConnection2D> listOfColliders = new List<ColliderModelConnection2D>();

        public CollisionService2D()
        {
            EventSender.UpdateEvent += CollisionCheck;
        }
        public void AddListener(object model, Collider2D collider, Action<List<object>> onCollision)
        {
            listOfColliders.Add(new ColliderModelConnection2D(model, collider, onCollision));
        }
        private void CollisionCheck()
        {
            Dictionary<List<object>, Action<List<object>>> CallList = new Dictionary<List<object>, Action<List<object>>>();

            foreach (var collider in listOfColliders)
            {
                if (collider._onCollision!=null&&collider._collider.IsTouchingLayers())
                {
                    List<Collider2D> colliders = new List<Collider2D>();
                    collider._collider.GetContacts(colliders);

                    var models = SearchAllModels(colliders);
                    CallList.Add(models, collider._onCollision);
                }
            }

            foreach (var call in CallList)
            {
                call.Value?.Invoke(call.Key);
            }
        }

        private List<object> SearchAllModels(List<Collider2D> colliders)
        {
            List<object> result = new List<object>();
            for (int k = 0; k < colliders.Count; k++)
            {
                for (int i = 0; i < listOfColliders.Count; i++)
                {
                    if (colliders[k] == listOfColliders[i]._collider)
                    {
                        result.Add(listOfColliders[i]._model);
                    }
                }
            }

            return result;
        }
    }


    public class ColliderModelConnection2D
    {
        public object _model { get; private set; }
        public Collider2D _collider { get; private set; }
        public Action<List<object>> _onCollision { get; private set; }
        public ColliderModelConnection2D(object model, Collider2D collider, Action<List<object>> onCollision)
        {
            _model = model;
            _collider = collider;
            _onCollision = onCollision;
        }
    }
}
