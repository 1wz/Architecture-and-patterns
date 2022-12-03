using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class GameStarter : MonoBehaviour
    {
        GameObject player;
        GameObject eventSender;
        InputObserver inputObserver;
        RespawnEnemy respawnEnemy;
        void Start()
        {
            player= Object.Instantiate((GameObject)Resources.Load("Player")); 
            eventSender = Object.Instantiate((GameObject)Resources.Load("EventSender"));
            inputObserver = new InputObserver();
            respawnEnemy = new RespawnEnemy((GameObject)Resources.Load("Enemy"), 1, 100, 0.5f);
            ViewSpace vievSpace = new ViewSpace(0.005f);
        }

    }
}