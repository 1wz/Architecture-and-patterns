using UnityEngine;
namespace Asteroids
{
    internal sealed class RotationShip : IRotation
    {
        private readonly Transform _transform;
        public RotationShip(Transform transform)
        {
            _transform = transform;
        }
        public void Rotation(Vector3 direction)
        {
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _transform.transform.rotation = Quaternion.AngleAxis(angle-90f,
            Vector3.forward);
        }

        public static Quaternion RotationToDir(Vector3 direction)
        {
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            return Quaternion.AngleAxis(angle - 90f,
            Vector3.forward);
        }
    }
}
