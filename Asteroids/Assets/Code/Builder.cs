using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPool;
using System;

namespace Asteroids
{
    internal class Builder
    {

        public T Build<T>(Vector2 position, Quaternion rotation, Vector2 forse) where T: IRespawn,new()
        {

            var newObj = ServiceLocator.Resolve<ViewServices>().Instantiate<T>();
            newObj.Respawn();
            newObj.View.transform.position = position;
            newObj.View.transform.rotation = rotation;
            newObj.View.GetComponent<Rigidbody2D>().AddForce(forse);
            return newObj;
        }

    }
}