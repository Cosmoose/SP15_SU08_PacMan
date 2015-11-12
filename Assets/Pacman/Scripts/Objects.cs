using UnityEngine;
using System.Collections;

public class Objects : MonoBehaviour {
	int score = 0;
	public int lives = 3;
	public GameObject respawnPrefab;
	public GameObject respawn;
	void Start() {
		if (respawn == null)
			respawn = GameObject.FindWithTag("Respawn");
	}

	void OnCollisionEnter (Collision col)
	{
		if((col.gameObject.tag == "ghost")&&(gameObject.tag == "hunting"))
		{
			score += 200;
			Destroy(col.gameObject);
		}
		if ((col.gameObject.tag == "ghost")&&(gameObject.tag == "Untagged")){
			lives-= 1;
			Instantiate(respawnPrefab, respawn.transform.position, respawn.transform.rotation);
			Destroy(gameObject);
		}
		if (lives == 0){
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter(Collider col)
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
		GUI.Label (new Rect (10, 10, 1000, 30), "Your score is: " +score +" points");
		if (lives != 1){
			GUI.Label (new Rect (10, 30, 1000, 30), "You have " +lives +" lives left");
		}
		else if (lives == 1){
			GUI.Label (new Rect (10, 30, 1000, 30), "You have " +lives +" live left!");
		}
	}
}
