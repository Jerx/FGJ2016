using UnityEngine;
using System.Collections;

public class FallTriggerScript : MonoBehaviour {

    void OnTriggerEnter(Collider collider) {
        Debug.Log("Respawn Trigger");
        
        Vector3 position = transform.parent.Find("SpawnPoint").position;
        collider.gameObject.GetComponent<Movement>().Respawn(position);
    }
}
