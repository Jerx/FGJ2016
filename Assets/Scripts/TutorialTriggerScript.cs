using UnityEngine;
using System.Collections;

public class TutorialTriggerScript : MonoBehaviour {

    void OnTriggerExit(Collider collider) {
        Debug.Log("Trigger Tutorial");
    }

}
