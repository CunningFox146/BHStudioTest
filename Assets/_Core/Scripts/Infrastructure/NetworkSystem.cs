using BhTest.Player;
using BhTest.PlayerSpawn;
using kcp2k;
using Mirror;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BhTest.Infrastructure
{
    public class NetworkSystem : NetworkManager
    {
        public static string NetworkError { get; private set; }

        private ISpawnPointSource _spawn;
        private RoundsSystem _rounds;
        public List<PlayerFacade> Players { get; private set; } = new List<PlayerFacade>();

        public override void Start()
        {
            base.Start();

            if (NetworkClient.isConnected || NetworkClient.isConnecting) return;

            ApplyConnectionSettings();

            if (PersistentData.IsHosting)
            {
                try
                {
                    StartHost();
                }
                catch (Exception ex)
                {
                    Debug.LogException(ex);
                    NetworkError = ex.Message;
                    SceneSystem.LoadLobby();
                }
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

        public override void OnStopClient()
        {
            NetworkError = (!NetworkClient.isHostClient && NetworkClient.isConnecting) ? "Failed to connect to the server." : null;
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
            networkAddress = PersistentData.ServerIp;
            if (ushort.TryParse(PersistentData.ServerPort, out ushort port))
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
