using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Projectile behavior
/// </summary>
public class Back : MonoBehaviour
{
	
	void Start()
	{
		Destroy(gameObject, 20); // 20sec
	}
}