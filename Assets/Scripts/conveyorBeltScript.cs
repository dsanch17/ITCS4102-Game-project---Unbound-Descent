using UnityEngine;
using System.Collections;

public class conveyorBeltScript : MonoBehaviour {

	public float speed;
	public bool goesCounterClockwise;


	void Start () {
		if (goesCounterClockwise)
			speed = -speed;
	}

	void OnCollisionStay2D(Collision2D other)
	{

		other.transform.Translate (new Vector3 (speed, 0, 0));
	}
}
