using UnityEngine;
using System.Collections;

public class ScreenScrollScript : MonoBehaviour {
	
	public Transform scrollTransform;
	public Transform secondTransform;

	float timer = 0;
	float speedOfScroll = .03f;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {



		timer += Time.deltaTime;
		//float pos;
		if (timer > 1.3 && scrollTransform.position.y > -10.0f) {
			scrollTransform.position = new Vector3 (scrollTransform.position.x, (scrollTransform.position.y - speedOfScroll), scrollTransform.position.z);
			secondTransform.position = new Vector3 (secondTransform.position.x, (secondTransform.position.y + speedOfScroll), secondTransform.position.z);
		}
		//pos += timer;


	
	}
}
