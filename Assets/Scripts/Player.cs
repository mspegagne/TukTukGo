using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Player controller and behavior
/// </summary>
public class Player : MonoBehaviour
{
	public Vector2 jumpForce = new Vector2(0, 300);

	
	void Update()
	{

			// Jump
			if (Input.GetKeyUp("space"))
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
		
		// End of the update method
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag ("Enemy")) {
			Health playerHealth = this.GetComponent<Health> ();
			if (playerHealth != null)
				playerHealth.Damage (1);
		}


	}



	
}