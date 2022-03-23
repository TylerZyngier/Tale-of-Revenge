using System;
using UnityEngine;

namespace GameManagement
{
    public class GameStateManager : MonoBehaviour
    {
        public static GameState CurrentGameState { get; private set; }

        public GameState currentGameState;

        public static event Action<GameState> OnGameStateChanged;

        private void Awake()
        {
            SetInitialGameState();
        }

        private void Update()
        {
            currentGameState = CurrentGameState;
        }

        public static void SetState(GameState newGameState)
        {
            if (newGameState == CurrentGameState)
                return;

            CurrentGameState = newGameState;

            OnGameStateChanged?.Invoke(newGameState);
        }

        private void SetInitialGameState()
        {
            int sceneIndex = Utils.GlobalFunctions.GetActiveSceneIndex();

            SetState(GameState.Gameplay);
        }
    }
}