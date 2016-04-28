using UnityEngine;
using System.Collections;

public class keyScript : MonoBehaviour {

	public SpriteRenderer goalSprite;
	public BoxCollider2D goalBox;
	public SpriteRenderer lockSprite;
	public PolygonCollider2D lockCollision;

	public Sprite doorToLeaveOpen;
	public Sprite doorToLeaveClosed;


	void Start () {

		goalSprite.sprite = doorToLeaveClosed;
		lockCollision.enabled = true;
		goalBox.enabled = true;
		goalBox.enabled = false;
	//	showKey ();
	//	showLock ();
	//	hideGoal();
	
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		hideKey();
		goalBox.enabled = true;
		hideLock(); //in future this could set lock disappear animation
	}

	void hideKey()
	{
		Color tmp = GetComponent<SpriteRenderer>().color;
		tmp.a = 0f;
		GetComponent<SpriteRenderer>().color = tmp;	
		lockCollision.enabled = false;
	}

	void showKey()
	{
		Color tmp = GetComponent<SpriteRenderer>().color;
		tmp.a = 1f;
		GetComponent<SpriteRenderer>().color = tmp;	
		lockCollision.enabled = false;
	}
	/*
	void hideGoal()
	{
		Color tmp = goalSprite.color;
		tmp.a = 0f;
		goalSprite.color = tmp;
	}
	*/

	void hideLock()
	{
		Color tmp = lockSprite.color;
		tmp.a = 0f;
		lockSprite.color = tmp;

		goalSprite.sprite = doorToLeaveOpen;
	}

	void showLock()
	{
		Color tmp = lockSprite.color;
		tmp.a = 1f;
		lockSprite.color = tmp;
	}

	/*
	void showGoal()
	{

		Color tmp = goalSprite.color;
		tmp.a = 1f;
		goalSprite.color = tmp;

		goalBox.enabled = true;
	}
	*/




}
