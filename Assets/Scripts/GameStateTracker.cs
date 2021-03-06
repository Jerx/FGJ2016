﻿using UnityEngine;
using System.Collections;

public class GameStateTracker : MonoBehaviour {

    public enum GameState {
        TUTORIAL,
        NORMAL
    }

    private static GameState currentState = GameState.TUTORIAL;
    private static int successfulJumpCounter = 0;
	private static bool firstTerrainGenerated = false;

    private static InterfaceGameStateChangeRule currentRule;

    //=================================================
    // GameState Rule
    //=================================================

    public static void SetGameState(GameState newState) {
        currentState = newState;
    }

    public static void SetGameStateChangeRule(InterfaceGameStateChangeRule rule) {
        currentRule = rule;
    }

    //=================================================
    // Counter, not sure if it is needed anymore...
    //=================================================

    public static void IncrementSuccessfulJumpCounter() {
		if (firstTerrainGenerated) {
        	successfulJumpCounter++;
			currentRule.UpdateGameState();
		} else {
			firstTerrainGenerated = true;
		}
    }

    public static int GetSuccessfulJumpCounter() {
        return successfulJumpCounter;
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
