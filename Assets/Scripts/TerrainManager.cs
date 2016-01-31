using UnityEngine;
using System.Collections;

public class TerrainManager : MonoBehaviour {

    private float offset = 70f;
    private float verticalOffset = -100f;
    public Terrain[] terrainPrefabs;

	public int failsNeededToFinish = 2;

    public GameObject dogPrefab;

    private Terrain currentTerrain;

    public void nextTerrain() {

		initializeNewTasks();

        int index = nextIndex();

        Debug.Log("Creating new terrain!");
        Debug.Log("  Index: " + index);

		generateTerrain(index);
		if (index == 2) {
			generateTerrain(1);
		}
    }

	private void generateTerrain(int index) {
		
		Terrain terrain = GameObject.Instantiate<Terrain>(terrainPrefabs[index]);
		terrain.transform.parent = this.transform;
		Vector3 terrainSize = terrain.terrainData.size;
		float width = terrainSize.x;
		
		Vector3 pos = new Vector3();
		pos.x = offset;
		pos.y = verticalOffset;
		terrain.transform.localPosition = pos;
		BoxCollider[] arr = terrain.GetComponentsInChildren<BoxCollider>();
		foreach (BoxCollider bc in arr) {
			bc.enabled = true;
			
			if (GameStateTracker.InNormalMode()) {
				foreach (Transform child in bc.transform.parent) {
					if (child.name == "TutorialTrigger") {
						child.GetComponent<BoxCollider>().enabled = false;
					}
				}
			}
		}
		
		offset += width;
		
		// vertical offset
		int playerZ = 5;
		int hwidth = terrain.terrainData.heightmapWidth;
		float heightDiff = terrain.terrainData.GetHeight(hwidth, playerZ) - terrain.terrainData.GetHeight(0, playerZ);
		Debug.Log("    Height diff: " + heightDiff);
		verticalOffset += heightDiff;
		
		currentTerrain = terrain;
		
		if (GameStateTracker.InTutorialMode()) {
			SpawnGuideDog(terrain);
		}
	}
	
	private void initializeNewTasks() {
		// TODO: change this to choose the tasks correctly, now always the same tasks.
		TaskManager taskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
		taskManager.RestartTasks();
	}

    int nextIndex() {
        TaskManager taskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
		if (taskManager.MissionFailsInARow() >= failsNeededToFinish) {
			return 3;
		}
        return 2;
    }

    /// <summary>
    /// Spawn in the Tutorial Dog at the Spawn Point defined in the Given Terrain
    /// </summary>
    /// <param name="terrain"></param>
    void SpawnGuideDog(Terrain terrain) {
        foreach (Transform transform in terrain.gameObject.transform) {
            if (transform.gameObject.name == "SpawnPoint") {
                GameObject guideDog = GameObject.Instantiate<GameObject>(dogPrefab);
                guideDog.transform.position = transform.position;
                guideDog.name = "GuideDog";
            }
        }
    }

    public void RespawnGuideDog() {
        Debug.Log("Respawning Guide Dog");
        DespawnGuideDog();
        if (GameStateTracker.InTutorialMode()) {
            SpawnGuideDog(currentTerrain);
        }
    }
    
    public void DespawnGuideDog() {
        GameObject.Destroy(GameObject.Find("GuideDog"));
    }
}
