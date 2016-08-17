using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameAudioScript : MonoBehaviour {

	private static bool created = false;

	void Awake ()
	{
		if (!created)
		{
			DontDestroyOnLoad(this.gameObject);
			created = true;
		}

		else
		{
			Destroy(this.gameObject);
		}
	}

	void Update ()
	{
		if (SceneManager.GetActiveScene ().name == "TitleScreen" || SceneManager.GetActiveScene ().name == "Win") {
			created = false;
			Destroy (this.gameObject);
		}
	}
}
