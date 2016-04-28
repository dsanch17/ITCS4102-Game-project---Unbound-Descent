using UnityEngine;
using System.Collections;

public class gravityButton : MonoBehaviour
{
	//this boolean determines if the button being held down locks gravity in place
	//this would freeze gravity rotation every frame until the player or a box is moved off the button, unimplemented for now

	//public bool lockGravity; 

	//enums are cool
	public enum Direction{None, Up, Down, Left, Right};
	public Direction gravityDirection;
	public Animator buttonAnimator;

	void OnCollisionEnter2D(Collision2D other) {
		changeGravityButtion();
	}

	void OnCollisionStay2D(Collision2D other)
	{
		//if (lockGravity)
		//	changeGravityButtion();
		
	}

	public void changeGravityButtion() {
		if (gravityDirection == Direction.Up) 
			gravityController.setGravUp ();
		if (gravityDirection == Direction.Down) 
			gravityController.setGravDown ();
		if (gravityDirection == Direction.Left) 
			gravityController.setGravLeft ();
		if (gravityDirection == Direction.Right) 
			gravityController.setGravRight ();
		
	}

	void OnCollisionExit2D(Collision2D other) {
	}

	void OnTriggerEnter2D(Collider2D c) {
		buttonAnimator.SetBool ("buttonPressed", true);
	}

	void OnTriggerExit2D(Collider2D c) {
		buttonAnimator.SetBool ("buttonPressed", false);

	}


}
