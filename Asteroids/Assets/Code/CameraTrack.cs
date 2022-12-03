using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class CameraTrack : MonoBehaviour
    {
        Transform player;
        void Start()
        {
            player = Player.GetPlayer().transform;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position=new Vector3(player.position.x, player.position.y, transform.position.z);
        }
    }
}