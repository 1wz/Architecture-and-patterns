using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class GameStarter : MonoBehaviour//nowork
    {
        Player player;
        EventSender eventSender;
        void Start()
        {
            player=(Player)Resources.Load("Player"); EventSender
            eventSender = (EventSender)Resources.Load("EventSender");
        }

    }
}