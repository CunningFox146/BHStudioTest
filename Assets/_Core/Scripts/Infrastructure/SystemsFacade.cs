using BhTest.PlayerSpawn;
using BhTest.UI.Gameplay;
using UnityEngine;

namespace BhTest.Infrastructure
{
    public class SystemsFacade : MonoBehaviour
    {
        public static SystemsFacade Instance { get; private set; }

        [field: SerializeField] public PlayerRandomSpawnSystem PlayerSpawn { get; private set; }
        [field: SerializeField] public ScoreSystem Score { get; private set; }
        [field: SerializeField] public HUD Hud { get; private set; }
        [field: SerializeField] public RoundsSystem Rounds { get; private set; }

        private void Awake()
        {
            Instance = this;
        }
    }
}
