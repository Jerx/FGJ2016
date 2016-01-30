using UnityEngine;
using System.Collections;

public class FallTriggerScript : MonoBehaviour {

    void OnTriggerEnter(Collider collider) {
        Debug.Log("Respawn Trigger");

        Vector3 position = collider.transform.position;
        collider.gameObject.transform.position = new Vector3(position.x, 20, position.z);
        collider.gameObject.GetComponent<Movement>().MovementSpeed = Vector3.zero;
    }
}
