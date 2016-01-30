using UnityEngine;
using System.Collections;

public class FallTriggerScript : MonoBehaviour {

    void OnTriggerEnter(Collider collider) {
        Debug.Log("Respawn Trigger");
        
        Vector3 position = transform.parent.Find("PlayerSpawnPoint").position;
        collider.gameObject.GetComponent<Movement>().Respawn(position);

        GameObject.Find("TerrainManager").GetComponent<TerrainManager>().RespawnGuideDog();
    }
}
