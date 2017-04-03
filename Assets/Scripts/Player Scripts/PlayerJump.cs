using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerJump : MonoBehaviour {

	[SerializeField] private AudioClip jumpSFX;

	// Movement affectors
	private float jumpForce = 12f, forwardForce = 0f;

	// Get the player body to move
	private Rigidbody2D rigidBody;

	// Enable/disable jump
	private bool canJump;

	// The jump button to wire up
	private Button jumpButton;


	// Use this for initialization
	void Start () {

		// get the Rigidbody2D
		rigidBody = GetComponent<Rigidbody2D>();

		// get the jump button
		jumpButton = GameObject.Find("Jump Button").GetComponent<Button>();

		// programmatically add the OnClick event
		jumpButton.onClick.AddListener( () => Jump() );


	}
	
	// Update is called once per frame
	void Update ()
	{

		// detect if the player is not flying through the air from a previous jump
		if (Mathf.Abs (rigidBody.velocity.y) == 0) {

			// playe is now eligble for jumping
			canJump = true;

		}


	}


	// Create the jump functionality
	public void Jump ()
	{

		if (canJump) {
			canJump = false;

			// if the player is on the left side of the screen, they will jump forward too.
			if (transform.position.x < 0) {

				forwardForce = 1f;

			} else {

				// too far forward so no forward force.
				forwardForce = 0f;
			}

			// play the audio clip for jumping
			AudioSource.PlayClipAtPoint(jumpSFX, transform.position);

			// move the player
			rigidBody.velocity = new Vector2(forwardForce, jumpForce);


		}



	}


}
