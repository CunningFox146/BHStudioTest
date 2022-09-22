using BhTest.Infrastructure;
using BhTest.Player;
using TMPro;
using UnityEngine;

namespace BhTest.UI.Gameplay
{
    [RequireComponent(typeof(Canvas))]
    public class HUD : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _winText;

        private PlayerFacade _player;
        private Canvas _canvas;
        private ScoreSystem _score;
        private RoundsSystem _rounds;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
        }

        private void Start()
        {
            var systems = SystemsFacade.Instance;
            _score = systems.Score;
            _rounds = systems.Rounds;

            RegisterEventHandlers();
        }

        private void OnEnable()
        {
            RegisterEventHandlers();
        }

        private void OnDisable()
        {
            UnregisterEventHandlers();
        }

        public void RegisterLocalPlayer(PlayerFacade player)
        {
            _player = player;
            _score.ScoresChanged += UpdateScore;
            player.RegisterCamera(_canvas.worldCamera);
        }

        private void UpdateScore()
        {
            int score = _score.GetScore(_player.netId);
            _scoreText.text = $"Score: {score}";
        }

        private void RegisterEventHandlers()
        {
            if (_player != null)
            {
                _score.ScoresChanged += UpdateScore;
            }
            if (_rounds != null)
            {
                _rounds.GameRestart += OnGameRestartHandler;
                _rounds.GameStart += OnGameStartHandler;
            }
        }

        private void UnregisterEventHandlers()
        {
            _score.ScoresChanged += UpdateScore;
            if (_rounds != null)
            {
                _rounds.GameRestart -= OnGameRestartHandler;
                _rounds.GameStart -= OnGameStartHandler;
            }
        }

        private void OnGameStartHandler()
        {
            _winText.gameObject.SetActive(false);
        }

        private void OnGameRestartHandler()
        {
            _winText.gameObject.SetActive(true);
            _winText.text = $"Player {_score.Winner} won this round!";
        }
    }
}
