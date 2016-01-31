using UnityEngine;
using System.Collections;

public class QuitGameScript : MonoBehaviour {
    
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log("Return to Main Menu");
            Application.LoadLevel("MainMenuScene");
        }
	}
}
