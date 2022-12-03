using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class ViewSpace:IDisposable
    {
        float Speed;
        Rigidbody2D player;
        GameObject View;

        public ViewSpace(float speed)
        {
            player = ServiceLocator.Resolve<Player>().View.GetComponent<Rigidbody2D>();
            Speed = speed;
            View= UnityEngine.Object.Instantiate((GameObject)Resources.Load("ViewSpace"));
            EventSender.UpdateEvent += Update;
        }

        public void Dispose()
        {
            EventSender.UpdateEvent -= Update;
        }

        void Update()
        {
            View.transform.Rotate(Vector3.up,player.velocity.x * Speed);
            View.transform.Rotate(Vector3.right, -player.velocity.y * Speed);
        }
    }
}
