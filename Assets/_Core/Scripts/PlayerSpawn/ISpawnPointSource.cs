using UnityEngine;

namespace BhTest.PlayerSpawn
{
    public interface ISpawnPointSource
    {
        public Transform GetSpawnPoint();
    }
}