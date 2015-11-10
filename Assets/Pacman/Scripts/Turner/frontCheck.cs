using UnityEngine;
using System.Collections;

public class frontCheck : MonoBehaviour {
	
	public bool front;
	
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
			front = true;
			Debug.Log ("front");
		}
	}
}