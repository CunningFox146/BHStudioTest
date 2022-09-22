using System.Collections.Generic;
using UnityEngine;

namespace BhTest.PlayerSpawn
{
    public class PlayerRandomSpawnSystem : MonoBehaviour, ISpawnPointSource
    {
        [SerializeField] private Transform[] _spawnPoints;

        private List<Transform> _avaliableSpawnPoints = new List<Transform>();

        private void Awake()
        {
            RepopulateSpawnPoints();
        }

        public Transform GetSpawnPoint()
        {
            int idx = Random.Range(0, _avaliableSpawnPoints.Count - 1);

            var point = _avaliableSpawnPoints[idx];
            _avaliableSpawnPoints.RemoveAt(idx);
            if (_avaliableSpawnPoints.Count == 0)
            {
                RepopulateSpawnPoints();
            }

            return point;
        }

        public void RepopulateSpawnPoints()
        {
            _avaliableSpawnPoints.AddRange(_spawnPoints);
        }
    }
}
