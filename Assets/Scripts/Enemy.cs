using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Projectile behavior
/// </summary>
public class Enemy : MonoBehaviour
{
	// 1 - Designer variables
	
	/// <summary>
	/// Damage inflicted
	/// </summary>
	public int damage = 1;

	
	void Start()
	{
		// 2 - Limited time to live to avoid any leak
		Destroy(gameObject, 20); // 20sec
	}
}