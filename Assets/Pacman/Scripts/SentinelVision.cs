using UnityEngine;
using System.Collections;

public class SentinelVision : MonoBehaviour {

	public NPCmovement objectMovement;
	public GameObject Sentinel;


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == Sentinel)
		{
			objectMovement = Sentinel.gameObject.GetComponent<NPCmovement>();
		}
		
		
	}

	void OnTriggerStay (Collider other)
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
		if (other.gameObject == Sentinel)
		{
			objectMovement = null;
		}
		if (other.gameObject.name == "pacman")
		{
			Debug.Log("exits");
			objectMovement.Invoke ("ResumeStatus", 0);
		}
		
	}
}
