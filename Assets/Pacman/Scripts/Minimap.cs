using UnityEngine;
using System.Collections;

public class Minimap : MonoBehaviour
{

    public Transform pac;

	// Use this for initialization
	void Start () {

       

    }
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(pac.transform.position.x, 500, pac.transform.position.z);
    }
}
