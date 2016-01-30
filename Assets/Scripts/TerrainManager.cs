﻿using UnityEngine;
using System.Collections;

public class TerrainManager : MonoBehaviour {

	private float offset = 60f;
	private float verticalOffset = -100f;
	public Terrain[] terrainPrefabs;

	public void nextTerrain() {

		int index = nextIndex();

		Debug.Log ("Creating new terrain!");
		Debug.Log ("  Index: " + index);

		Terrain terrain = GameObject.Instantiate<Terrain>(terrainPrefabs[index]);
		terrain.transform.parent = this.transform;
		Vector3 terrainSize = terrain.terrainData.size;
		float width = terrainSize.x;
		float length = terrainSize.z;

		Debug.Log("    Width = " + width);
		Debug.Log("    Length = " + length);

		Vector3 pos = new Vector3();
		pos.x = offset;
		pos.y = verticalOffset;
		terrain.transform.localPosition = pos;
		BoxCollider[] arr = terrain.GetComponentsInChildren<BoxCollider>();
		foreach (BoxCollider bc in arr) {
			bc.enabled = true;
		}

		offset += width;

		// TODO: vertical offset
		// verticalOffset += 
	}

	int nextIndex() {
		// TODO: Implement this properly.
		return 2;
	}
}
