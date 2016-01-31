using UnityEngine;
using System.Collections;

public class UserDogMovement : Movement {

    public delegate void BowEvent();
    public static event BowEvent OnBow;

    public delegate void JumpOnSpotEvent();
    public static event JumpOnSpotEvent OnJumpOnSpot;

    public delegate void RunningJumpEvent();
    public static event RunningJumpEvent OnRunningJump;

    private bool releasedJumpButton = true;

    protected override void UpdateInputMovement() {

        float dx = Input.GetAxis("Horizontal");

        doMove(dx);

        if (Input.GetButton("Jump")) {
            if (releasedJumpButton) {
                doJump();
                if (Mathf.Abs(movementSpeed.x) < 0.01f) {
                    PlayBounceAnimation();
                    if (OnJumpOnSpot != null) {
                        OnJumpOnSpot();
                    }
                } else {
                    PlayJumpAnimation();
                    if (OnRunningJump != null) {
                        OnRunningJump();
                    }
                }
            }
        } else if (Input.GetButton("Bow")) {
            doBow();
            if (OnBow != null) {
                OnBow();
            }
        }

        updateJumpButtonRelease();
    }

    private void updateJumpButtonRelease() {
        if (Input.GetButton("Jump")) {
            releasedJumpButton = false;
        } else if (GetComponent<CharacterController>().isGrounded) {
            releasedJumpButton = true;
        }
    }

    protected override float getBoostForJump() {
        if (GameStateTracker.InNormalMode()) {
            return jumpBoost;
        }
        if (GameStateTracker.InTutorialMode()) {
            TaskManager taskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
            return taskManager.IsMissionComplete() ? jumpBoost : 1.0f;
        }
        return 1.0f;
    }
}
