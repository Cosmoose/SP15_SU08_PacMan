using UnityEngine;
using System.Collections;

public class GoHomeGhost : MonoBehaviour {


	public GameObject ghost;
	private GameObject home;




	// Use this for initialization
	void Start () {

		home = GameObject.Find ("DeadGhostHome");

		NavMeshAgent ghost = GetComponent<NavMeshAgent> ();
		ghost.destination = home.transform.position;
        Debug.Log(home.transform.position);
	
	}
	
	// Update is called once per frame
	void Update () {

		if (gameObject.transform.position.x == home.transform.position.x && gameObject.transform.position.y == gameObject.transform.position.y)
		{
			Destroy(gameObject,0f);
			Instantiate(ghost, home.transform.position, Quaternion.identity);
		}

	
	}
}
