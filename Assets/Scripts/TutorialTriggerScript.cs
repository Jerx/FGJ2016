using UnityEngine;
using System.Collections;

public class TutorialTriggerScript : MonoBehaviour {

    void OnTriggerExit(Collider collider) {
        Debug.Log("Trigger Tutorial");
		GameObject guideDog = GameObject.Find("GuideDog");
		GuideDogBrain brain = guideDog.GetComponent<GuideDogBrain>();
		brain.startTutorial();
    }

}
