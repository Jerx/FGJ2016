using UnityEngine;
using System.Collections;

public class GameStateTracker {

    public enum GameState {
        TUTORIAL,
        NORMAL
    }

    private static GameState currentState = GameState.TUTORIAL;
    private static int successfulJumpCounter = 0;

    public static void IncrementSuccessfulJumpCounter() {
        successfulJumpCounter++;
    }

    public static int GetSuccessfulJumpCounter() {
        return successfulJumpCounter;
    }

    public static void SetGameState(GameState newState) {
        currentState = newState;
    }

    //=================================================
    // State Checkers
    //=================================================

    public static bool InTutorialMode() {
        return currentState == GameState.TUTORIAL;
    }

    public static bool InNormalMode() {
        return currentState == GameState.NORMAL;
    }
}
