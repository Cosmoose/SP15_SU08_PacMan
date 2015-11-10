using UnityEngine;
using System.Collections;

public class rightCheck : MonoBehaviour {
	
	public bool right;
	
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
			right = true;
			Debug.Log ("right");
		}
	}
}