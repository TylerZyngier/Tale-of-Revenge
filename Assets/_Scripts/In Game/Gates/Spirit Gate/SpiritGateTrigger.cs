using Root.Systems.States;
using UnityEngine;

namespace Root.Gates
{
    public class SpiritGateTrigger : MonoBehaviour
    {
        [SerializeField] private SpiritGate spiritGate;
        [SerializeField] private Animator anim;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!GameStateManager.inGameplay || !other.CompareTag("Spear")) return;

            spiritGate.IsOpen = true;
            anim.SetTrigger("Activate");
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!GameStateManager.inGameplay || !other.CompareTag("Spear")) return;

            spiritGate.IsOpen = false;
            anim.SetTrigger("Deactivate");
        }
    }
}
