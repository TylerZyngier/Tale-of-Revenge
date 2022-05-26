using Root.Player.Spear;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Root.Player.Components
{
    public class PlayerSpearManager : PlayerComponent
    {
        [SerializeField] private bool debug;
        [Space]
        [SerializeField] private GameObject spearPrefab;
        [SerializeField] private Transform playerCenter;
        [SerializeField] private LayerMask groundLayer;
        [Space]
        [SerializeField] private float maxSpearDistance = 50f;
        [SerializeField] private float spearOffsetDistance = 4f;
        [SerializeField] private float spearThrowCooldown = 0.15f;

        private SpearStateManager spearStateManager;
        internal bool isSpearActive;
        private bool SpearInRange => Vector2.Distance(center.position, spearStateManager.transform.position) <= maxSpearDistance;
        private float spearThrowCooldownTimer;

        private void Update() => spearThrowCooldownTimer -= Time.deltaTime;

        public void OnSpear(InputAction.CallbackContext context)
        {
            if (isSpearActive && (context.performed || !SpearInRange))
            {
                RetractSpear();
                return;
            }

            if (context.performed && spearThrowCooldownTimer <= 0)
            {
                ThrowSpear();
            }
        }

        private void ThrowSpear()
        {
            isSpearActive = true;
            spearThrowCooldownTimer = spearThrowCooldown;
            controller.SpearHop();

            GameObject spearObject = Instantiate(spearPrefab, GetSpearStartPosition(), GetSpearStartRotation());

            spearStateManager = spearObject.GetComponent<SpearStateManager>();
            spearStateManager.Init(playerManager);
        }

        private void RetractSpear() => spearStateManager.ReturnToPlayer();

        private Quaternion GetSpearStartRotation()
        {
            Vector3 aimDir = Utility.Utils.MouseWorldPosition - playerCenter.position;
            float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
            Quaternion quaternion = Quaternion.AngleAxis(angle, Vector3.forward);

            return quaternion;
        }

        private Vector3 GetSpearStartPosition()
        {
            Vector3 position = playerCenter.position;
            Vector3 aimDir = (Utility.Utils.MouseWorldPosition - position).normalized;
            Vector3 centerPos = position;
            Vector3 spearOriginPosition = centerPos + (aimDir * spearOffsetDistance);

            RaycastHit2D hit = Physics2D.Raycast(centerPos, aimDir, spearOffsetDistance, groundLayer);

            float distanceToHitPoint = Vector2.Distance(centerPos, hit.point);
            float distanceToSpearOrigin = Vector2.Distance(centerPos, spearOriginPosition);

            return distanceToHitPoint < distanceToSpearOrigin ? (Vector3)hit.point : spearOriginPosition;
        }

        private void OnDrawGizmos()
        {
            if (!debug) return;

            Gizmos.DrawWireSphere(GetSpearStartPosition(), 0.3f);
        }
    }
}