using UnityEngine;
using System.Collections;

public class UserDogMovement : Movement {

    public delegate void BowEvent();
    public static event BowEvent OnBow;

    public delegate void JumpOnSpotEvent();
    public static event JumpOnSpotEvent OnJumpOnSpot;

    public delegate void RunningJumpEvent();
    public static event RunningJumpEvent OnRunningJump;
    	
	protected override void UpdateInputMovement() {

		float dx = Input.GetAxis("Horizontal");
		
		doMove(dx);
		
		if (Input.GetButton("Jump")) {
			doJump();
			if (Mathf.Abs(movementSpeed.x) < 0.01f) {
				if (OnJumpOnSpot != null) {
					OnJumpOnSpot();
				}
			} else {
				if (OnRunningJump != null) {
					OnRunningJump();
				}
			}
		} else if (Input.GetButton("Bow")) {
			doBow();
			if (OnBow != null) {
				OnBow();
			}
		}
	}
    
	protected override float getBoostForJump () {
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
