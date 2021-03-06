﻿using UnityEngine;
using System.Collections;

public class TerrainGenerationTrigger : MonoBehaviour {

	private TerrainManager terrainManager;

	void Start() {
		terrainManager = GameObject.Find("TerrainManager").GetComponent<TerrainManager>();
	}

	void OnTriggerExit(Collider collider) {
		terrainManager.DespawnGuideDog();
        if (collider.gameObject.name != "GuideDog") {

            // If one reaches this trigger, a successful jump has occured.
            GameStateTracker.IncrementSuccessfulJumpCounter();

            terrainManager.nextTerrain();
            GetComponent<BoxCollider>().enabled = false;
        }
	}
}
