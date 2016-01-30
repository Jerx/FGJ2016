using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {

    public Vector3 offset = new Vector3(1.25f, 1.5f, -2.5f);
    public Vector3 eulerAngles = new Vector3(25f, 0f, 0f);
    	
	// Update is called once per frame
	void Update () {
        Camera.main.transform.position = transform.position + offset;
        Camera.main.transform.eulerAngles = eulerAngles;
	}
}
