using System;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    internal sealed class Player : MonoBehaviour,IDamagebl
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;
        private Camera _camera;
        private Rigidbody2D _rigidbody;
        private InputShoot _inputShoot;
        private UserMoves _userMoves;
        private UserRotates _userRotates;
        private HPModule _hpmolule;


        public static Func<Player> GetPlayer { get; private set; }
        private void Awake()
        {
            if (GetPlayer != null)
            {
                throw new Exception("There is more than one player on stage!");
            }
            else
            {
                GetPlayer += GetThis;
            }

            _camera = Camera.main;
            _rigidbody = GetComponent<Rigidbody2D>();

            _userRotates = new UserRotates(_camera, transform);
            _userMoves = new UserMoves(_rigidbody, _speed, _acceleration);
            _inputShoot = new InputShoot(_bullet, _barrel,_force);
            _hpmolule = new HPModule(_hp, null);


            Respawn();
        }

        public Player GetThis()
        {
            return this;
        }
        public void Respawn()
        {
            _userRotates.On();
            _userMoves.On();
            _inputShoot.On();
            _hpmolule.Reset();
        }
        public void Destroy()
        {
            _userRotates.Off();
            _userMoves.Off();
            _inputShoot.Off();
        }

        public void Damage(float damage)
        {
            _hpmolule.Damage(damage);
        }
    }
}
