using UnityEngine;
using System.Collections;

public class vision : MonoBehaviour {

	public NPCmovement objectMovement;
    public bool sees ;


    void Start ()
    {
        sees = false;
    }

	void OnTriggerEnter(Collider other)
	{
		
		if (other.gameObject.name == "pacman")
		{
			Debug.Log("enters");

            sees = true;
			if (other.gameObject.tag == "hunting")
			{
				objectMovement.Invoke ("RepeatRun", 0);
			}
			else
			{
				objectMovement.Invoke ("RepeatHunt",0);
			}

		} 


	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "pacman")
		{
            sees = false;
			Debug.Log("exits");
			objectMovement.Invoke ("ResumeStatus", 0);
		}
				
	}
}
