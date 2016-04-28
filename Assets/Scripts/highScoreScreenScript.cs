using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;


public class highScoreScreenScript : MonoBehaviour {
	
	public Text finalTimeText;



	void Awake ()
	{
		
	}


	// Use this for initialization
	void Start () {
		
	}
	/*
	int getMinutes(float time) {
		return (int)Math.Floor(time / 60);
	}
	*/
	String getSecondsAsString(float time) {
		String str = "" + (float)(Math.Truncate ((double)time * 100.0) / 100.0);
		return str;

	}
	/*
	String calcScoreText(float time, int turns) {
		int seconds = getSeconds (time);

		String str = "" + minutes + ":" + seconds + " - " + turns + " Grav flips";

		return str;
	}
	*/
	// Update is called once per frame
	void Update () {
		String secondsStr = getSecondsAsString (highScoreController.getTime ());

		finalTimeText.text = secondsStr + " Seconds\n" + highScoreController.getCounter() + " Gravity flips";
	
	}
}
