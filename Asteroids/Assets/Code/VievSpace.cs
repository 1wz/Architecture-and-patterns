using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class VievSpace : MonoBehaviour
    {
        [SerializeField]
        float Speed = 1f;
        Rigidbody2D player;

        private void Start()
        {
            player = Player.GetPlayer().GetComponent<Rigidbody2D>();
        }
        void Update()
        {
            transform.Rotate(Vector3.up,player.velocity.x * Speed);
            transform.Rotate(Vector3.right, -player.velocity.y * Speed);
        }
    }
}
