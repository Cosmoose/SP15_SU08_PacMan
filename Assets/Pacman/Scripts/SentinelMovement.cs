using UnityEngine;
using System.Collections;

public class SentinelMovement : NPCmovement {

	NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		
		ghostPoints = GameObject.FindGameObjectsWithTag("corridorPoint");
		pacman = GameObject.Find ("pacman");
		InvokeRepeating ("Patrol", 0, 9);	
		agent = gameObject.GetComponent <NavMeshAgent> ();
	}

	
	void RepeatHunt ()
	{
		Debug.Log ("what");
		CancelInvoke ();
		Invoke ("HuntPacman", 0);
		agent.speed = 10;
	}

	void RepeatRun () // sentineln har ingen fruktan och jagar alltid pacman
	{
		Debug.Log ("what");
		CancelInvoke ();
		Invoke ("HuntPacman", 0);
		agent.speed = 10;
	}

	void ResumeStatus ()
	{
		Debug.Log ("what");
		CancelInvoke ();
		InvokeRepeating ("Patrol", 0, 9);
		agent.speed = 3.5f;
	}


}
