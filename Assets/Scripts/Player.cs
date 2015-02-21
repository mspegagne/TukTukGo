using UnityEngine;
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
	
	private SpriteRenderer sprite;

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
			
		sprite = GetComponent<SpriteRenderer>();
		sprite.sortingOrder = Convert.ToInt32(Math.Floor(-transform.position.y * 10));


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