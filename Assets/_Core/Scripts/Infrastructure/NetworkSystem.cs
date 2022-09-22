using BhTest.Player;
using Mirror;
using System.Collections.Generic;

namespace BhTest.Infrastructure
{
    public class NetworkSystem : NetworkManager
    {
        private PlayerSpawnSystem _spawn;
        private RoundsSystem _rounds;
        public List<PlayerFacade> Players { get; private set; } = new List<PlayerFacade>();

        public override void OnStartServer()
        {
            var systems = SystemsFacade.Instance;
            _spawn = systems.PlayerSpawn;
            _rounds = systems.Rounds;
            _rounds.GameStart += OnGameStartHandler;
        }

        private void OnGameStartHandler()
        {
            _spawn.RepopulateSpawnPoints();
            foreach (PlayerFacade player in Players)
            {
                var point = _spawn.GetSpawnPoint();
                player.transform.position = point.position;
                player.transform.rotation = point.rotation;
            }
        }

        public override void OnServerAddPlayer(NetworkConnectionToClient conn)
        {
            var startPos = _spawn.GetSpawnPoint();
            var player = Instantiate(playerPrefab, startPos.position, startPos.rotation);

            player.name = $"{playerPrefab.name} [connId={conn.connectionId}]";
            NetworkServer.AddPlayerForConnection(conn, player);

            Players.Add(player.GetComponent<PlayerFacade>());
        }

        public override void OnServerDisconnect(NetworkConnectionToClient conn)
        {
            Players.Remove(conn.identity.GetComponent<PlayerFacade>());
            base.OnServerDisconnect(conn);
        }
    }
}
