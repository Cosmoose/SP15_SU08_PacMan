using UnityEngine;
using System.Collections;

public class SentinelMovement : NPCmovement {

	NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		
		ghostPoints = GameObject.FindGameObjectsWithTag("corridorPoint");
		pacman = GameObject.Find ("pacman");
		InvokeRepeating ("Patrol", 0, 15);	
		agent = gameObject.GetComponent <NavMeshAgent> ();
	}

	
	void RepeatHunt ()
	{
		Debug.Log ("what1");
		CancelInvoke ();
		Invoke ("HuntPacman", 0);
		agent.speed = 120;
	}

	void RepeatRun ()
    {
        CancelInvoke();
        Invoke("HuntPacman", 0);
        agent.speed = 120;
    }

	void ResumeStatus ()
	{
		Debug.Log ("what3");
		CancelInvoke ();
		InvokeRepeating ("Patrol", 0, 15);
		agent.speed = 60;
	}


}
