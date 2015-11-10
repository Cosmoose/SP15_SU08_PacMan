﻿using UnityEngine;
using System.Collections;

public class EatOrEaten : MonoBehaviour {

	public GameObject deadGhost;
	public GameObject ghost;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision coll)
	{
		if(coll.gameObject.tag == "Untagged")
		{
			Destroy(coll.gameObject);
		}
		else if (coll.gameObject.tag == "hunting")
		{
			Destroy(ghost,0f);
			Instantiate (deadGhost, transform.position, Quaternion.identity);
		}
	}
}
