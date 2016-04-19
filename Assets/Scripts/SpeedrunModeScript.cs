using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;


public class SpeedrunModeScript : MonoBehaviour {

	float timer = 0;
	float timerTruncated;


	public Text timerText;
	static bool created = false;
	int gravityCounter = 0;

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

	void Update () {


		gravityCounter = highScoreController.getCounter ();

	//	timerTruncated = (float)(Math.Truncate ((double)timer * 100.0) / 100.0);

		timerText.text = "" + gravityCounter;

		timer +=  Time.deltaTime;

		/* Delete this object when:
		if (SceneManager.GetActiveScene ().buildIndex > 1) {
			created = false;
			Destroy (this.gameObject);
		}
		*/
	}
}