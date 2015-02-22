using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour
{
	public int damage = 1;	
	
	private SpriteRenderer sprite;

	
	void Start()
	{
		Destroy(gameObject, 20); // 20sec
	}

	void Update()
	{

		
		sprite = GetComponent<SpriteRenderer>();
		sprite.sortingOrder = Convert.ToInt32(Math.Floor(-transform.position.y * 10));
		
		
	}

}