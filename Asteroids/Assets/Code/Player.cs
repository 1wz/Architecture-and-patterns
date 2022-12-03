using System;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroids
{
    internal sealed class Player :IDamagebl
    {
        private float _speed;
        private float _acceleration;
        private float _hp;
        private Bullet _bullet;
        private Transform _barrel;
        private float _force;
        private Camera _camera;
        private Rigidbody2D _rigidbody;
        private InputShoot _inputShootModule;
        private UserMoves _inputMovesModele;
        private UserRotates _inputRotatesModule;
        private HPModule _hpmolule;
        public GameObject View { get; private set; }

        public Player(float speed, float acceleration,float hp,Bullet bullet, float force)
        {
            _speed = speed;
            _acceleration = acceleration;
            _hp = hp;
            _bullet = bullet;
            _force = force;

            View= UnityEngine.Object.Instantiate((GameObject)Resources.Load("Player"));

            _camera = Camera.main;
            _rigidbody = View.GetComponent<Rigidbody2D>();
            _barrel = View.transform.GetChild(0);
            _inputRotatesModule = new UserRotates(_camera, View.transform);
            _inputMovesModele = new UserMoves(_rigidbody, _speed, _acceleration);
            _inputShootModule = new InputShoot(_bullet, _barrel,_force);
            _hpmolule = new HPModule(_hp, null);


            Respawn();
        }

        public void Respawn()
        {
            View.SetActive(true);
            _inputRotatesModule.On();
            _inputMovesModele.On();
            _inputShootModule.On();
            _hpmolule.Reset();
        }
        public void Destroy()
        {
            View.SetActive(false);
            _inputRotatesModule.Off();
            _inputMovesModele.Off();
            _inputShootModule.Off();
        }

        public void Damage(float damage)
        {
            _hpmolule.Damage(damage);
        }
    }
}
