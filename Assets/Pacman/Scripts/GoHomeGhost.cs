using UnityEngine;
using System.Collections;

public class GoHomeGhost : MonoBehaviour {


	public GameObject ghost;
	private GameObject home;




	// Use this for initialization
	void Start () {

		home = GameObject.Find ("home");

		NavMeshAgent ghost = GetComponent<NavMeshAgent> ();
		ghost.destination = home.transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position == home.transform.position)
		{
			Destroy(this.gameObject,0f);
			Instantiate(ghost, new Vector3(home.transform.position.x, home.transform.position.y + 5f, home.transform.position.z), Quaternion.identity);
		}

	
	}
}
