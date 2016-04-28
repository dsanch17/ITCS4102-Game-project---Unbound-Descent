using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleMusicScript : MonoBehaviour {

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
		if (SceneManager.GetActiveScene ().name.Equals("level1") || SceneManager.GetActiveScene ().name.Equals("firstLevelWithTimer")) {
			created = false;
			Destroy (this.gameObject);
		}
	}
}

