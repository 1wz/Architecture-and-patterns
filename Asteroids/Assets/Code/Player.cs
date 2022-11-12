using UnityEngine;
namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;
        private Camera _camera;
        private Rigidbody2D _rigidbody;
        private InputShoot _inputShoot;
        private UserMoves _userMoves;
        private UserRotates _userRotates;
        private Collider2D _collider;
        private HPModule _hpmolule;

        private void Start()
        {
            _camera = Camera.main;
            _rigidbody = GetComponent<Rigidbody2D>();
            _collider = GetComponent<Collider2D>();

            _userRotates = new UserRotates(_camera, transform);
            _userMoves = new UserMoves(_rigidbody, _speed, _acceleration);
            _inputShoot = new InputShoot(_bullet, _barrel,_force);
            _hpmolule = new HPModule(_hp, _collider);
        }

    }
}
