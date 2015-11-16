using UnityEngine;
using System.Collections;

public class vision : MonoBehaviour {
	
	public GhostMovementNav ghostMovement;
	
	void OnTriggerEnter(Collider other)
	{
		
		if (other.gameObject.name == "pacman")
		{
			Debug.Log("enters");
			ghostMovement.spotted = true;

			if (other.gameObject.tag == "hunting")
			{
				ghostMovement.hunted = true;
			}
		} 
		
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "pacman")
		{
			Debug.Log("exits");
			ghostMovement.spotted = false;

			if (other.gameObject.tag == "hunting")
			{
				ghostMovement.hunted = false;
			}
		}
		
	}
}
