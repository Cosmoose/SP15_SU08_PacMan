using UnityEngine;
using System.Collections;

public class ObjectsScript : MonoBehaviour {
	int PowerUP;
	int pellets;
	public int pointsForLives = 1000;
	int score = 0;
	int lastPoints = 0;
	public int lives = 3;
	Vector3 startPos;
	Quaternion startRot;

	void Start() {
		DontDestroyOnLoad(this);
		if (FindObjectsOfType(GetType()).Length > 1)
		{
		Destroy(gameObject);
		}
		startPos = transform.position;
		startRot = transform.rotation;
	}
	
	void Update () {
		if(score - lastPoints >= pointsForLives) 
		{
		lives += 1;
		lastPoints = score;
		}
		if ((pellets == 0)&&(PowerUP == 0))
		{
		Application.LoadLevel ("PacMan1");
		transform.position=startPos;
		transform.rotation=startRot;
		}
		pellets = GameObject.FindGameObjectsWithTag("pellets").Length;
		PowerUP = GameObject.FindGameObjectsWithTag("Power UP").Length;
	}

	void OnCollisionEnter (Collision other)
	{
		if((other.gameObject.tag == "ghost")&&(gameObject.tag == "hunting"))
		{
		score += 200;
		Destroy(other.gameObject);
		}
		if ((other.gameObject.tag == "ghost")&&(gameObject.tag == "Player")){
		lives-= 1;
		transform.position=startPos;
		transform.rotation=startRot;
		}
		if (lives == 0){
		Destroy(gameObject);
		Application.LoadLevel ("GameOver");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Power UP")
		{
		score += 500;
		Destroy(other.gameObject);
		transform.gameObject.tag = "hunting";
		Invoke ("StopHunting", 10.0f);
		}
		if(other.gameObject.tag == "pellets")
		{
		score += 100;
		Destroy(other.gameObject);
		}
		if(other.gameObject.tag == "boosts")
		{
		score += 300;
		Destroy(other.gameObject);
		}
	}
	
	void StopHunting ()
	{
		transform.gameObject.tag = "Player";
	}

	void OnGUI()
	{
		GUI.Label (new Rect (10, 5, 1000, 30), "Your score is: " +score +" points");
		if (lives != 1)
		{
		GUI.Label (new Rect (10, 20, 1000, 30), "You have " +lives +" lives left");
		}
		else if (lives == 1)
		{
		GUI.Label (new Rect (10, 20, 1000, 30), "You have " +lives +" live left!");
		}
		GUI.Label (new Rect (10, 35, 1000, 30), "You have " +pellets +" pellets and " +PowerUP +" power UPs left");
	}
}
