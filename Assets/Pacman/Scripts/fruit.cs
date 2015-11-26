using UnityEngine;
using System.Collections;

public class fruit : ObjectsScript {

    
    

	// Use this for initialization
	void Start () {

        
		//Invoke ("destroy", OS.Timer);

	}


	void destroy ()
	{
		Destroy (gameObject, 0f);
	}


}
