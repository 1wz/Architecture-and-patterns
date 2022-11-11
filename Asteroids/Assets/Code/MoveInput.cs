using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal class MoveInput
    {
        private IMove _moveTransform;

        public MoveInput(IMove moveTransform)
        {
            _moveTransform = moveTransform;
            InputObserver.InputMove += Move;
        }

        public void Move(float Horizontal,float Vertical)
        {
            _moveTransform.Move(Horizontal, Vertical);
        }
    }
}