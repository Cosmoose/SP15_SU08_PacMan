﻿using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {
	public int code;
	float disableTimer=0;

	void Update(){
		if (disableTimer > 0)
			disableTimer -= Time.deltaTime;
	}

	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.name=="pacman" && disableTimer<=0){

			foreach(Teleport tp in FindObjectsOfType<Teleport>()){

				if (tp.code==code && tp != this){
					tp.disableTimer=2;
					Vector3 position=tp.gameObject.transform.position; 
					position.y= -55.85f;
					collider.gameObject.transform.position=position;
				}
			}

		}
	}

}
