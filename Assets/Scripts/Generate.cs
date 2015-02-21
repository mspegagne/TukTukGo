using UnityEngine;
using System.Collections;
using System;

public class Generate : MonoBehaviour
{
	public Enemy moto;
	public Enemy bus;
	public Enemy adulte;
	public Enemy camion1;		
	public Enemy camion2;
	public Enemy enfant;
	public Enemy trou;
	public Enemy vache;	
	public Enemy obstacle;	
	private bool isSpawning = false;

	void Update()
	{
		if (! isSpawning) {
			isSpawning = true; 
			float difficult = 3.2f - Coeff();	
			StartCoroutine (CreateObstacle(difficult));	
			Debug.Log (difficult);
		}
	}

	float Coeff()
	{
		float score = Player.points;
		float coeff = 0f;
		if ((score > 100) && (score <= 300)){
			coeff = 0.3f;
		}		
		if ((score > 300) && (score <= 800)){
			coeff = 0.8f;
		}
		if ((score > 800) && (score <= 1200)){
			coeff = 1.2f;
		}
		if ((score > 800) && (score <= 1200)){
			coeff = 1.5f;
		}
		if ((score > 1200) && (score <= 1700)){
			coeff = 1.8f;
		}
		if ((score > 1700) && (score <= 2300)){
			coeff = 2.1f;
		}
		if (score > 2300){
			coeff = 2.5f;
		}
		return coeff;

	}
	
	IEnumerator CreateObstacle(float difficult)
	{
		System.Random rnd = new System.Random();
		int type = rnd.Next(1, 9);
		int bottom = rnd.Next(1, 5);
		float position = rnd.Next(-4, -1);
		if (bottom == 1)
			position = -4;

		switch (type) {
		case 1 :
			obstacle = moto;
			break;
		case 2 :
			obstacle = bus;
			position += 0.5f;
			break;
		case 3 :
			obstacle = adulte;
			break;
		case 4 :
			obstacle = camion1;			
			position += 0.5f;
			break;
		case 5 :
			obstacle = camion2;
			position += 0.5f;	
			break;
		case 6 :
			obstacle = enfant;	
			break;
		case 7 :
			obstacle = trou;	
			position += 0.3f;	
			break;
		default :
			obstacle = vache;			
			position += 0.52f;	
			break;
		}
		
			yield return new WaitForSeconds(difficult);
			Instantiate (obstacle, new Vector3 (10, position, 5), Quaternion.identity);		
			isSpawning = false;

	}
}