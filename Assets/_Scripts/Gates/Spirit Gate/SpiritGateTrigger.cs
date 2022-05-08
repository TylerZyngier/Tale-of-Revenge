using UnityEngine;

namespace Root.Gates
{
    public class SpiritGateTrigger : MonoBehaviour
    {
        [SerializeField] private SpiritGate spiritGate;
        [SerializeField] private Animator anim;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Spear")) return;

            spiritGate.isOpen = true;
            anim.SetTrigger("Activate");
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Spear")) return;

            spiritGate.isOpen = false;
            anim.SetTrigger("Deactivate");
        }
    }
}