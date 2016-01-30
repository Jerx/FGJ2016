using UnityEngine;
using System.Collections;

public class FollowCameraPosition : MonoBehaviour {

    public Vector3 offset = new Vector3(70, 0, 20);

	// Update is called once per frame
	void Update () {
        transform.position = Camera.main.transform.position + offset;
	}
}
