using BhTest.Player;
using TMPro;
using UnityEngine;

namespace BhTest.UI.Gameplay
{
    [RequireComponent(typeof(Canvas))]
    public class HUD : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;

        private PlayerFacade _player;
        private Canvas _canvas;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
        }

        public void RegisterLocalPlayer(PlayerFacade player)
        {
            _player = player;
            _player.Score.ScoreChanged += UpdateScore;
            UpdateScore(_player.Score.Score);
            player.RegisterCamera(_canvas.worldCamera);
        }

        private void UpdateScore(int score)
        {
            _scoreText.text = $"Score: {score}";
        }
    }
}
