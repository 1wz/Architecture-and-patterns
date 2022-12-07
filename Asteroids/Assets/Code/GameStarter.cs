using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPool;

namespace Asteroids
{
    public class GameStarter : MonoBehaviour
    {
        GameObject eventSender;
        InputObserver inputObserver;
        RespawnEnemy respawnEnemy;
        [SerializeField] private Bullet _bullet;

        void Awake()
        {
            eventSender = Object.Instantiate((GameObject)Resources.Load("EventSender"));
            inputObserver = new InputObserver();
            ServiceLocator.SetService<ViewServices>(new ViewServices());
            ServiceLocator.SetService<Builder>(new Builder());
            respawnEnemy = new RespawnEnemy( 1, 100, 0.5f);
            ServiceLocator.SetService<Player>(new Player(4, 50, 5, _bullet, 1000));
            ViewSpace vievSpace = new ViewSpace(0.005f);
            ServiceLocator.SetService<CollisionService2D>(new CollisionService2D());
        }

    }
}