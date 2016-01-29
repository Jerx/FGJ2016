using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float moveSpeed = 5.0f;
    public float jumpSpeed = 20f;

    private Vector3 movement = new Vector3();

    // Update is called once per frame
    void Update() {
        CharacterController cc = GetComponent<CharacterController>();

        if (cc.isGrounded) {
            float dx = Input.GetAxis("Horizontal");
            float dy = Input.GetAxis("Vertical"); // Not yet used for the movement (only 2D this far)

            movement.x = dx * moveSpeed;

            if (Input.GetButton("Jump")) {
                movement.y = jumpSpeed;
            }
        }

        movement += Physics.gravity * Time.deltaTime;
        cc.Move(movement * Time.deltaTime);
    }
}
