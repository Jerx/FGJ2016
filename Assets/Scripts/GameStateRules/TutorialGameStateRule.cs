using UnityEngine;
using System.Collections;
using System;

public class TutorialGameStateRule : InterfaceGameStateChangeRule {

    public void UpdateGameState() {
        if(GameStateTracker.GetSuccessfulJumpCounter() == 3) {
            GameStateTracker.SetGameState(GameStateTracker.GameState.NORMAL);
        }
    }
}
