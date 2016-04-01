using UnityEngine;
using System.Collections;

public class gravityButton : MonoBehaviour
{
	//this boolean determines if the button being held down locks gravity in place
	//this seems like a bad idea
	public bool lockGravity;
	public playerScript player;


	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnCollisionStay2D(Collision2D other)
	{
	}
}
