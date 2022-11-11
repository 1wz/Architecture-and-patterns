using UnityEngine;
namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;
        private Camera _camera;
        private AccelerationMove _moveTransform;
        private IRotation _rotation;
        private Rigidbody2D _rigidbody;
        private LookMouse _lookMouse;
        private MoveInput _moveInput;
        private InputAcceleration _inputAcceleration;
        private InputShoot _inputShoot;
        private void Start()
        {
            _camera = Camera.main;
            _rigidbody = GetComponent<Rigidbody2D>();

            _moveTransform = new AccelerationMove(_rigidbody, _speed, _acceleration);
            _rotation = new RotationToDir(transform);

            _lookMouse = new LookMouse(_camera, transform, _rotation);
            _moveInput = new MoveInput(_moveTransform);
            _inputAcceleration = new InputAcceleration(_moveTransform);
            _inputShoot = new InputShoot(_bullet, _barrel,_force);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _hp--;
            }
        }
    }
}
