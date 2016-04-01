﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class playerScript : MonoBehaviour {

	public Rigidbody2D freyaBody;
	public Animator freyaAnimator;
	public SpriteRenderer freyaSpriteRenderer;
	public PolygonCollider2D freyaHitbox;
	public BoxCollider2D freyaFeetBox;



	public float moveSpeed = .04f;	
	public float airSpeedMultiplier = .8f;
	public float jumpForce = 200f;

	float moveDistance;

	float moveInput;
	bool jumpInput;

	float facingDirection;
	bool onGround;
	bool onMovingPlatform;

	float moveX;
	float jumpX;
	float jumpY;

	bool flippedSprite;

	Vector2 gravity;

	public float moveForce;

	bool gravUp;
	bool gravDown;
	bool gravLeft;
	bool gravRight;

	void Start () {

		if (SceneManager.GetActiveScene ().buildIndex == 2) {
			gravityController.setGravDown ();
			gravDown = true;
			facingDirection = 1f;
			flippedSprite = false;
		} else {
			gravityController.setGravUp ();
			gravUp = true;
			facingDirection = 1f;
			flippedSprite = true;
		}

		
	}
	
	void Update () {

		//reset input variables
		moveInput = 0;
		moveForce = 0;
		moveDistance = 0;
		jumpInput = false;
			

		if (freyaHitbox.IsTouchingLayers (LayerMask.GetMask("Death"))) { 
			restartLevel ();
		}

		onGround = (freyaFeetBox.IsTouchingLayers (LayerMask.GetMask("Platforms")) || onMovingPlatform);

		if (!onGround)
			moveDistance = airSpeedMultiplier * moveSpeed;
		else
			moveDistance = moveSpeed;

		//parse input and set base movement variables
		movementInput();

		detectGravityChange ();
		updateLocalGravVariables (); //important that this comes after the change detection

		moveForce = moveDistance * moveInput;

		//call function to set movement values reletive to current gravity
		setMovementRelative ();
		setAnimatorFlags ();

		if (moveInput == 1 || moveInput == -1)
			freyaMove ();


		if (jumpInput && onGround)
			freyaBody.AddForce(new Vector2(jumpX, jumpY));



		//flip sprite if the moving direction has changed
		if (moveInput != facingDirection && moveInput != 0) {
			freyaSpriteRenderer.flipX = !freyaSpriteRenderer.flipX;
			facingDirection = moveInput;
		}




	}

	//fixedUpdate is called every physics step
	//anything that affects the physics should occur inside it
	void FixedUpdate()
	{
		Physics2D.gravity = gravity;

		//updates based on gravity flags
		gravityUpdate ();
	}

	void gravityUpdate() {
		if (gravUp) {
			gravity.x = 0;
			gravity.y = 9.8f;
		}

		if (gravDown) {
			gravity.x = 0;
			gravity.y = -9.8f;
		}

		if (gravRight) {
			gravity.x = 9.8f;
			gravity.y = 0;
		}

		if (gravLeft) {
			gravity.x = -9.8f;
			gravity.y = 0;
		}
	}

	void setGravityUp() {
		gravityController.setGravUp();
		transform.eulerAngles = new Vector3(0, 0, 180f);
		if (flippedSprite == false)
			freyaSpriteRenderer.flipX = !freyaSpriteRenderer.flipX;
		flippedSprite = true;
	}

	void setGravityDown() {
		gravityController.setGravDown ();
		transform.eulerAngles = new Vector3 (0, 0, 0);
		if (flippedSprite == true)
			freyaSpriteRenderer.flipX = !freyaSpriteRenderer.flipX;
		flippedSprite = false;
	}

	void setGravityLeft() {
		gravityController.setGravLeft ();
		transform.eulerAngles = new Vector3 (0, 0, 270f);
		if (flippedSprite == true)
			freyaSpriteRenderer.flipX = !freyaSpriteRenderer.flipX;
		flippedSprite = false;
	}

	void setGravityRight() {
		gravityController.setGravRight ();
		transform.eulerAngles = new Vector3 (0, 0, 90f);
		if (flippedSprite == false)
			freyaSpriteRenderer.flipX = !freyaSpriteRenderer.flipX;
		flippedSprite = true;
	}
		
		
	void detectGravityChange()
	{
		// gravity flags and model rotation
		if (gravUp == false && ((onGround && Input.GetKeyDown (KeyCode.W)) || (gravityController.gravUp == true && gravUp == false))) {
			setGravityUp();
			GetComponent<AudioSource>().Play(); //should move audio sources into another gameObject and make them public
		}

		else if (gravDown == false && ((onGround && Input.GetKeyDown (KeyCode.S)) || (gravityController.gravDown == true && gravDown == false))) {
			setGravityDown ();
			GetComponent<AudioSource>().Play();
		}

		else if (gravLeft == false && ((onGround && Input.GetKeyDown (KeyCode.A)) || (gravityController.gravLeft == true && gravLeft == false))) {
			setGravityLeft();
			GetComponent<AudioSource>().Play();
		}

		else if (gravRight == false && ((onGround && Input.GetKeyDown (KeyCode.D)) || (gravityController.gravRight == true && gravRight == false))) {
			setGravityRight ();
			GetComponent<AudioSource>().Play();
		}
	}

	void updateLocalGravVariables() {
		gravUp = gravityController.gravUp;
		gravDown = gravityController.gravDown;
		gravLeft = gravityController.gravLeft;
		gravRight = gravityController.gravRight;
	}


	void movementInput() {
		if (Input.GetKey (KeyCode.RightArrow) && (gravDown || gravUp))
			moveInput = 1f;

		if (Input.GetKey (KeyCode.LeftArrow) && (gravDown || gravUp))
			moveInput = -1f;

		if (Input.GetKey (KeyCode.UpArrow) && (gravLeft || gravRight))
			moveInput = -1f;

		if (Input.GetKey (KeyCode.DownArrow) && (gravLeft || gravRight))
			moveInput = 1f;

		if (Input.GetKeyDown (KeyCode.Space))
			jumpInput = true;
	}

	void setMovementRelative() 
	{

		if (gravDown) {
			moveX = moveForce;
			jumpY = jumpForce;
			jumpX = 0;
		}

		else if (gravUp) {
			moveX = moveForce * -1;
			jumpY = jumpForce * -1;
			jumpX = 0;
		}

		else if (gravLeft) {
			moveX = moveForce;
			jumpX = jumpForce;
			jumpY = 0;
		}

		else if (gravRight) {
			moveX = moveForce * -1;
			jumpX = jumpForce * -1;
			jumpY = 0;
		}


	}

	void setAnimatorFlags() {
		freyaAnimator.SetBool ("Walk", moveInput != 0);

		freyaAnimator.SetBool ("Jump", jumpInput);

		freyaAnimator.SetBool ("Grounded", onGround);
	}

	void freyaMove() {
		freyaBody.transform.Translate (new Vector3 (moveX, 0, 0));
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag == "movingPlatform")
        {
            transform.parent = other.transform;
			onMovingPlatform = true;
        }
    }

	void restartLevel() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "movingPlatform")
        {
			onMovingPlatform = false;
            transform.parent = null;
        }
    }

}