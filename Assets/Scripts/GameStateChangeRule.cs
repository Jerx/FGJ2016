using System;

public interface GameStateChangeRule {

    void UpdateGameState(GameStateTracker gameStateTracker);
}
