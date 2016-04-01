using UnityEngine;
using System.Collections;

public class conveyorBeltScript : MonoBehaviour {

	public float speed;
	public bool goesCounterClockwise;


	void Start () {
		if (goesCounterClockwise)
			speed = -speed;
	}

	//this public function could be called by another piece of code to reverse the conveyor
	public void reverseConveyor() {
		goesCounterClockwise = !goesCounterClockwise;

		speed = -speed;
	}

	//while something is touching this objects collider, move it based on its x-value
	//predicting that this won't properly in flipped gravity for non-player objects because they don't flip their sprites
	void OnCollisionStay2D(Collision2D other)
	{
		other.transform.Translate (new Vector3 (speed, 0, 0));
	}
}
