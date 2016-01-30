using UnityEngine;
using System.Collections;



public abstract class Movement : MonoBehaviour {

	public float moveSpeed;
    public float jumpSpeed;
	public float jumpBoost;

    protected Vector3 movementSpeed = new Vector3();

    private bool bowing = false;
    public bool Bowing {
        get;
        set;
    }

    public float maxBowTimer = 1.0f;
    private float bowTimer;

    private CharacterController characterController;

    private bool respawning = false;
    private float respawnTimer = 0f;
    public float respawnTimerMax = 1f;

    void Start() {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {
        if (respawning) {
            UpdateRespawning();
            ApplyGravity();
        } else if (characterController.isGrounded) {
			movementSpeed.y = 0f;
            if (bowing) {
                UpdateBowing();
            } else {
                UpdateInputMovement();
            }
        } else {
            ApplyGravity();
        }

        characterController.Move(movementSpeed * Time.deltaTime);
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
        if (bowTimer >= maxBowTimer) {
            bowTimer = 0.0f;
            bowing = false;
			transform.eulerAngles = Vector3.zero;
        } else {
			Vector3 bowingRotationVector = new Vector3();
			bowingRotationVector.z = -30;
			transform.eulerAngles = bowingRotationVector;
		}
    }

    private void ApplyGravity() {
		if (!characterController.isGrounded) {
        	movementSpeed += Physics.gravity * Time.deltaTime;
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

	protected abstract void UpdateInputMovement();

	protected void doJump() {
		if (characterController.isGrounded) {
			movementSpeed.x *= getBoostForJump();
			movementSpeed.y = jumpSpeed;
		}
	}

	private float getBoostForJump() {
		if (GameStateTracker.InNormalMode()) {
			return jumpBoost;
		}
		if (GameStateTracker.InTutorialMode()) {
			TaskManager taskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
			return taskManager.IsMissionComplete() ? jumpBoost : 1.0f;
		}
		return 1.0f;
	}

	protected void doBow() {
		bowing = true;
	}

	protected void doMove(float dx) {
		movementSpeed.x = dx * moveSpeed;
	}

	protected bool IsIdle() {
		return characterController.isGrounded && !bowing && isZeroMovement();
	}

	private bool isZeroMovement() {
		return Vector3.Magnitude(movementSpeed) < 1e-3f;
	}
}
