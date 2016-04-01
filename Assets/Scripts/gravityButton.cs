using UnityEngine;
using System.Collections;

public class gravityButton : MonoBehaviour
{
	//this boolean determines if the button being held down locks gravity in place
	//this seems like a bad idea
//	public bool lockGravity;

	//enums are cool
	public enum Direction{None, Up, Down, Left, Right};
	public Direction gravityDirection;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (gravityDirection == Direction.Up) 
			gravityController.setGravUp ();
		if (gravityDirection == Direction.Down) 
			gravityController.setGravDown ();
		if (gravityDirection == Direction.Left) 
			gravityController.setGravLeft ();
		if (gravityDirection == Direction.Right) 
			gravityController.setGravRight ();
	}

	void OnCollisionStay2D(Collision2D other)
	{
	}
}
