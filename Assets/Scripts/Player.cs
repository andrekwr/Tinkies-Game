using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float maxJumpHeight;
	public float minJumpHeight;
	public float timeToJumpApex;
	float accelerationTimeAirborne;
	float accelerationTimeGrounded;
	float moveSpeed;

	float gravity;
	float maxJumpVelocity;
	float minJumpVelocity;
	public Vector3 velocity;
	float velocityXSmoothing;

	public float hangTime;
	private float hangCounter;
	public float jumpBufferLength;
	private float jumBufferCount;

	public Controller2d controller;

	float inputx;
	Vector2 oldInput;

	private InputListener IL;

	void Start()
	{
		IL = GetComponent<InputListener>();
		controller = GetComponent<Controller2d>();

		moveSpeed = 7;
		maxJumpHeight = 6;
		minJumpHeight = 1f;
		accelerationTimeAirborne = 0.2f;
		accelerationTimeGrounded = 0.1f;
		hangTime = 0.2f;
		jumpBufferLength = 0.1f;
		gravity = -55;

		maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
		
	}

	void Update()
	{
		MovePlayer();
	}

	void Flip(){
		if (inputx > 0){
			gameObject.GetComponent<SpriteRenderer>().flipX = true;
			GetComponent<Animator>().SetBool("Walk", true);
		}
		else if (inputx == -1){
			gameObject.GetComponent<SpriteRenderer>().flipX = false;
			GetComponent<Animator>().SetBool("Walk", true);
		}
		else{
			GetComponent<Animator>().SetBool("Walk", false);
		}
	}

	public virtual void MovePlayer(){
		//coyote time
		if (controller.collisions.below)
		{
			hangCounter = hangTime;
		}
		else
		{
			hangCounter -= Time.deltaTime;
		}

		//jump buffer
		if (IL.jump)
		{
			jumBufferCount = jumpBufferLength;
			IL.jump = false;
		}
		else
		{
			jumBufferCount -= Time.deltaTime;
		}
		
		int left = IL.left ? 1 : 0;
		int right = IL.right ? 1 : 0;
		inputx = right - left;

		if (IL.rightRelease || IL.leftRelease){
			IL.rightRelease = false;
			IL.leftRelease = false;
			inputx = 0;
		}
		Flip();


		if (jumBufferCount >= 0 && hangCounter > 0f && velocity.y <= 0)
		{
			velocity.y = maxJumpVelocity;
			jumBufferCount = 0;
		}
		if (IL.jumpRelease && velocity.y > 0)
		{
			hangCounter = -1;
			//adjustable jump
			if (velocity.y > minJumpVelocity)
			{
				velocity.y = minJumpVelocity;
			}
			IL.jumpRelease = false;
		}
		IL.jumpRelease = false;
		float targetVelocityX = inputx * moveSpeed;
		velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);

		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);
	}
}
