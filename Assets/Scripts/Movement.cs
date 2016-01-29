using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float moveSpeed = 5.0f;
    public float jumpSpeed = 20f;

    private Vector3 movement = new Vector3();
    private bool bowing = false;

    public float maxBowTimer = 1.0f;
    private float bowTimer;

    // Update is called once per frame
    void Update() {
        CharacterController cc = GetComponent<CharacterController>();

        if (cc.isGrounded) {
            if (bowing) {
                UpdateBowing();
            } else {
                float dx = Input.GetAxis("Horizontal");

                movement.x = dx * moveSpeed;

                if (Input.GetButton("Jump")) {
                    movement.y = jumpSpeed;
                } else if (Input.GetButton("Bow")) {
                    bowing = true;
                }
            }
        }

        movement += Physics.gravity * Time.deltaTime;
        cc.Move(movement * Time.deltaTime);
    }
    
    private void UpdateBowing() {
        bowTimer += Time.deltaTime;
        if (bowTimer >= maxBowTimer) {
            bowTimer = 0.0f;
            bowing = false;
        }
    }
}
