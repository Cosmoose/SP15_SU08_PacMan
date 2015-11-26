using UnityEngine;
using System.Collections;

public class GhostMovementNav : NPCmovement {

	GameObject eye;
    Animator ghostani;
    ObjectsScript OS;
    GameObject pac;

	void Start ()
	{

		ghostPoints = GameObject.FindGameObjectsWithTag("point");
		pacman = GameObject.Find ("pacman");
		InvokeRepeating ("StumbleAround", 1, 6);
        ghostani = GetComponent<Animator>();
        ghostani.Play("Run");
        //OS = FindObjectOfType<>;
	}
    /*
    void Update()
    {



        if (OS.hunting == true)
        {
            ghostani.Play("Hunted");
        }
        else
        {
            ghostani.Play("Run");
        }
    }*/

    void RepeatHunt ()
	{
		CancelInvoke ();
		InvokeRepeating ("HuntPacman", 0, 0.5f);
	}

	void ResumeStatus ()
	{
		CancelInvoke ();
		InvokeRepeating ("StumbleAround", 1, 6);
	}

	void RepeatRun ()
	{
		CancelInvoke ();
		InvokeRepeating ("RunFromPacman", 0, 2);
	}

}
