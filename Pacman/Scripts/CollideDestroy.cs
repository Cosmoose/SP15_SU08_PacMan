using UnityEngine;
using System.Collections;

public class CollideDestroy : MonoBehaviour {

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Untagged")
		{
			Destroy(col.gameObject);
		}
		else if (col.gameObject.tag == "hunting")
		{
			Destroy(gameObject);
		}
	}
}
