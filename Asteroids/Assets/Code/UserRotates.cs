using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal class UserRotates 
    {
        Camera _camera;
        Vector3 direction;
        public RotationShip _rotation;
        Transform _transform;

        public UserRotates(Camera camera, Transform transform)
        {
            _camera = camera;
            InputObserver.MouseMove += Look;
            _rotation=new RotationShip(transform);
            _transform = transform;
        }
        public void Look()
        {
            direction = Input.mousePosition - _camera.WorldToScreenPoint(_transform.position);
            _rotation.Rotation(direction);
        }
    }
}
