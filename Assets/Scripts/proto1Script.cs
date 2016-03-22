using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


// I hope you are having a great day

public class Proto1Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		gotoLevel2();
	}

	public void gotoLevel2()
	{
		SceneManager.LoadScene ("prototypeLevel");
	}
}
