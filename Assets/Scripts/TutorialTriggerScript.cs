using UnityEngine;
using System.Collections;

public class TutorialTriggerScript : MonoBehaviour {

    void OnTriggerExit(Collider collider) {

        Debug.Log("Trigger Tutorial");

		restartMissionForPlayer();

		startTutorial();

    }

	private void restartMissionForPlayer() {
		TaskManager taskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
		taskManager.RestartTasks();
	}

	private void startTutorial() {
		GameObject guideDog = GameObject.Find("GuideDog");
		GuideDogBrain brain = guideDog.GetComponent<GuideDogBrain>();
		brain.startTutorial();
	}

}
