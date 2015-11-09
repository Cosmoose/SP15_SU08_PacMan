using UnityEngine;
using System.Collections;

public class PacMan : MonoBehaviour {

	void Start () {

	}


	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "Power UP")
		{
			Destroy(col.gameObject);
			transform.gameObject.tag = "hunting";
		}
	}
}

