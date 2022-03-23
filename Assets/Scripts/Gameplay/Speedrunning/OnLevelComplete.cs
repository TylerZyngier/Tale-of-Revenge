using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLevelComplete : MonoBehaviour {
    [SerializeField] private Animator anim;

    private void Awake() {
        CheckpointManager.OnFinalCheckpointTriggered += OnFinalCheckpointTriggered;
    }

    private void OnDestroy() {
        CheckpointManager.OnFinalCheckpointTriggered -= OnFinalCheckpointTriggered;
    }

    private void OnFinalCheckpointTriggered() {
        anim.SetTrigger("Popup");
    }
}
