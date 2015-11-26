using UnityEngine;
using System.Collections;

public class ObjectsScript : MonoBehaviour {
	GUIStyle guiStyle = new GUIStyle();
	public Font f;
	int pickUPs;
	float time;
	int PowerUP;
	int pellets;
	public int pointsForLives = 1000;
	int score = 0;
	int lastPoints = 0;
	public int lives = 3;
	Vector3 startPos;
	Quaternion startRot;
	float hunger;
	float maxhunger;
	Rect hungerRect;
	Texture2D hungerTexture;
	public Texture2D aTexture;
	public Texture2D image;
	public Texture2D OneLife;
	public Texture2D TwoLifes;
	public Texture2D ThreeLifes;
	public Texture2D FourLifes;
	public Texture2D FiveLifes;
	public Texture2D SixLifes;
    public float Timer;
    public GameObject deadGhost;
    public bool hunting;

    void Start() {
		guiStyle.normal.textColor = Color.white;
		hunger = 100f;
		maxhunger = 100f;
        Timer = 15f;
        

        hungerTexture = new Texture2D (1, 2); 
		hungerTexture = aTexture; 

		DontDestroyOnLoad(this);
		if (FindObjectsOfType(GetType()).Length > 1)
		{
		Destroy(gameObject);
		}
		startPos = transform.position;
		startRot = transform.rotation;
        Debug.Log(Timer);

	}
	
	void Update () {

        if (lives >= 6){
			lives = 6;
		}

        pellets = GameObject.FindGameObjectsWithTag("pellets").Length;
        PowerUP = GameObject.FindGameObjectsWithTag("Power UP").Length;
        pickUPs = pellets + PowerUP;
        hunger -= Time.deltaTime;

		if ((hunger == maxhunger) || (hunger >= maxhunger)){
			hunger = maxhunger;
		}

		if (hunger < 0)
		{
			lives-= 1;
			transform.position=startPos;
			transform.rotation=startRot;
            hunger = maxhunger;
		}
		if (lives == 0){
			Destroy(gameObject);
			Application.LoadLevel ("GameOver");
		}

		time = Time.fixedTime;
		if(score - lastPoints >= pointsForLives) 
		{
		lives += 1;
		lastPoints = score;
		}
		if (pickUPs == 0)
		{
		Application.LoadLevel ("s_PAC_e_MAN");
		transform.position=startPos;
		transform.rotation=startRot;
            Timer = Timer * 0.9f;
            Debug.Log(Timer);
		}
		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
		
	}

	void OnCollisionEnter (Collision other)
	{
		
		if((other.gameObject.tag == "ghost")&&(gameObject.tag == "hunting"))
		{
		score += 200;
		Destroy(other.gameObject);
            Instantiate(deadGhost, transform.position, Quaternion.identity);
		}
		if ((other.gameObject.tag == "ghost")&&(gameObject.tag == "Player") || other.gameObject.tag == "sentinel"){
		lives-= 1;
		transform.position=startPos;
		transform.rotation=startRot;
            hunger = maxhunger;
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
		Invoke ("StopHunting", Timer);
            hunting = true;

			if (hunger < maxhunger)
			{
				hunger += 10;
			}
		}
		if(other.gameObject.tag == "pellets")
		{
		score += 100;
		Destroy(other.gameObject);
			if (hunger < maxhunger)
			{
				hunger += 10;
			}
		}
		if(other.gameObject.tag == "boosts")
		{
		score += 300;
		Destroy(other.gameObject);
			if (hunger < maxhunger)
			{
				hunger += 10;
			}
		}
	}
	
	void StopHunting ()
	{
        hunting = false;
		transform.gameObject.tag = "Player";
	}

	void OnGUI()
	{ 	GUI.skin.font = f;
		guiStyle.fontSize = 24;
		GUI.DrawTexture(new Rect(0, 0, 300, 150), image);
		hungerRect = new Rect (12, 14, 60, 25);
		if (lives == 6){
		GUI.DrawTexture (new Rect (12, 42, 220, 25), SixLifes);
		}
		else if (lives == 5){
		GUI.DrawTexture (new Rect (12, 42, 220, 25), FiveLifes);
		}
		else if (lives == 4){
			GUI.DrawTexture (new Rect (12, 42, 220, 25), FourLifes);
		}
		else if (lives == 3){
			GUI.DrawTexture (new Rect (12, 42, 220, 25), ThreeLifes);
		}
		else if (lives == 2){
			GUI.DrawTexture (new Rect (12, 42, 220, 25), TwoLifes);
		}
		else if (lives == 1){
			GUI.DrawTexture (new Rect (12, 42, 220, 25), OneLife);
		}
		GUI.Label (new Rect (12, 65, 1000, 50), "Your score is: " +score +" points", guiStyle);
		GUI.Label (new Rect (12, 85, 1000, 30), "You have " +pickUPs +" pickUPs left", guiStyle);
		GUI.Label (new Rect (12, 105, 1000, 30), "Time played: " +time, guiStyle);
		 
		float ratio = hunger / maxhunger; 
		float rectWidth = ratio * 276; 
		hungerRect.width = rectWidth; 
		GUI.DrawTexture (hungerRect, hungerTexture); 
	}
}
