using UnityEngine;
using System.Collections;

public class GhostMovementNav : NPCmovement {

	GameObject eye;

	void Start ()
	{

		ghostPoints = GameObject.FindGameObjectsWithTag("point");
		pacman = GameObject.Find ("pacman");
		InvokeRepeating ("StumbleAround", 1, 3);
		//StartCoroutine ("MyCoroutine");

	}

	void RepeatHunt ()
	{
		CancelInvoke ();
		InvokeRepeating ("HuntPacman", 0, 1);
	}

	void ResumeStatus ()
	{
		CancelInvoke ();
		InvokeRepeating ("StumbleAround", 1, 3);
	}

	void RepeatRun ()
	{
		CancelInvoke ();
		InvokeRepeating ("RunFromPacman", 0, 2);
	}


}
