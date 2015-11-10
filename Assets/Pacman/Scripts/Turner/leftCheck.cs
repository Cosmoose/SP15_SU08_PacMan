using UnityEngine;
using System.Collections;

public class leftCheck : MonoBehaviour {

	public bool left;

	// Use this for initialization
	void Start () {
	
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider coll)
	{
		if (coll.gameObject.tag == "wall")
		{
			left = true;
			Debug.Log("left");
		}
	}
}
