using UnityEngine;
using System.Collections;

public class GuideDogBrain : Movement {

	protected override void UpdateInputMovement() {
		doJump ();
	}
}
