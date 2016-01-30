using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float moveSpeed = 5.0f;
    public float jumpSpeed = 20f;

    private Vector3 movementSpeed = new Vector3();

    private bool bowing = false;
    public bool Bowing {
        get;
        set;
    }

    public float maxBowTimer = 1.0f;
    private float bowTimer;

    private CharacterController cc;
    private float ccDefaultHeight;

    private bool respawning = false;
    private float respawnTimer = 0f;
    public float respawnTimerMax = 0.5f;

    void Start() {
        cc = GetComponent<CharacterController>();
        ccDefaultHeight = cc.height;
    }

    // Update is called once per frame
    void Update() {
        if (respawning) {
            UpdateRespawning();
            return; // Don't do anything else before spawning complete
        }

        if (cc.isGrounded) {
            if (bowing) {
                UpdateBowing();
            } else {
                float dx = Input.GetAxis("Horizontal");

                movementSpeed.x = dx * moveSpeed;

                if (Input.GetButton("Jump")) {
                    movementSpeed.y = jumpSpeed;
                } else if (Input.GetButton("Bow")) {
                    bowing = true;
                }
            }
        } else {
            movementSpeed += Physics.gravity * Time.deltaTime;
        }

        cc.Move(movementSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Helper function for handling respawning
    /// </summary>
    private void UpdateRespawning() {
        respawnTimer += Time.deltaTime;
        if (respawnTimer >= respawnTimerMax) {
            respawnTimer = 0.0f;
            respawning = false;
        }
    }

    /// <summary>
    /// Helper function for handling bowing
    /// </summary>
    private void UpdateBowing() {
        bowTimer += Time.deltaTime;
        if (cc.height > 0.25) {
            cc.height -= 10 * Time.deltaTime;
        }
        if (bowTimer >= maxBowTimer) {
            bowTimer = 0.0f;
            bowing = false;
            cc.height = ccDefaultHeight;
        }
    }

    /// <summary>
    /// Respawn character at <code>position</code>
    /// </summary>
    /// <param name="position"></param>
    public void Respawn(Vector3 position) {
        respawning = true;
        transform.position = position;
        movementSpeed = Vector3.zero;
    }
}
