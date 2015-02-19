using UnityEngine;
using System.Collections;
using System;

public class Generate : MonoBehaviour
{
	public Enemy obstacle1;
	public Enemy obstacle2;
	public Enemy obstacle3;
	public Enemy obstacle4;	
	public Enemy obstacle;
	
	// Use this for initialization
	void Start()
	{
		InvokeRepeating("CreateObstacle", 1f, 2f);
	}
	
	void CreateObstacle()
	{
		System.Random rnd = new System.Random();
		int type = rnd.Next(1, 4);
		int bottom = rnd.Next(1, 5);
		int position = rnd.Next(-4, -1);
		if (bottom == 1)
			position = -4;

		switch (type) {
		case 1 :
			obstacle = obstacle1;
			break;
		case 2 :
			obstacle = obstacle2;
			break;
		case 3 :
			obstacle = obstacle3;
			break;
		default :
			obstacle = obstacle4;
			break;
		}

		Instantiate(obstacle, new Vector3(10, position, 0), Quaternion.identity);

	}
}