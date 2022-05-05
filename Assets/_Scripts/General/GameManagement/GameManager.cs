﻿using System.Collections;
using UnityEngine;

namespace Root.GameManagement
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        private const string gameSpeed = "GameSpeed";

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(this.gameObject);

            GameStateManager.OnGameStateChanged += OnGameStateChanged;
        }

        private void OnDestroy()
        {
            GameStateManager.OnGameStateChanged -= OnGameStateChanged;
        }

        private void OnGameStateChanged(GameState state)
        {
            UpdateGameSpeed(state);
        }

        private void UpdateGameSpeed(GameState currentState)
        {
            Time.timeScale = currentState != GameState.Gameplay ? 1f : PlayerPrefs.GetFloat(gameSpeed);
        }

        private void Update()
        {
            var active = GameStateManager.CurrentGameState == GameState.Gameplay;

            Cursor.visible = active;

            Cursor.lockState = active ? CursorLockMode.Confined : CursorLockMode.Locked;

            transform.Rotate(new Vector3(0, 0, 10), Space.Self);
        }

        public void FreezeGame(float duration = 0.05f) => StartCoroutine(Freeze(duration));

        private IEnumerator Freeze(float duration)
        {
            Time.timeScale = 0f;

            yield return new WaitForSecondsRealtime(duration);

            Time.timeScale = PlayerPrefs.GetFloat(gameSpeed);
        }
    }
}