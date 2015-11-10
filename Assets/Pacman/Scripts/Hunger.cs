using UnityEngine;
using System.Collections;

public class Hunger : MonoBehaviour {

	public float hunger;
	public float maxhunger;

	Rect hungerRect; // används för att visa var vi ritar rektangeln
	Texture2D hungerTexture; // själva texutren

	// Use this for initialization
	void Start () {

		hunger = 10f;
		maxhunger = 10f;

		hungerRect = new Rect (Screen.width / 3, Screen.height * 9 / 10, Screen.width / 3, Screen.height / 50); // (vart på x axeln, vart på y axeln, hur bred rektangeln är, hur hög den är)
		hungerTexture = new Texture2D (1, 2); 
		hungerTexture.SetPixel (0, 0, Color.red); 
		hungerTexture.Apply ();
	
	}
	
	// Update is called once per frame
	void Update () {


		hunger -= Time.deltaTime;


		if (hunger < 0)
		{
			Destroy (gameObject);
		}
	
	}

	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.tag == "pellets")
		{
			if (hunger < maxhunger)
			{
				hunger += 1;
			}
		}
	}
	void OnGUI() 
	{ 
		float ratio = hunger / maxhunger; 
		float rectWidth = ratio * Screen.width / 3; 
		hungerRect.width = rectWidth; 
		GUI.DrawTexture (hungerRect, hungerTexture); 
	} 
}
