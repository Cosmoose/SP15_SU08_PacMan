using UnityEngine;
using System.Collections;

public class SentinelVision : MonoBehaviour {

	public SentinelMovement objectMovement;
	public GameObject Sentinel;


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "sentinel")
		{
          
			objectMovement = Sentinel.gameObject.GetComponent<SentinelMovement>();

		}
		
		
	}

	void OnTriggerStay (Collider other)
	{
		if (other.gameObject.name == "pacman")
		{
			if (objectMovement != null)
            {
                if (other.gameObject.tag == "hunting")
                {
                    objectMovement.Invoke("RepeatHunt", 0);
                }
                else
                {
                    objectMovement.Invoke("RepeatRun", 0);
                }
            }
		} 
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject == Sentinel)
		{
			objectMovement = null;
		}
		if (other.gameObject.name == "pacman" && objectMovement != null)
		{
			objectMovement.Invoke ("ResumeStatus", 0);
		}
		
	}
}
