using UnityEngine;
using System.Collections;

public class NPCmovement : MonoBehaviour {

	public GameObject pacman;
	public GameObject[] ghostPoints;
	public int index = 0;
	GameObject currentDestination;
	GameObject choice;
	public GameObject ghost;
	public GameObject home;




	void HuntPacman () // Jaga pacman
	{
		
		NavMeshAgent agent = GetComponent<NavMeshAgent> ();
		agent.destination = pacman.transform.position;

	}


	void StumbleAround () // Gå runt på random
	{
		
		index = Random.Range (0, ghostPoints.Length);
		
		currentDestination = ghostPoints [index];

		NavMeshAgent agent = GetComponent<NavMeshAgent> ();
		agent.destination = currentDestination.transform.position;

	}


	public int patrolIndex ()
	{

		index += 1;

		if (index == ghostPoints.Length)
		{
			index = 0;
		}

		return index;
	}
	
	void Patrol () // Gå runt på random
	{
		index = patrolIndex ();
		Debug.Log (index);

		currentDestination = ghostPoints [index];

		NavMeshAgent agent = GetComponent<NavMeshAgent> ();
		agent.destination = currentDestination.transform.position;

	}

	void RunFromPacman () // fly från pacman
	{
		
		float distance = Mathf.Infinity;
		Vector3 ghostPosition = transform.position; // spökets position
		
		
		foreach (GameObject point in ghostPoints)
		{
			Vector3 ghostDiff = point.transform.position - ghostPosition; // tittar efter närmaste punkt relativt spöket
			Vector3 pacDiff = point.transform.position - pacman.transform.position; // tittar efter punkten närmast pacman
			float curDistance = ghostDiff.sqrMagnitude - pacDiff.sqrMagnitude; // jämför pacmans och spöket position 
			
			
			if (curDistance < distance)
			{
				choice = point; // den tittar alla punkter men den väljer punkten som är närmast spöket om den är längre från pacman än vad spöket är
				distance = curDistance;
			}
		}
		NavMeshAgent agent = GetComponent<NavMeshAgent> ();
		agent.destination = choice.transform.position;

	}



	void GoHome () // Spöket rör sig till spawnpoint
	{
		NavMeshAgent agent = GetComponent<NavMeshAgent> ();
		agent.destination = home.transform.position;
	}
}
