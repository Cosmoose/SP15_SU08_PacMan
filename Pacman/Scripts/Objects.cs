using UnityEngine;
using System.Collections;

public class Objects : MonoBehaviour {
	int score = 0;
	void Start () {
		
	}
	void OnTriggerEnter (Collider col)
	{
		if(col.gameObject.tag == "Power UP")
		{
			Destroy(col.gameObject);
			transform.gameObject.tag = "hunting";
			score += 500;
		}
		if(col.gameObject.tag == "pellets")
		{
			Destroy(col.gameObject);
			score += 100;
		}
		if(col.gameObject.tag == "boosts")
		{
			Destroy(col.gameObject);
			score += 300;
		}
	}
	void OnGUI()
	{
		GUI.Label (new Rect (10, 10, 1000, 30), "Your score is: " +score);
	}
}
