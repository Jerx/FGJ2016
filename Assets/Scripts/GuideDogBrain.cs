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

	private void executeTutorial() {
		doJump ();
	}
}
