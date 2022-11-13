using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class EventSender : MonoBehaviour
    {
        public static Action UpdateEvent;
        void Update()
        {
            UpdateEvent();
        }
    }
}