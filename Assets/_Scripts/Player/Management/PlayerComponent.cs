using UnityEngine;
using Root.Cameras;
using Root.Systems.Audio;
using Root.Systems.Input;

namespace Root.Player.Components
{
    public class PlayerComponent : MonoBehaviour
    {
        public PlayerManager playerManager;

        public InputManager input { get => InputManager.instance; }

        public PlayerManager.PlayerComponents components { get => playerManager.components; }

        public new Collider2D collider { get => components.collider; }
        public new PlayerAnimation animation { get => components.animation; }

        public Rigidbody2D rb { get => components.rb; }
        public Animator anim { get => components.anim; }
        public Transform center { get => components.center; }
        public LocalAudioController audioPlayer { get => components.audioPlayer; }

        public PlayerCombat combat { get => components.combat; }
        public PlayerHealth health { get => components.health; }
        public PlayerCollision collision { get => components.collision; }
        public PlayerController controller { get => components.controller; }
        public SpearManager spearManager { get => components.spearManager; }
        public PlayerKnockbackManager knockback { get => components.knockback; }
        public PlayerDeathManager deathManager { get => components.deathManager; }
        public PlayerCameraController playerCamera { get => components.playerCamera; }

        public PlayerManager.PlayerSoundEffects soundEffects { get => playerManager.soundEffects; }
        public PlayerManager.PlayerParticleEffects particleEffects { get => playerManager.particleEffects; }
    }
}