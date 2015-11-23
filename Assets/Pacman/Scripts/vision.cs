using UnityEngine;
using System.Collections;

public class vision : MonoBehaviour {

	public NPCmovement objectMovement;


	void OnTriggerEnter(Collider other)
	{
		
		if (other.gameObject.name == "pacman")
		{
			Debug.Log("enters");


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
			Debug.Log("exits");
			objectMovement.Invoke ("ResumeStatus", 0);
		}
				
	}
}
