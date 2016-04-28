using UnityEngine;
using System.Collections;

public class OpeningScrollScript : MonoBehaviour {
	
	public Transform scrollTransform;

	float timer = 0;
	float speedOfScroll = .02f;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {

		

		timer += Time.deltaTime;
		//float pos;

		scrollTransform.position = new Vector3 (scrollTransform.position.x, (scrollTransform.position.y + speedOfScroll), scrollTransform.position.z);

		//pos += timer;


	
	}
}
