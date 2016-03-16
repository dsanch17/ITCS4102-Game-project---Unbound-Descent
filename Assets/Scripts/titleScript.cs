using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class titleScript : MonoBehaviour {

	public void playPrototype()
	{
		SceneManager.LoadScene (2);
	}

	public void viewInstructions()
	{
		SceneManager.LoadScene (4);
	}
}