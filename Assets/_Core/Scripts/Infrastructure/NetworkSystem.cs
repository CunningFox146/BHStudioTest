using BhTest.Player;
using kcp2k;
using Mirror;
using System.Collections.Generic;
using UnityEngine;

namespace BhTest.Infrastructure
{
    public class NetworkSystem : NetworkManager
    {
        private PlayerSpawnSystem _spawn;
        private RoundsSystem _rounds;
        public List<PlayerFacade> Players { get; private set; } = new List<PlayerFacade>();

        public override void Start()
        {
            base.Start();

            if (NetworkClient.isConnected || NetworkClient.isConnecting) return;

            networkAddress = SaveSystem.ServerIp;
            ((KcpTransport)transport).Port = ushort.Parse(SaveSystem.ServerPort);
            if (SaveSystem.IsHosting)
            {
                StartHost();
            }
            else
            {
                StartClient();
            }
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

        public override void OnStartServer()
        {
            var systems = SystemsFacade.Instance;
            _spawn = systems.PlayerSpawn;
            _rounds = systems.Rounds;
            _rounds.GameStart += OnGameStartHandler;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            foreach (PlayerFacade player in Players)
            {
                Destroy(player.gameObject);
            }
            Players.Clear();
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
