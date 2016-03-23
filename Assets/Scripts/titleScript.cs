using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class titleScript : MonoBehaviour {

	public void playPrototype()
	{
		SceneManager.LoadScene ("prototypeLevel2");
	}

	public void viewInstructions()
	{
		SceneManager.LoadScene ("InstructionsScene");
	}
}