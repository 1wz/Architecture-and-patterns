using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


namespace Asteroids
{
    public class InputObserver: MonoBehaviour
    {
        public static Action<float, float> InputMove;
        public static Action ShiftUp;
        public static Action ShiftDown;
        public static Action Fire1;
        public static Action MouseMove;
        private void Update()
        {
            if(Input.GetAxis("Horizontal")!=0||Input.GetAxis("Vertical") != 0)
            {
                InputMove(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                ShiftDown();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                ShiftUp();
            }
            if (Input.GetButtonDown("Fire1"))
            {
                Fire1();
            }
            if(Input.GetAxis("Mouse X")!=0||Input.GetAxis("Mouse Y") != 0)
            {
                MouseMove();
            }
        }
    }
}