﻿using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Player controller and behavior
/// </summary>
public class Player : MonoBehaviour
{
	public Vector2 jumpForce = new Vector2(0, 300);

	public static int points = 0;

	public static int highscore = 0;

	void Start()
	{
		InvokeRepeating("addPoints", 1f, 1f);
		highscore = PlayerPrefs.GetInt("High Score");
	}

	void Update()
	{

			// Jump
			if (Input.GetKeyUp("space") || Input.GetMouseButtonDown(0))
			{
				rigidbody2D.velocity = Vector2.zero;
				rigidbody2D.AddForce(jumpForce);
			}

		
		// 6 - Make sure we are not outside the camera bounds
		var dist = (transform.position - Camera.main.transform.position).z;
		
		var leftBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).x;
		
		var rightBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(1, 0, dist)
			).x;
		
		var topBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).y;
		
		var bottomBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 1, dist)
			).y;
		
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
			transform.position.z
			);

	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag ("Enemy")) {
			Health playerHealth = this.GetComponent<Health> ();
			if (playerHealth != null)
				playerHealth.Damage (1);
		}


	}

	void addPoints()
	{
		points += 10;
	}



	void OnDestroy()
	{
		// Game Over.
		// Add the script to the parent because the current game
		// object is likely going to be destroyed immediately.
		if(points > highscore) //when player dies set highscore = to that score
		{
			highscore = points;
			PlayerPrefs.SetInt("High Score", highscore);
			
			Debug.Log("High Score is " + highscore );
			
		}    
		transform.parent.gameObject.AddComponent<GameOver>();
	}


	
}