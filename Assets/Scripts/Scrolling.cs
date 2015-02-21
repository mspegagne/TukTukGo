using UnityEngine;
using System.Collections;
using System;


public class Scrolling : MonoBehaviour
{
	
	public Back back1;
	public Back back2;
	public Back back3;
	public Back back4;
	public Back back;

	void Start()
	{
		InvokeRepeating("CreateBack", 10f, 20f);
	}
	
	void CreateBack()
	{
		System.Random rnd = new System.Random();
		int type = rnd.Next(1, 5);

		switch (type) {
		case 1 :
			back = back1;
			break;
		case 2 :
			back = back2;
			break;
		case 3 :
			back = back3;
			break;
		default :
			back = back4;
			break;
		}
		
		Instantiate(back, new Vector3(50, 0, 5), Quaternion.identity);		
		Instantiate(back, new Vector3(100, 0, 5), Quaternion.identity);
		
		
	}
}