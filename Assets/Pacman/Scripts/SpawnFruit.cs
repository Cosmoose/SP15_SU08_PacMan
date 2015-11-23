using UnityEngine;
using System.Collections;

public class SpawnFruit : NPCmovement {

	public GameObject fruit;
	GameObject fruitSpawn;

	// Use this for initialization
	void Start () {


		InvokeRepeating ("SpawnIt", 30, 40);
		ghostPoints = GameObject.FindGameObjectsWithTag("point");
	
	}
	



	void SpawnIt ()
	{

		index = Random.Range (0, ghostPoints.Length);


		fruitSpawn = ghostPoints [index];


		Instantiate (fruit, fruitSpawn.transform.position, Quaternion.identity);
	}
}
