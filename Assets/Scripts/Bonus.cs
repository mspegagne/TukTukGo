using UnityEngine;
using System.Collections;
using System;

public class Bonus : MonoBehaviour
{
	
	public SpriteRenderer sprite;
	public int points;
	
	
	void Start()
	{
		Destroy(gameObject, 20);
	}
	
	void Update()
	{		
		sprite = GetComponent<SpriteRenderer>();
		sprite.sortingOrder = Convert.ToInt32(Math.Floor(-transform.position.y * 10));
	}

}