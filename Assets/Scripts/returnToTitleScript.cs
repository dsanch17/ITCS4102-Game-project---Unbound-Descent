using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class returnToTitleScript : MonoBehaviour {

	public void returnToTitle()
	{
		SceneManager.LoadScene (3);
	}
}