using UnityEngine;
namespace Asteroids
{
    internal class MoveTransform : IMove
    {
        private readonly Rigidbody2D _rigidbody;
        public float Speed { get; protected set; }
        public MoveTransform(Rigidbody2D rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            Speed = speed;
        }
        public void Move(float horizontal, float vertical)
        {
            var speed = Speed;
            _rigidbody.AddForce(new Vector2(horizontal * speed, vertical * speed));
        }
    }
}

