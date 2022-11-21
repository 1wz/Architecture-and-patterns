using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


namespace Asteroids
{
    public class InputObserver:IDisposable
    {
        public InputObserver()
        {
            EventSender.UpdateEvent += Update;
        }

        public static event Action<float, float> InputMove;
        public static event Action ShiftUp;
        public static event Action  ShiftDown;
        public static event Action  Fire1;
        public static event Action  MouseMove;

        public void Dispose()
        {
            EventSender.UpdateEvent -= Update;
        }

        private void Update()
        {
            if(Input.GetAxis("Horizontal")!=0||Input.GetAxis("Vertical") != 0)
            {
                InputMove?.Invoke(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                ShiftDown?.Invoke();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                ShiftUp?.Invoke();
            }
            if (Input.GetButtonDown("Fire1"))
            {
                Fire1?.Invoke();
            }
            if(Input.GetAxis("Mouse X")!=0||Input.GetAxis("Mouse Y") != 0)
            {
                MouseMove?.Invoke();
            }
        }
    }
}