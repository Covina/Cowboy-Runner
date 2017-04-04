using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour {

	// move to the left (negative side)
	private float obstacleSpeed = -3f;

	private Rigidbody2D rigidBody;


	void Awake ()
	{

		// get the rigidbody of the obstacle
		rigidBody = GetComponent<Rigidbody2D>();


	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// move the object to the left
		rigidBody.velocity = new Vector2(obstacleSpeed, 0f);

		
	}
}
