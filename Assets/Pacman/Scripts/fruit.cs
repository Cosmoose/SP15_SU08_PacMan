using UnityEngine;
using System.Collections;

public class fruit : NPCmovement {

	float spawnTime;

	// Use this for initialization
	void Start () {

		spawnTime = 10;
		Invoke ("destroy", spawnTime);
		ghostPoints = GameObject.FindGameObjectsWithTag("point");
		InvokeRepeating ("StumbleAround", 1, 3);

	}


	void destroy ()
	{
		Destroy (gameObject, 0f);
	}


}
