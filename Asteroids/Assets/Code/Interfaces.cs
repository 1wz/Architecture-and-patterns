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
    }

    public interface IDamagebl
    {
        void Damage(float damage);
    }
}

namespace ObjectPool
{
    public interface IViewServices
    {
        T Instantiate<T>(GameObject prefab);
        void Destroy(GameObject value);
    }
}
