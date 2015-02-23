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
	public Bonus bidon;
	public Bonus riz;	
	public Bonus bonus;	
	private bool isSpawning = false;


	void Start()
	{
		CreateObstacleVoid();		
		InvokeRepeating("Bonus", 10f, 20f);
			
	}

	void Update()
	{
		if (! isSpawning) {
			isSpawning = true; 
			float difficult = 2.7f - Coeff();	
			StartCoroutine (CreateObstacle(difficult));	
		}
	}

	float Coeff()
	{
		float score = Player.points;
		float coeff = 0f;
		if (score <1000){
			coeff = score/1000;
		}
		if ((score > 100) && (score <= 2500)){
			coeff = 1+((score-1000)/1500);
		}
		if (score > 2500){
			coeff = 2f;
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
			position -= 0.5f;	
			break;
		default :
			obstacle = vache;			
			position += 0.52f;	
			break;
		}
		
			yield return new WaitForSeconds(difficult);
			Instantiate (obstacle, new Vector3 (0, position, 5), Quaternion.identity);		
			isSpawning = false;

	}

	void CreateObstacleVoid()
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
			position -= 0.5f;	
			break;
		default :
			obstacle = vache;			
			position += 0.52f;	
			break;
		}
		

		Instantiate (obstacle, new Vector3 (0, position, 5), Quaternion.identity);	
		
	}

	void Bonus()
	{
		System.Random rnd = new System.Random();
		int type = rnd.Next(1, 3);
		int bottom = rnd.Next(1, 5);
		float position = rnd.Next(-4, -1);
		if (bottom == 1)
			position = -4;
		
		switch (type) {
		case 1 :
			bonus = riz;			
			position -= 0.5f;	
			break;
		default :
			bonus = bidon;			
			position -= 0.5f;	
			break;
		}
		
		
		Instantiate (bonus, new Vector3 (0, position, 5), Quaternion.identity);	

	}

}