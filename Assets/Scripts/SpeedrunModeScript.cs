using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;


public class SpeedrunModeScript : MonoBehaviour {

	float timer = 0;
	float timerTruncated;


	public Text timerText;
	public Text gravChangeCounterText;
	static bool created = false;
	int gravityCounter = 0;

	void Awake ()
	{
		if (!created)
		{
			DontDestroyOnLoad(this.gameObject);
			created = true;
			highScoreController.resetCounter ();
			highScoreController.timedGame = true;
		}

		else
		{
			Destroy(this.gameObject);
		}
	}

	void Update () {


		gravityCounter = highScoreController.getCounter ();

		timerTruncated = (float)(Math	.Truncate ((double)timer * 100.0) / 100.0);

		timerText.text = "" + timerTruncated;

		gravChangeCounterText.text = "" + gravityCounter;

		timer +=  Time.deltaTime;

		// Delete this object when: win screen is reached
		if (SceneManager.GetActiveScene ().name.Equals("highScoreScene")) {
			highScoreController.updateTime (timer);
			highScoreController.timedGame = false;
			created = false;
			Destroy (this.gameObject);
		}
	}
}