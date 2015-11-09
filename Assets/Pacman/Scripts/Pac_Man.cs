using UnityEngine;
using System.Collections;

public class Pac_Man : MonoBehaviour {

	public float movementSpeed = 10.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxis ("Horizontal") * movementSpeed * Time.deltaTime;
		transform.Translate (horizontal, 0, 0);

		float vertical = Input.GetAxis ("Vertical") * movementSpeed * Time.deltaTime;
		transform.Translate (0, 0, vertical);
	
	}
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Power UP")
        {
            Destroy(col.gameObject);
            transform.gameObject.tag = "hunting";
        }
    }
}
