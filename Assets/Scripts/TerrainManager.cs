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

		Vector3 pos = new Vector3();
		pos.x = offset;
		pos.y = verticalOffset;
		terrain.transform.localPosition = pos;
		BoxCollider[] arr = terrain.GetComponentsInChildren<BoxCollider>();
		foreach (BoxCollider bc in arr) {
			bc.enabled = true;
		}

		offset += width;

		// vertical offset
		int playerZ = 5;
		int hwidth = terrain.terrainData.heightmapWidth;
		float heightDiff = terrain.terrainData.GetHeight(hwidth, playerZ) - terrain.terrainData.GetHeight(0, playerZ);
		Debug.Log("    Height diff: " + heightDiff);
		verticalOffset += heightDiff;

	}

	int nextIndex() {
		// TODO: Implement this properly.
		return 2;
	}
}
