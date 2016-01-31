using UnityEngine;
using System.Collections;

public class MenuButtonScript : MonoBehaviour {
    	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log("Escape Key pressed");
            Application.Quit();
        } else if (Input.anyKeyDown) {
            Debug.Log("An other key is down");
            Application.LoadLevel("GameScene");
        }
	}

}
