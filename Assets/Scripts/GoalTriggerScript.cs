using UnityEngine;
using System.Collections;

public class GoalTriggerScript : MonoBehaviour {

	void OnTriggerExit(Collider collider) {
		Debug.Log("Goal!");
	}
}
