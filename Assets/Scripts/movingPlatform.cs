using UnityEngine;
using System.Collections;

public class movingPlatform : MonoBehaviour {

    public GameObject platform;
    public float moveSpeed;
    public Transform currentPosition;
    public Transform[] points;
    public int nextPoint;

	void Start () {

        currentPosition = points[nextPoint];
	}
	
	void Update () {

        platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPosition.position, Time.deltaTime * moveSpeed);

        if(platform.transform.position == currentPosition.position)
        {
            nextPoint++;

            if(nextPoint == points.Length)
            {
                nextPoint = 0;
            }

            currentPosition = points[nextPoint];

        }
	}
}
