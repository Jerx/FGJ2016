using UnityEngine;
using System.Collections;

public class UserDogMovement : Movement {

    public delegate void BowEvent();
    public static event BowEvent OnBow;

    public delegate void JumpOnSpotEvent();
    public static event JumpOnSpotEvent OnJumpOnSpot;

    public delegate void RunningJumpEvent();
    public static event RunningJumpEvent OnRunningJump;

    public Animator animator;
	
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
    
}
