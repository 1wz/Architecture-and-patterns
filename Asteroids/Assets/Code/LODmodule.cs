using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{

    public class LODmodule
    {
        public const float minLODdist = 30;
        public const float maxLODdist = 40;

        public Action OnExitZone;

        private float _distance;
        Transform _transform;
        public LODmodule(Transform transform,Action onExitZone)
        {
            _transform = transform;
            OnExitZone += onExitZone;
        }
        public void CheckZone()
        {
            if (Vector2.Distance(Player.GetPlayer().transform.position, _transform.position) > maxLODdist)
                OnExitZone();
        }
        public void On()
        {
            EventSender.UpdateEvent += CheckZone;
        }
        public void Off()
        {
            EventSender.UpdateEvent -= CheckZone;
        }
    }
}