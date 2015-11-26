using UnityEngine;
using System.Collections;

public class Lajka : NPCmovement {

	// Use this for initialization
	void Start () {

		ghostPoints = GameObject.FindGameObjectsWithTag("point");
		pacman = GameObject.Find ("pacman");
	
	}

	void RepeatHunt ()
	{
		CancelInvoke ();
		InvokeRepeating ("HuntPacman", 0, 0.1f);
	}

	void RepeatRun ()
	{
		CancelInvoke ();
		InvokeRepeating ("RunFromPacman", 0, 4);
	}

	void ResumeStatus ()
	{
		CancelInvoke ();
		Debug.Log ("woof");
	}
	
}