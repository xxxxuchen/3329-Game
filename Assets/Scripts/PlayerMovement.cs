using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController controller;
    public Animator animator;

	public float runSpeed = 100f;

	float horizontalMove = 0f;
	bool jump = false;
	
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			animator.SetBool("IsJumping", true);
			jump = true;
		}
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
		jump = false;
	}

    public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
	}

}