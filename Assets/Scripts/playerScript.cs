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
	bool onMovingPlatform;

	float moveX;
	float jumpY;

	bool flippedSprite;

	Vector2 gravity;


	public float moveForce;

	void Start () {

		if (SceneManager.GetActiveScene ().name.Equals ("prototypeLevel2")) {
			gravityController.setGravDown ();
			facingDirection = 1f;
			flippedSprite = false;
		} else {
			gravityController.gravUp = true;
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

		//call function to set gravity flags
		setGravity ();

		moveForce = moveDistance * moveInput;

		//call function to set movement values reletive to current gravity
		setMovementRelative ();
		setAnimatorFlags ();

		if (moveInput == 1 || moveInput == -1)
			freyaMove ();


		if (jumpInput && onGround)
			freyaBody.AddForce(new Vector2(0, jumpY));



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
		if (gravityController.gravUp) {
			gravity.x = 0;
			gravity.y = 9.8f;
		}

		if (gravityController.gravDown) {
			gravity.x = 0;
			gravity.y = -9.8f;
		}

		if (gravityController.gravRight) {
			gravity.x = 9.8f;
			gravity.y = 0;
		}

		if (gravityController.gravLeft) {
			gravity.x = -9.8f;
			gravity.y = 0;
		}
	}
		
	void setGravity()
	{
		// gravity flags and model rotation
		if (gravityController.gravUp == false && onGround && Input.GetKeyDown (KeyCode.W)) {
            GetComponent<AudioSource>().Play();
			gravityController.setGravUp();
			transform.eulerAngles = new Vector3(0, 0, 180f);
			if (flippedSprite == false)
				freyaSpriteRenderer.flipX = !freyaSpriteRenderer.flipX;
			flippedSprite = true;
		}

		else if (gravityController.gravDown == false && onGround && Input.GetKeyDown (KeyCode.S)) {
            GetComponent<AudioSource>().Play();
			gravityController.setGravDown ();
			transform.eulerAngles = new Vector3(0, 0, 0);
			if (flippedSprite == true)
				freyaSpriteRenderer.flipX = !freyaSpriteRenderer.flipX;
			flippedSprite = false;

		}

		else if (gravityController.gravLeft == false && onGround && Input.GetKeyDown (KeyCode.A)) {
            GetComponent<AudioSource>().Play();
			gravityController.setGravLeft ();
       		transform.eulerAngles = new Vector3(0, 0, 270f);
			if (flippedSprite == true)
				freyaSpriteRenderer.flipX = !freyaSpriteRenderer.flipX;
			flippedSprite = false;

		}

		else if (gravityController.gravRight == false && onGround && Input.GetKeyDown (KeyCode.D)) {
            GetComponent<AudioSource>().Play();
			gravityController.setGravRight ();
			transform.eulerAngles = new Vector3(0, 0, 90f);
			if (flippedSprite == false)
				freyaSpriteRenderer.flipX = !freyaSpriteRenderer.flipX;
			flippedSprite = true;

		}
	}

	void movementInput() {
		if (Input.GetKey (KeyCode.RightArrow) && (gravityController.gravDown || gravityController.gravUp))
			moveInput = 1f;

		if (Input.GetKey (KeyCode.LeftArrow) && (gravityController.gravDown || gravityController.gravUp))
			moveInput = -1f;

		if (Input.GetKey (KeyCode.UpArrow) && (gravityController.gravLeft || gravityController.gravRight))
			moveInput = -1f;

		if (Input.GetKey (KeyCode.DownArrow) && (gravityController.gravLeft || gravityController.gravRight))
			moveInput = 1f;

		if (Input.GetKeyDown (KeyCode.Space))
			jumpInput = true;
	}

	void setMovementRelative() 
	{

		if (gravityController.gravDown) {
			moveX = moveForce;
			jumpY = jumpForce;
		}

		else if (gravityController.gravUp) {
			moveX = moveForce * -1;
			jumpY = jumpForce * -1;
		}

		else if (gravityController.gravLeft) {
			moveX = moveForce;
			jumpY = 0;
		}

		else if (gravityController.gravRight) {
			moveX = moveForce * -1;
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