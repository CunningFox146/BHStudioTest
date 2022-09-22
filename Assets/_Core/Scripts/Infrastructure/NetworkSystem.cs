using BhTest.Player;
using BhTest.PlayerSpawn;
using kcp2k;
using Mirror;
using System.Collections.Generic;

namespace BhTest.Infrastructure
{
    public class NetworkSystem : NetworkManager
    {
        private ISpawnPointSource _spawn;
        private RoundsSystem _rounds;
        public List<PlayerFacade> Players { get; private set; } = new List<PlayerFacade>();

        public override void Start()
        {
            base.Start();

            if (NetworkClient.isConnected || NetworkClient.isConnecting) return;

            ApplyConnectionSettings();

            if (SaveSystem.IsHosting)
            {
                StartHost();
            }
            else
            {
                StartClient();
            }
        }

        public override void OnStartServer()
        {
            var systems = SystemsFacade.Instance;
            _spawn = systems.PlayerSpawn;
            _rounds = systems.Rounds;
            RegisterEventhandlers();
        }

        public override void OnStopServer()
        {
            UnregisterEventHandlers();
        }

        public override void OnClientConnect()
        {
            if (!clientLoadedScene)
            {
                if (!NetworkClient.ready)
                    NetworkClient.Ready();

                if (autoCreatePlayer && !NetworkClient.connection.identity)
                    NetworkClient.AddPlayer();
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

        private void ApplyConnectionSettings()
        {
            networkAddress = SaveSystem.ServerIp;
            if (ushort.TryParse(SaveSystem.ServerPort, out ushort port))
            {
                ((KcpTransport)transport).Port = port;
            }
        }

        private void RegisterEventhandlers()
        {
            _rounds.GameStart += OnGameStartHandler;
        }

        private void UnregisterEventHandlers()
        {
            _rounds.GameStart -= OnGameStartHandler;
        }

        private void OnGameStartHandler()
        {
            foreach (PlayerFacade player in Players)
            {
                var point = _spawn.GetSpawnPoint();
                player.Movement.IsMoving = false;
                player.transform.position = point.position;
                player.transform.rotation = point.rotation;
            }
        }
    }
}
