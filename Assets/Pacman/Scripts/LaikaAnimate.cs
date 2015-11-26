using UnityEngine;
using System.Collections;

public class LaikaAnimate : MonoBehaviour {

    GameObject pacman;
    public Animator Laika;
    public vision vs;
    bool eating;

    // Use this for initialization
    void Start()
    {
        eating = true;
        pacman = GameObject.Find("pacman");
        Laika = GetComponent<Animator>();
        Laika.Play("Eating");
        
    }
	// Update is called once per frame
	void Update () {


	
        if (vs.sees == true)
            {
            Laika.Play("Runing");
            eating = false;
        }
        else if (!eating && vs.sees == false)
        {
            Laika.Play("Idle");
        }
	}
}
