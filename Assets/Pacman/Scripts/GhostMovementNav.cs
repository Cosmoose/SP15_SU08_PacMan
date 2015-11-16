using UnityEngine;
using System.Collections;

public class GhostMovementNav : MonoBehaviour {

	public bool spotted;
	public bool hunted;
	GameObject pacman;
	public GameObject ghost;
	public GameObject[] ghostPoints;
	public int index;
	GameObject currentDestination;
	GameObject choice;


	// Use this for initialization
	void Start () {

		ghostPoints = GameObject.FindGameObjectsWithTag("point");
		pacman = GameObject.Find ("pacman");
	
	}
	
	// Update is called once per frame
	void Update () {

		if (spotted)
		{
			CancelInvoke ("StumbleAround");

			if (hunted)
			{
				InvokeRepeating ("RunFromPacman", 1f, 3f);
			}
			else
			{
				InvokeRepeating ("HuntPacman", 1f, 3f);
			}
		}
		else
		{
			CancelInvoke ("HuntPacman");
			InvokeRepeating ("StumbleAround", 3f, 9f);
		}
	
	}

	void HuntPacman ()
	{

		NavMeshAgent ghost = GetComponent<NavMeshAgent> ();
		ghost.destination = pacman.transform.position;

		CancelInvoke ("HuntPacman"); // används för att den inte ska köras kontinuerligt utan var tredje sekund.
	}

	void StumbleAround ()
	{

		index = Random.Range (0, ghostPoints.Length);

		currentDestination = ghostPoints [index];

		NavMeshAgent ghost = GetComponent<NavMeshAgent> ();
		ghost.destination = currentDestination.transform.position;

		CancelInvoke ("StumbleAround"); // gör så att currentPoint int förändras hela tiden utan den förändras när metoden invokas igen
	}

	void RunFromPacman ()
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
		NavMeshAgent ghost = GetComponent<NavMeshAgent> ();
		ghost.destination = choice.transform.position;

		CancelInvoke ("RunFromPacman");
	}
}
