using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {

	// Variables
	public Animator anim;                       // Refrerence to the animator
	private float fallSpeed;                     // The speed the character falls
	private float verticalMovement;         // The amount of vertical movement
	private bool onGround;                    // Flag to check if the character is on the ground

	// Use this for initialization
	void Start () {
		// The character starts on the ground
		onGround = true;

		// Set the fall speed
		fallSpeed = 0.03f;
	}
	
	// Update is called once per frame
	void Update () {

		// If the space bar is pressed and the character is on the ground
		if (Input.GetKeyDown(KeyCode.Space) == true && onGround == true)
		{
			verticalMovement = 1f;
			onGround = false;
		}
		else
		{
			// Check if the character is in the air and the vertical movement greater than 0
			if(onGround == false && verticalMovement > 0)
			{
				// Reduce vertical movement
				verticalMovement -= fallSpeed;

				// If the vertical movement is less or equal to 0, the character is on the floor
				if (verticalMovement < 0)
				{
					verticalMovement = 0;
					onGround = true;
				}
			}
		}

		// Update the animator variables
		anim.SetFloat("VerticalMovement", verticalMovement);
		anim.SetBool("OnGround", onGround);
	}
}
