using UnityEngine;
using System.Collections;

public class TerrainGenerationTrigger : MonoBehaviour {

	private TerrainManager terrainManager;

	void Start() {
		terrainManager = GameObject.Find("TerrainManager").GetComponent<TerrainManager>();
	}

	void OnTriggerExit(Collider collider) {
		Debug.Log("Name: " + collider.gameObject.name);
		terrainManager.nextTerrain();
		GetComponent<BoxCollider>().enabled = false;
	}
}
