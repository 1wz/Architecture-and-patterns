using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal class SimpleTimer
    {
        public Action OnTimesUp;
        public bool work { get; private set; }
        public float remainingTime { get; private set; }
        public SimpleTimer()
        {
            work = false;
        }

        public void Set(float time)
        {
            Stop();
            remainingTime = time;
            EventSender.UpdateEvent += Counting;
            work = true;
        }

        public void Stop()
        {
            if (work == true)
            {
                EventSender.UpdateEvent -= Counting;
                work = false;
            }
        }

        private void Counting()
        {
            remainingTime -= Time.deltaTime;
            if(remainingTime<=0)
            {
                Stop();
                OnTimesUp();
            }
        }
    }
}