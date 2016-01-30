﻿using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {

    public Vector3 offset = new Vector3(0f, 0.1f, -1.2f);
    public Vector3 eulerAngles = new Vector3(10f, 30f, 0f);
    	
	// Update is called once per frame
	void Update () {
        Camera.main.transform.position = transform.position + offset;
        Camera.main.transform.eulerAngles = eulerAngles;
	}
}
