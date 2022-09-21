using Mirror;
using UnityEngine;

namespace BhTest.Player
{
    public class PlayerColor : NetworkBehaviour
    {
        [SerializeField] private MeshRenderer _renderer;
        [field: SyncVar(hook = nameof(OnColorChange))] public Color MeshColor { get; set; }

        private void Awake()
        {
            MeshColor = _renderer.material.color;
        }

        private void OnColorChange(Color old, Color current)
        {
            _renderer.material.color = current;
        }
    }
}
