using UnityEngine;
using System.Collections;

public class keyScript : MonoBehaviour {

	public SpriteRenderer goalSprite;
	public BoxCollider2D goalBox;


	void Start () {

		goalBox.enabled = false;
		hideGoal();
	
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		hideKey();
		showGoal();
	}

	void hideKey()
	{
		Color tmp = GetComponent<SpriteRenderer>().color;
		tmp.a = 0f;
		GetComponent<SpriteRenderer>().color = tmp;	
	}
	void hideGoal()
	{
		Color tmp = goalSprite.color;
		tmp.a = 0f;
		goalSprite.color = tmp;
	}

	void showGoal()
	{

		Color tmp = goalSprite.color;
		tmp.a = 1f;
		goalSprite.color = tmp;

		goalBox.enabled = true;
	}




}
