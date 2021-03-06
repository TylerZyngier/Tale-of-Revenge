using Root.Systems.States;
using UnityEngine;

namespace Root.ObjectManagement
{
    public class FixRigidbodyOnPause : MonoBehaviour
    {
        public Rigidbody2D rb;

        private RigidbodyType2D bodyType;
        private Vector2 velocity;
        private float angularVelocity;

        private void Awake() => GameStateManager.OnGameStateChanged += OnGameStateChange;

        private void OnDestroy() => GameStateManager.OnGameStateChanged -= OnGameStateChange;

        private void OnGameStateChange(GameState gameState)
        {
            if (rb == null) return;

            if (gameState == GameState.Paused)
            {
                bodyType = rb.bodyType;
                velocity = rb.velocity;
                angularVelocity = rb.angularVelocity;

                rb.bodyType = RigidbodyType2D.Static;
            }
            else if (gameState == GameState.Gameplay)
            {
                rb.bodyType = bodyType;
                rb.velocity = velocity;
                rb.angularVelocity = angularVelocity;
            }
        }
    }
}