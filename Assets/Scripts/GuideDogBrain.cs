using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuideDogBrain : Movement {

	private bool tutorialStarted = false;
	private LinkedList<TaskManager.Task> tasks;

	protected override void UpdateInputMovement() {
		if (tutorialStarted) {
			executeTutorial();
		}
	}

	public void startTutorial() {
		tasks = getTasksToShow();
		tutorialStarted = true;
	}

	private LinkedList<TaskManager.Task> getTasksToShow() {
		return GameObject.Find("TaskManager").GetComponent<TaskManager>().getCurrentTasks();
	}

	private bool jumpDone = false;
	private float initialX = -1f;

	private void executeTutorial() {
        Debug.Log("ExecuteTutorial");
		
		if (initialX < 0f) {
			initialX = transform.position.x;
		}

		if (tasks.Count > 0 && IsIdle()) {
			TaskManager.Task task = tasks.First.Value;
			tasks.RemoveFirst();
			if (task == TaskManager.Task.BOW) {
				doBow();
			} else if (task == TaskManager.Task.JUMP_ON_SPOT) {
				doJump();
			}
		} else {
			if (isTimeToMove()) {
				doMove(1f);
			}
			if(isTimeToJump() && !jumpDone) {
				executeJump();
			}
		}
	}

	private bool isTimeToMove() {
		return tasks.Count == 0;
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
