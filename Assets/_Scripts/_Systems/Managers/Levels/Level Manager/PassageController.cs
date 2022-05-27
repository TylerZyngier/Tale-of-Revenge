using Root.Player;
using UnityEngine;

namespace Root.Systems.Levels
{
    public class PassageController : MonoBehaviour
    {
        public int id;

        [SerializeField] private Collider2D passageTrigger;
        [Space]
        [SerializeField] private Vector2 spawnPositionOffset = new Vector2(0, -2);

        internal Vector3 spawnPosition { get => transform.position + (Vector3)spawnPositionOffset; }

        private bool passageDisabled;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (passageDisabled || !other.CompareTag("Player")) return;

            PassageManager.instance.LoadLevel(this);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;

            passageDisabled = false;
        }

        public void TeleportPlayer()
        {
            passageDisabled = true;

            PlayerManager playerManager = PlayerManager.instance;

            if (playerManager == null)
            {
                Debug.Log("There is no available instance of the player");

                return;
            }

            playerManager.MovePlayer(spawnPosition);
        }
    }
}