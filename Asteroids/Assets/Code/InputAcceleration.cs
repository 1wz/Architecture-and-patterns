using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal class InputAcceleration
    {
        AccelerationMove _accelerationMove;

        public InputAcceleration(AccelerationMove accelerationMove)
        {
            _accelerationMove = accelerationMove;
            InputObserver.ShiftDown += AccelerationOn;
            InputObserver.ShiftUp += AccelerationOff;
        }

        public void AccelerationOn()
        {
            _accelerationMove.AddAcceleration();
        }

        public void AccelerationOff()
        {
            _accelerationMove.RemoveAcceleration();
        }
    }
}