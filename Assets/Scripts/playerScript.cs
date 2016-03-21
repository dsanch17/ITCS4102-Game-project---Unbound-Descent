using UnityEngine;
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

	float moveX;
	//float moveY;
	float jumpX;
	float jumpY;

	bool flippedSprite;

	Vector2 gravity;

	bool gravUp;
	bool gravDown;
	bool gravLeft;
	bool gravRight;

	public float moveForce;

	void Start () {

		if (SceneManager.GetActiveScene ().name.Equals ("prototypeLevel2")) {
			gravDown = true;
			facingDirection = 1f;
			flippedSprite = false;
		} else {
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
			SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
		}

        if (freyaHitbox.IsTouchingLayers(LayerMask.GetMask("Win"))) {
            SceneManager.LoadScene("Win");
        }


        onGround = freyaFeetBox.IsTouchingLayers (LayerMask.GetMask("Platforms"));

		if (!onGround)
			moveDistance = airSpeedMultiplier * moveSpeed;
		else
			moveDistance = moveSpeed;

		//getkey is true if held down
		//getkeydown is true once per press
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



		//call function to set gravity flags
		setGravity ();



		moveForce = moveDistance * moveInput;


		//call function to set movement values reletive to current gravity
		setMovementRelative ();
		setAnimatorFlags ();

		if (moveInput == 1 || moveInput == -1)
			freyaMove ();
		//move and jump in the relative directions




		if (jumpInput && onGround)
			freyaBody.AddForce(new Vector2(jumpX, jumpY));



		//flip sprite if the moving direciont has changed
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


	void setGravity()
	{
		// gravity flags and model rotation
		if (gravUp == false && onGround && Input.GetKeyDown (KeyCode.W)) {
            GetComponent<AudioSource>().Play();
			gravUp = true;
			gravDown = false;
			gravLeft = false; 
			gravRight = false;
			transform.eulerAngles = new Vector3(0, 0, 180f);
			if (flippedSprite == false)
				freyaSpriteRenderer.flipX = !freyaSpriteRenderer.flipX;
			flippedSprite = true;
		}

		if (gravDown == false && onGround && Input.GetKeyDown (KeyCode.S)) {
            GetComponent<AudioSource>().Play();
            gravUp = false;
			gravDown = true;
			gravLeft = false; 
			gravRight = false;
			transform.eulerAngles = new Vector3(0, 0, 0);
			if (flippedSprite == true)
				freyaSpriteRenderer.flipX = !freyaSpriteRenderer.flipX;
			flippedSprite = false;

		}

		if (gravLeft == false && onGround && Input.GetKeyDown (KeyCode.A)) {
            GetComponent<AudioSource>().Play();
            gravUp = false;
			gravDown = false;
			gravLeft = true; 
			gravRight = false;
			transform.eulerAngles = new Vector3(0, 0, 270f);
			if (flippedSprite == true)
				freyaSpriteRenderer.flipX = !freyaSpriteRenderer.flipX;
			flippedSprite = false;

		}

		if (gravRight == false && onGround && Input.GetKeyDown (KeyCode.D)) {
            GetComponent<AudioSource>().Play();
            gravUp = false;
			gravDown = false;
			gravLeft = false; 
			gravRight = true;
			transform.eulerAngles = new Vector3(0, 0, 90f);
			if (flippedSprite == false)
				freyaSpriteRenderer.flipX = !freyaSpriteRenderer.flipX;
			flippedSprite = true;

		}
	}

	void setMovementRelative() 
	{

		if (gravDown) {
			moveX = moveForce;
			//moveY = 0;
			jumpX = 0;
			jumpY = jumpForce;
		}

		else if (gravUp) {
			moveX = moveForce * -1;
			//moveY = 0;
			jumpX = 0;
			jumpY = jumpForce * -1;
		}

		else if (gravLeft) {
			moveX = moveForce;
			//moveY = 0;
			jumpX = jumpForce;
			jumpY = 0;
		}

		else if (gravRight) {
			moveX = moveForce * -1;
			//moveY = 0;
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

}