using UnityEngine;
using System.Collections;

public class GuideDogBrain : Movement {

	private bool tutorialStarted = false;

	protected override void UpdateInputMovement() {
		if (tutorialStarted) {
			executeTutorial();
		}
	}

	public void startTutorial() {
		tutorialStarted = true;
	}

	private bool jumpDone = false;
	private float initialX = -1f;

	private void executeTutorial() {
		if (initialX < 0f) {
			initialX = transform.position.x;
		}
		doMove(1f);
		if(isTimeToJump() && !jumpDone) {
			executeJump();
		}
	}

	private bool isTimeToJump() {
		return transform.position.x - initialX > 3f;
	}

	private void executeJump() {
		if (!jumpDone) {
			doJump();
			jumpDone = true;
		}
	}
}
