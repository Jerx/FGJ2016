using UnityEngine;
using System.Collections;

public class GoalTriggerScript : MonoBehaviour {

	private bool done = false;
	private bool timerOn = false;
	public float waitingTime = 2.0f;
	private float timer = 0.0f;

	void OnTriggerExit(Collider collider) {
		Debug.Log("Goal!");
		done = true;
		timerOn = false;
	}

	public void Update() {
		if (done) {
			if (timerOn) {
				timer += Time.deltaTime;
			} else {
				timerOn = true;
				timer = 0.0f;
			}
			if (timer >= waitingTime) {
				Application.LoadLevel("EndScene");
			}
		}
	}
}
