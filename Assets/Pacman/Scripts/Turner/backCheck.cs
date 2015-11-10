using UnityEngine;
using System.Collections;

public class backCheck : MonoBehaviour {
	
	public bool back;
	
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
			back = true;
			Debug.Log ("back");
		}
	}
}
