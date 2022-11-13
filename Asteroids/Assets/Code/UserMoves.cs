using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal class UserMoves
    {
        public AccelerationMove _moveTransform;

        public UserMoves(Rigidbody2D rigidbody, float speed, float acceleration)
        {
            _moveTransform = new AccelerationMove(rigidbody,speed,acceleration);
            InputObserver.InputMove += Move;
            InputObserver.ShiftDown += AccelerationOn;
            InputObserver.ShiftUp += AccelerationOff;
        }

        public void Move(float Horizontal, float Vertical)
        {
            _moveTransform.Move(Horizontal, Vertical);
        }

        public void AccelerationOn()
        {
            _moveTransform.AddAcceleration();
        }

        public void AccelerationOff()
        {
            _moveTransform.RemoveAcceleration();
        }
    }
}