using System;

namespace BhTest.Player
{
    public interface IHitSource
    {
        public event Action GotHit;
    }
}