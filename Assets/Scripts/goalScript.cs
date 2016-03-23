using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


// I hope you are having a great day

public class goalScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D c)
	{
		goToNextLevel();
	}

	public void goToNextLevel() //loads next level by the index in build settings
	{
		int nextLevel = (SceneManager.GetActiveScene().buildIndex + 1);
		SceneManager.LoadScene(nextLevel);
	}
/*
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.transform.tag == "level1Exit")
		{
			SceneManager.LoadScene(3);
		}

		if (other.transform.tag == "level2Exit")
		{
			SceneManager.LoadScene(5);
		}

		if (other.transform.tag == "level3Exit")
		{
			SceneManager.LoadScene(2);
		}
	}
	*/
}
