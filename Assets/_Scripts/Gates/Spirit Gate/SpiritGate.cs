using UnityEngine;
using Root.Systems.States;

namespace Root.Gates
{
    public class SpiritGate : MonoBehaviour
    {
        [SerializeField] private float gateLiftSpeed;
        [SerializeField, Range(0, 1)] private float gateLiftLerpSpeed;
        [SerializeField] private float gateLiftDistance = 4f;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Animator anim;

        private Vector3 openPosition;
        private bool liftGate;
        private float currentSpeed;

        private bool isOpen;
        internal bool IsOpen
        {
            get => isOpen;
            set
            {
                isOpen = value;
                currentSpeed = 0f;
                rb.bodyType = value ? RigidbodyType2D.Kinematic : RigidbodyType2D.Dynamic;
                rb.velocity = Vector2.zero;

                anim.SetTrigger(value ? "Activate" : "Deactivate");
            }
        }

        private void Awake() => openPosition = transform.position + new Vector3(0, gateLiftDistance);

        private void FixedUpdate()
        {
            if (GameStateManager.CurrentGameState == GameState.Paused || !liftGate) return;

            Vector3 position = transform.position;

            currentSpeed = Mathf.Lerp(currentSpeed, gateLiftSpeed, gateLiftLerpSpeed);
            transform.position = Vector3.MoveTowards(position, openPosition, currentSpeed);
        }

        private void LiftGate() => liftGate = true;
        private void DropGate() => liftGate = false;
    }
}
