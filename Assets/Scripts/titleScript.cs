using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class titleScript : MonoBehaviour {

	public void playGame()
	{
		SceneManager.LoadScene (2);
	}

	public void playGameWithTimer()
	{
		SceneManager.LoadScene ("firstLevelWithTimer");
	}


	public void viewControls()
	{
		SceneManager.LoadScene ("ControlsScene");
	}

	public void viewInstructions()
	{
		SceneManager.LoadScene ("StoryInstructions");
	}

	public void viewCredits()
	{
		SceneManager.LoadScene ("CreditsScene");
	}
}