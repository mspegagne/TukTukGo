using UnityEngine;
using System.Collections;
using System;

public class Back : MonoBehaviour
{
	
	void Start()
	{
		Destroy(gameObject, 60);
	}
}