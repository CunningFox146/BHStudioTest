using System;
using UnityEngine;

namespace BhTest.Collision
{
    public interface ICollisionSource
    {
        public event Action<GameObject> CollisionHit;
    }
}
