using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal class LookMouse
    {
        Camera _camera;
        Transform _transform;
        IRotation _rotation;
        Vector3 direction;

        public LookMouse(Camera camera, Transform transform, IRotation rotation)
        {
            _camera = camera;
            _transform = transform;
            _rotation = rotation;
            InputObserver.MouseMove += Look;

        }
    public void Look()
        {
            direction = Input.mousePosition -_camera.WorldToScreenPoint(_transform.position);
            _rotation.Rotation(direction);
        }

    }

}
