using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPool;

namespace Asteroids
{
    public interface IMove
    {
        float Speed { get; }
        void Move(float horizontal, float vertical);
    }
    public interface IRotation
    {
        void Rotation(Vector3 direction);
    }
    internal interface IRespawn
    {
        void Respawn();
        void Destroy();
        GameObject View { get; }
    }

    public interface IDamagebl
    {
        void Damage(float damage);
    }
}

